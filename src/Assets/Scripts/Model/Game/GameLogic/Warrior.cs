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

    public float Knockback;
    public float AntiKnockback;
    public float PhysicalAttack;
    public float PhysicalDefence;
    public float MagicAttack;
    public float MagicDefence;
    public float HitDelay;
    public float MaxHP;
    public float MaxMoveSpeed;


    public float HP;
    public float MoveSpeed;
    public float AttackSpeed;
    public float Acceleration;
    public float AttackDistance;
    
    public float HitRestTime;
    public WarriorState state;



    public OrderedList<BattleEventHandler> FindHitTargetHandler = new OrderedList<BattleEventHandler>();

    public void Attack()
    {
        BattleEventMessage msg = new BattleEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillAttack, new List<Warrior>() { this }, null, msg);
        if (!msg.ContinueAction)
        {
            return;
        }
        this.state = WarriorState.Attack;
        this.HitRestTime = this.HitDelay;
        BattleField.Instance.SendEvent(BattleEventType.DidAttack, new List<Warrior>() { this }, null, msg);
        
    }

    void Update()
    {
        if (state==WarriorState.Attack)
        {
            this.HitRestTime -= Time.deltaTime;
            if (this.HitRestTime<=0)
            {
                this.HitRestTime = this.HitDelay;
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
            this.transform.localPosition = new Vector3(this.transform.localPosition.x + this.MoveSpeed * Time.deltaTime * BattleField.Instance.baseLength, 0, 0);
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
