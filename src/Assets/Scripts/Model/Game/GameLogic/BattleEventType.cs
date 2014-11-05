using UnityEngine;
using System.Collections;

public enum BattleEventType
{
    WillStartBattle,
    DidStartBattle,
    WillAttack,
    DidAttack,
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
    int KnockStrength;
}

public class HurtEventMessage : BattleEventMessage
{
    int Damage;
}