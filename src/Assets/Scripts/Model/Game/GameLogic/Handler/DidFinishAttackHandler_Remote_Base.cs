using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DidFinishAttackHandler_Remote_Base : BattleEventHandler 
{
    public override object HandleEvent(List<Warrior> sponsors = null, List<Warrior> responders = null, object param0 = null, object param1 = null, object param2 = null, object param3 = null)
    {
        if (sponsors[0]!=owner)
        {
            return null;
        }
        Debug.Log("aa");
        Ammo ammo = Ammo.Create();
        BattleField.Instance.gameObject.AddChild(ammo.gameObject);
        ammo.transform.localPosition = sponsors[0].transform.localPosition;
        int dir = 0;
        //忽视本方碰撞
        List<Warrior> list;
        if (sponsors[0].isAttacker)
        {
            list = BattleField.Instance.AttackerList;
            ammo.transform.localScale = new Vector3(1, 1, 1);
            dir = 1;
        }
        else
        {
            list = BattleField.Instance.DefenderList;
            ammo.transform.localScale = new Vector3(-1, 1, 1);
            dir = -1;

        }
        foreach (Warrior warrior in list)
        {
            Physics.IgnoreCollision(ammo.collider, warrior.collider);
        }
        
        //发射
        ammo.rigidbody.velocity = new Vector3(dir, 0, 0);
        return null;
    }
}
