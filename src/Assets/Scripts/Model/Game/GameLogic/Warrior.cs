using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void BattleEventDelegate(List<Warrior> sponsors,List<Warrior> responders,int priority,ArrayList paramlist);
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

    public SortedList WillStartBattleHandler;
    public SortedList DidStartBattleHandler;
    public SortedList WillAttackHandler;
    public SortedList DidAttackHandler;
    public SortedList WillHitHandler;
    public SortedList DidHitHandler;
    public SortedList WillBeHitHandler;
    public SortedList DidBeHitHandler;
    public SortedList WillKnockHandler;
    public SortedList DidKnockHandler;
    public SortedList WillBeKnockHandler;
    public SortedList DidBeKnockHandler;
    public SortedList WillHurtHandler;
    public SortedList DidHurtHandler;
    public SortedList ArriveTopSpeedHandler;
    public SortedList StopKnockBackHandler;
    public SortedList KnockScreenEdgeHandler;
    public SortedList WillStartSpellHandler;
    public SortedList DidStartSpellHandler;
    public SortedList WillSpellFinishHandler;
    public SortedList DidSpellFinishHandler;
    public SortedList UpdateHandler;

    void Update()
    {
        
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
