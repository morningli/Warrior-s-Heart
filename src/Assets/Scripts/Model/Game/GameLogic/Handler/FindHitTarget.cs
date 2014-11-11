using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FindHitTargetHandler_Base : BattleEventHandler
{

    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        if (sponsors.Count > 0)
        {
            if (sponsors[0].isAttacker)
            {
                foreach (Warrior item in BattleField.Instance.DefenderList)
                {
                    float distance = Mathf.Abs(sponsors[0].transform.localPosition.x - item.transform.localPosition.x)/BattleField.Instance.baseLength;
                    if (sponsors[0].attackDistance>=distance)
                    {
                        responders.Add(item);
                    }
                }
            }
            else
            {
                foreach (Warrior item in BattleField.Instance.AttackerList)
                {
                    float distance = Mathf.Abs(sponsors[0].transform.localPosition.x - item.transform.localPosition.x) / BattleField.Instance.baseLength;
                    if (sponsors[0].attackDistance >= distance)
                    {
                        responders.Add(item);
                    }
                }
            }
        }
        return null;
    }
}
