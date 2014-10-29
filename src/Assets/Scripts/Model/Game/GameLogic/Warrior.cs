using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Warrior : MonoBehaviour 
{
    public float Knockback;
    public float AntiKnockback;
    public float PhysicalAttack;
    public float PhysicalDefence;
    public float MagicAttack;
    public float MagicDefence;
    public float HP;
    public float MaxHP;
    public float MoveSpeed;
    public float MaxMoveSpeed;
    public float AttackSpeed;
    public float Acceleration;
    public float AttackDistance;
    public float HitDelay;
    public float HitRestTime;

    public SortedList WillStartBattleHandler = new SortedList();
    public SortedList DidStartBattleHandler = new SortedList();
    public SortedList WillAttackHandler = new SortedList();
    public SortedList DidAttackHandler = new SortedList();
    public SortedList WillHitHandler = new SortedList();
    public SortedList DidHitHandler = new SortedList();
    public SortedList WillBeHitHandler = new SortedList();
    public SortedList DidBeHitHandler = new SortedList();
    public SortedList WillKnockHandler = new SortedList();
    public SortedList DidKnockHandler = new SortedList();
    public SortedList WillBeKnockHandler = new SortedList();
    public SortedList DidBeKnockHandler = new SortedList();
    public SortedList WillHurtHandler = new SortedList();
    public SortedList DidHurtHandle = new SortedList();
    public SortedList ArriveTopSpeedHandler = new SortedList();
    public SortedList StopKnockBackHandler = new SortedList();
    public SortedList KnockScreenEdgeHandler = new SortedList();
    public SortedList WillPrepareSpellHandler = new SortedList();
    public SortedList DidPrepareSpellHandler = new SortedList();
    public SortedList WillStartSpellHandler = new SortedList();
    public SortedList DidStartSpellHandler = new SortedList();
    public SortedList WillFinishSpellHandler = new SortedList();
    public SortedList DidFinishSpellHandler = new SortedList();
    public SortedList WillBreakSpellHandler = new SortedList();
    public SortedList DidBreakSpellHandler = new SortedList();
    public SortedList WillBeBreakSpellHandler = new SortedList();
    public SortedList DidBeBreakSpellHandler = new SortedList();
    public SortedList WillUpdateHandler = new SortedList();
    public SortedList DidUpdateHandler = new SortedList();

    void Update()
    {
        //WillUpdate
        {
            foreach (BattleEventHandler item in WillUpdateHandler)
            {
                List<Warrior> sponsprs = new List<Warrior>();
                item.HandleEvent(sponsprs, null, null);
            }
        }


        //Update
        {

        }


        //DidUpdate
        {
            foreach (BattleEventHandler item in DidUpdateHandler)
            {
                List<Warrior> sponsprs = new List<Warrior>();
                item.HandleEvent(sponsprs, null, null);
            }
        }

    }

    public void WillStartBattle()
    {

    }

    public void DidStartBattle()
    {

    }

    public void WillAttack()
    {

    }
    public void Attack()
    {

    }
    public void DidAttack()
    {

    }

    public void WillHit()
    {

    }
    public void Hit()
    {

    }

    public void DidHit()
    {

    }

    public void WillBeHit()
    {

    }

    public void BeHit()
    {

    }

    public void DidBeHit()
    {

    }

    public void WillKnock()
    {

    }

    public void DidKnock()
    {

    }

    public void WillBeKnock()
    {

    }

    public void DidBeKnock()
    {

    }

    public void WillHurt()
    {

    }

    public void DidHurt()
    {

    }
    public void WillBeHurt()
    {

    }

    public void DidBeHurt()
    {

    }

    public void ArriveTopSpeed()
    {

    }

    public void StopKnockBack()
    {

    }

    public void KnockScreenEdge()
    {

    }

    public void WillStartSpell()
    {

    }

    public void DidStartSpell()
    {

    }

    public void WillSpellFinish()
    {

    }
    public void DidSpellFinish()
    {

    }
}
