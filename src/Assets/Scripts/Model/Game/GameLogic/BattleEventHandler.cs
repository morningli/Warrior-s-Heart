using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BattleEventHandlerType
{
    Unknow,
}
public class BattleEventHandler
{
    public BattleEventHandlerType type;
    public int priority;
    public virtual object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        return null;
    }
}

