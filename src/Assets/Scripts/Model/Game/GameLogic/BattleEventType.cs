using UnityEngine;
using System.Collections;

public enum BattleEventType
{
    WillStartBattle,
    DidStartBattle,
    WillAttack,
    DidAttack,
    WillFinishAttack,
    DidFinishAttack,
    WillHit,
    DidHit,
    WillKnock,
    DidKnock,
    WillHurt,
    DidHurt,
    ArriveTopSpeed,
    StopKnockBack,
    KnockScreenEdge,
    WillPrepareSpell,
    DidPrepareSpell,
    WillStartSpell,
    DidStartSpell,
    WillFinishSpell,
    DidFinishSpell,
    WillBreakSpell,
    DidBreakSpell,
    WillBeBreakSpell,
    DidBeBreakSpell,
    WillUpdate,
    DidUpdate,
}

public class BattleEventMessage
{
    public bool ContinueAction = true;
}


public class KnockEventMessage : BattleEventMessage
{
    public float KnockStrength;
}

public class HurtEventMessage : BattleEventMessage
{
    public float Damage;
}