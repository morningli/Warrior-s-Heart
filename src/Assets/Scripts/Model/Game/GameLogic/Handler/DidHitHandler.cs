﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidHitHandler_Base : BattleEventHandler
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        KnockEventMessage knockmsg = new KnockEventMessage();
        knockmsg.KnockStrength = 0;
        foreach (Warrior item in sponsors)
        {
            knockmsg.KnockStrength += item.knockback;
        }
        BattleField.Instance.SendEvent(BattleEventType.WillKnock, sponsors, responders, knockmsg);
        if (knockmsg.ContinueAction)
        {
            BattleField.Instance.SendEvent(BattleEventType.DidKnock, sponsors, responders, knockmsg);
        }
        

        HurtEventMessage hurtmsg = new HurtEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillHurt, sponsors, responders, hurtmsg);
        if (hurtmsg.ContinueAction)
        {
            BattleField.Instance.SendEvent(BattleEventType.DidHurt, sponsors, responders, hurtmsg);
        }
        
        return null;
    }
}
