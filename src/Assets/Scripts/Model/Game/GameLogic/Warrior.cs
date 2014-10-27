using UnityEngine;
using System.Collections;

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

    public SortedList StartBattleHanders;
    public SortedList AttackHanders;
    public SortedList HitHanders;
    public SortedList BeHitHanders;
    public SortedList KnockHanders;
    public SortedList BeKnockHanders;
    public SortedList HurtHanders;
    public SortedList BeHurtHanders;

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
