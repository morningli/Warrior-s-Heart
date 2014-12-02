using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidFinishAttackHandler_Melee_Base : BattleEventHandler
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        //FindTarget

        if (sponsors[0].FindHitTargetHandler.Count > 0)
        {
            responders = new List<Warrior>();
            sponsors[0].FindHitTargetHandler[0].HandleEvent(sponsors, responders);
        }
        BattleEventMessage msg = new BattleEventMessage();
        BattleField.Instance.SendEvent(BattleEventType.WillHit, sponsors, responders, msg);
        if (!msg.ContinueAction)
        {
            return null;
        }
        BattleField.Instance.SendEvent(BattleEventType.DidHit, sponsors, responders, msg);
        return null;
    }
}
