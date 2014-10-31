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
    public SortedList FindHitTargetHandler = new SortedList();
    public SortedList WillHitHandler = new SortedList();
    public SortedList DidHitHandler = new SortedList();
    public SortedList WillBeHitHandler = new SortedList();
    public SortedList DidBeHitHandler = new SortedList();
    public SortedList WillKnockHandler = new SortedList();
    public SortedList DidKnockHandler = new SortedList();
    public SortedList WillBeKnockHandler = new SortedList();
    public SortedList DidBeKnockHandler = new SortedList();
    public SortedList WillHurtHandler = new SortedList();
    public SortedList DidHurtHandler = new SortedList();
    public SortedList WillBeHurtHandler = new SortedList();
    public SortedList DidBeHurtHandler = new SortedList();
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
        List<Warrior> sponsors = new List<Warrior>();
        //Will
        {
            foreach (BattleEventHandler item in WillUpdateHandler)
            {
                item.HandleEvent(sponsors);
            }
        }


        //Do
        {
            HitRestTime -= Time.deltaTime;
            if (HitRestTime<=0)
            {
                HitRestTime = 0;
                Hit();
            }
        }


        //Did
        {
            foreach (BattleEventHandler item in DidUpdateHandler)
            {
                item.HandleEvent(sponsors);
            }
        }

    }

    public void WillStartBattle()
    {
        List<Warrior> sponsors = new List<Warrior>();
        foreach (BattleEventHandler item in WillStartBattleHandler)
        {
            item.HandleEvent(sponsors);
        }


    }

    public void DidStartBattle()
    {
        List<Warrior> sponsors = new List<Warrior>();
        foreach (BattleEventHandler item in DidStartBattleHandler)
        {
            item.HandleEvent(sponsors);
        }

    }

    public void Attack()
    {
        List<Warrior> sponsors = new List<Warrior>() { this };
        //Will
        {
            foreach (BattleEventHandler item in WillAttackHandler)
            {
                item.HandleEvent(sponsors);
            }
        }


        //Do
        {
            HitRestTime = HitDelay;
        }


        //Did
        {
            foreach (BattleEventHandler item in DidAttackHandler)
            {
                item.HandleEvent(sponsors);
            }
        }
    }

    public void Hit()
    {
        //FindHit
        List<Warrior> responders = new List<Warrior>();
        if (FindHitTargetHandler.Count>0)
        {
            responders = (FindHitTargetHandler[0] as BattleEventHandler).HandleEvent(new List<Warrior>() { this }) as List<Warrior>;
        }
        List<Warrior> sponsors = new List<Warrior>() { this };
        //Will
        {
            SortedList list = new SortedList();
            foreach (BattleEventHandler item in WillHitHandler)
            {
                list.Add(item.priority, item);
            }

            foreach (Warrior responder in responders)
            {
                foreach (BattleEventHandler item in responder.WillBeHitHandler)
                {
                    list.Add(item.priority, item);
                }
            }

            foreach (BattleEventHandler item in list)
            {
                item.HandleEvent(sponsors, responders);
            }

            
        }


        //Do
        {
           
        }


        //Did
        {
            SortedList list = new SortedList();
            foreach (BattleEventHandler item in DidHitHandler)
            {
                list.Add(item.priority, item);
            }

            foreach (Warrior responder in responders)
            {
                foreach (BattleEventHandler item in responder.DidBeHitHandler)
                {
                    list.Add(item.priority, item);
                }
            }

            foreach (BattleEventHandler item in list)
            {
                item.HandleEvent(sponsors, responders);
            }
        }
    }
    public void Knock(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        //Will
        {
            SortedList list = new SortedList();
            foreach (BattleEventHandler item in WillKnockHandler)
            {
                list.Add(item.priority, item);
            }

            foreach (Warrior responder in responders)
            {
                foreach (BattleEventHandler item in responder.WillBeKnockHandler)
                {
                    list.Add(item.priority, item);
                }
            }

            foreach (BattleEventHandler item in list)
            {
                item.HandleEvent(sponsors, responders, param0, param1, param2, param3);
            }


        }


        //Do
        {

        }


        //Did
        {
            SortedList list = new SortedList();
            foreach (BattleEventHandler item in DidKnockHandler)
            {
                list.Add(item.priority, item);
            }

            foreach (Warrior responder in responders)
            {
                foreach (BattleEventHandler item in responder.DidBeKnockHandler)
                {
                    list.Add(item.priority, item);
                }
            }

            foreach (BattleEventHandler item in list)
            {
                item.HandleEvent(sponsors, responders, param0, param1, param2, param3);
            }
        }
    }


    public void Hurt(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        //Will
        {
            SortedList list = new SortedList();
            foreach (BattleEventHandler item in WillHurtHandler)
            {
                list.Add(item.priority, item);
            }

            foreach (Warrior responder in responders)
            {
                foreach (BattleEventHandler item in responder.WillBeHurtHandler)
                {
                    list.Add(item.priority, item);
                }
            }

            foreach (BattleEventHandler item in list)
            {
                item.HandleEvent(sponsors, responders, param0, param1, param2, param3);
            }


        }


        //Do
        {

        }


        //Did
        {
            SortedList list = new SortedList();
            foreach (BattleEventHandler item in DidBeHurtHandler)
            {
                list.Add(item.priority, item);
            }

            foreach (Warrior responder in responders)
            {
                foreach (BattleEventHandler item in responder.DidBeHurtHandler)
                {
                    list.Add(item.priority, item);
                }
            }

            foreach (BattleEventHandler item in list)
            {
                item.HandleEvent(sponsors, responders, param0, param1, param2, param3);
            }
        }
    }


    public void ArriveTopSpeed()
    {
        List<Warrior> sponsors = new List<Warrior>() { this };
        foreach (BattleEventHandler item in ArriveTopSpeedHandler)
        {
            item.HandleEvent(sponsors);
        }
    }

    public void StopKnockBack()
    {
        List<Warrior> sponsors = new List<Warrior>() { this };
        foreach (BattleEventHandler item in StopKnockBackHandler)
        {
            item.HandleEvent(sponsors);
        }
    }

    public void KnockScreenEdge()
    {
        List<Warrior> sponsors = new List<Warrior>() { this };
        foreach (BattleEventHandler item in KnockScreenEdgeHandler)
        {
            item.HandleEvent(sponsors);
        }
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
