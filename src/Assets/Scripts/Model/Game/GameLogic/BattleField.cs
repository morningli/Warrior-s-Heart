using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// public delegate void BattleEventDelegate(BattleEventDefine define, List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null);
class EventHandlerComparer : IComparer<BattleEventHandler>
{
    public int Compare(BattleEventHandler x, BattleEventHandler y)
    {
        if (x.priority > y.priority)
        {
            return -1;
        }
        else if (x.priority < y.priority)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
public class BattleField : MonoBehaviour
{
    static BattleField m_instance;
    public static BattleField Instance
    {
        get
        {
            return m_instance;
        }
    }
    public List<Warrior> AttackerList;
    public List<Warrior> DefenderList;

    public float baseLength;

    void Awake()
    {
        m_instance = this;
        baseLength = Screen.currentResolution.width / 100.0f;
    }
    public void StartBattle()
    {
        this.SendEvent(BattleEventType.WillStartBattle);
        /////////////////////////
        for (int i = 0; i < 2; i++)
        {
            Warrior attacker = ResourceManager.Load("Prefab/Game/Warrior").GetComponent<Warrior>();
            this.gameObject.AddChild(attacker.gameObject);
            attacker.transform.localPosition = new Vector3(-Screen.width/2 + 50+i*20, -Screen.height + 50, 0);
            attacker.isAttacker = true;
            AttackerList.Add(attacker);
        }
        for (int i = 0; i < 2; i++)
        {
            Warrior defender = ResourceManager.Load("Prefab/Game/Warrior").GetComponent<Warrior>();
            this.gameObject.AddChild(defender.gameObject);
            defender.transform.localPosition = new Vector3(Screen.width/2 - 50-i*20, -Screen.height + 50, 0);
            DefenderList.Add(defender);
        }

        DidHitHandler_Base didhitbase = new DidHitHandler_Base();
        this.RegisterEvent(BattleEventType.DidHit, didhitbase);
        /////////////////////////
        this.SendEvent(BattleEventType.DidStartBattle);
    }


    //Event
    Dictionary<BattleEventType, OrderedList<BattleEventHandler>> EventDic = new Dictionary<BattleEventType, OrderedList<BattleEventHandler>>();

    public void RegisterEvent(BattleEventType define, BattleEventHandler handler)
    {
        if (!EventDic.ContainsKey(define))
        {
            EventDic.Add(define, new OrderedList<BattleEventHandler>(new EventHandlerComparer()));
        }
        EventDic[define].Add(handler);
    }

    public void UnRegisterEvent(BattleEventType define, BattleEventHandler handler)
    {
        if (!EventDic.ContainsKey(define))
        {
            return;
        }
        EventDic[define].Remove(handler);

    }

    public void SendEvent(BattleEventType define, List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {

        OrderedList<BattleEventHandler> handlerlist;
        try
        {
            handlerlist = EventDic[define];
        }
        catch (System.Exception ex)
        {
            Debug.Log("NoDelegateRecvThisEvent:" + define.ToString());
            return;
        }
        for (int i = 0; i < handlerlist.Count; i++)
        {
            handlerlist[i].HandleEvent(sponsors, responders, param0, param1, param2, param3);
        }
    }

    void Update()
    {
        foreach (Warrior attacker in AttackerList)
        {
            foreach (Warrior defender in DefenderList)
            {
                float dis = Mathf.Abs(attacker.transform.localPosition.x - defender.transform.localPosition.x) / baseLength;
                if (attacker.state!=WarriorState.Attack&&attacker.attackDistance >= dis)
                {
                    attacker.Attack();
                }
                if (defender.state != WarriorState.Attack && defender.attackDistance >= dis)
                {
                    defender.Attack();
                }
            }
        }
    }

}
