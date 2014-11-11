using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WarriorState
{
    Idle,
    Move,
    Attack,
}


public class Warrior : MonoBehaviour
{

    public float knockback;
    public float antiKnockback;
    public float physicalAttack;
    public float physicalDefence;
    public float magicAttack;
    public float magicDefence;
    public float hitDelay;
    public float maxHP;
    public float maxMoveSpeed;


    public float hp;
    public float moveSpeed;
    public float attackSpeed;
    public float acceleration;
    public float attackDistance;
    
    public float hitRestTime;
    public WarriorState state;
    public bool isAttacker;



    public OrderedList<BattleEventHandler> FindHitTargetHandler = new OrderedList<BattleEventHandler>();

    void Awake()
    {
        knockback = 5;
        maxMoveSpeed = 10;
        acceleration = 2;
        attackDistance = 5;
        hitDelay = 0.1f;
        this.FindHitTargetHandler.Add(new FindHitTargetHandler_Base());
    }

    public void Attack()
    {
        BattleEventMessage msg = new BattleEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillAttack, new List<Warrior>() { this }, null, msg);
        if (!msg.ContinueAction)
        {
            return;
        }
        this.state = WarriorState.Attack;
        this.hitRestTime = this.hitDelay;
        BattleField.Instance.SendEvent(BattleEventType.DidAttack, new List<Warrior>() { this }, null, msg);
        
    }

    void Update()
    {
        int dir = 0;
        if (isAttacker)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
        if (state==WarriorState.Attack)
        {
            this.hitRestTime -= Time.deltaTime;
            if (this.hitRestTime<=0)
            {
                this.hitRestTime = this.hitDelay;
                this.state = WarriorState.Idle;
                this.Hit();
            }
        }

        if (this.state==WarriorState.Idle)
        {
            this.state = WarriorState.Move;
        }


        if (this.state==WarriorState.Move)
        {
            this.moveSpeed += this.acceleration * Time.deltaTime;
            this.transform.localPosition = new Vector3(this.transform.localPosition.x + dir * this.moveSpeed * Time.deltaTime * BattleField.Instance.baseLength, 0, 0);
        }

    }
    void Hit()
    {
        //FindTarget
        List<Warrior> sponsors=new List<Warrior>() { this };
        List<Warrior> responders = new List<Warrior>();
        if (FindHitTargetHandler.Count>0)
        {
            FindHitTargetHandler[0].HandleEvent(sponsors, responders);
        }
        BattleEventMessage msg=new BattleEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillHit, sponsors, responders, msg);
        if (!msg.ContinueAction)
        {
            return;
        }
        BattleField.Instance.SendEvent(BattleEventType.DidHit, sponsors, responders, msg);


    }
}
