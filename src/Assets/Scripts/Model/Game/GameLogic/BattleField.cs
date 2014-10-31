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
public enum BattleEventDefine
{

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
    List<Warrior> m_AttackerList;
    List<Warrior> m_DefenderList;


    void Awake()
    {
        m_instance = this;
    }
    public void StartBattle()
    {
        foreach (Warrior warrior in m_AttackerList)
        {
            warrior.WillStartBattle();
        }
        foreach (Warrior warrior in m_DefenderList)
        {
            warrior.WillStartBattle();
        }
        /////////////////////////



        /////////////////////////
        foreach (Warrior warrior in m_AttackerList)
        {
            warrior.DidStartBattle();
        }
        foreach (Warrior warrior in m_DefenderList)
        {
            warrior.DidStartBattle();
        }
    }


    //Event
    Dictionary<BattleEventDefine, OrderedList<BattleEventHandler>> EventDic = new Dictionary<BattleEventDefine, OrderedList<BattleEventHandler>>();

    public void RegisterEvent(BattleEventDefine define, int priority, BattleEventHandler handler)
    {
        if (!EventDic.ContainsKey(define))
        {
            EventDic.Add(define, new OrderedList<BattleEventHandler>(new EventHandlerComparer()));
        }
        EventDic[define].Add(handler);
    }

    public void UnRegisterEvent(BattleEventDefine define, BattleEventHandler handler)
    {
        if (!EventDic.ContainsKey(define))
        {
            return;
        }
        EventDic[define].Remove(handler);

    }

    public void SendEvent(BattleEventDefine define, List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
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

}
