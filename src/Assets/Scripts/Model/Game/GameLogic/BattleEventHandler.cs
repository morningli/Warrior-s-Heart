using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BattleEventHandlerType
{
    Unknow,
}
public class BattleEventHandler
{
    BattleEventHandlerType type;
    int priority;
    public virtual bool HandleEvent(List<Warrior> sponsors, List<Warrior> responders, int priority, ArrayList paramlist)
    {
        return false;
    }
}


