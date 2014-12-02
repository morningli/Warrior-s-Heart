using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidHitHandler_Base : BattleEventHandler
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        if (responders.Count==0)
        {
            return null;
        }
        KnockEventMessage knockmsg = new KnockEventMessage();
        knockmsg.KnockStrength = 0;
        foreach (Warrior item in sponsors)
        {
            knockmsg.KnockStrength += item.knockback;
        }
        BattleField.Instance.SendEvent(BattleEventType.WillKnock, sponsors, responders, knockmsg);
        if (knockmsg.ContinueAction)
        {
            float dis=0;
            int id = 0;
            for (int i = 0; i < responders.Count; i++)
            {
                float len = Mathf.Abs(responders[i].transform.localPosition.x - sponsors[0].transform.localPosition.x);
                if (len>dis)
                {
                    dis = len;
                    id = i;
                }
            }
            BattleField.Instance.SendEvent(BattleEventType.DidKnock, sponsors, responders, knockmsg);
            responders[id].moveState = MoveState.KnockBack;
            responders[id].rigidbody.AddForce(new Vector3(-knockmsg.KnockStrength * responders[0].dir, 0, 0), ForceMode.Impulse);
            //responders[id].rigidbody.velocity = new Vector3(-knockmsg.KnockStrength * responders[0].dir, 0, 0);
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
