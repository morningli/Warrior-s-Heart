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
        Ammo ammo = Ammo.Create();
        BattleField.Instance.gameObject.AddChild(ammo.gameObject);
        ammo.transform.localPosition = sponsors[0].transform.localPosition + new Vector3(0, 40, 0);
        int dir = 0;
        //忽视本方碰撞
        List<Warrior> warriorlist;
        List<Ammo> ammolist;
        if (sponsors[0].isAttacker)
        {
            warriorlist = BattleField.Instance.AttackerList;
            ammolist = BattleField.Instance.AttackerAmmoList;
            ammo.transform.localScale = new Vector3(1, 1, 1);
            dir = 1;
        }
        else
        {
            warriorlist = BattleField.Instance.DefenderList;
            ammolist = BattleField.Instance.DefenderAmmoList;
            ammo.transform.localScale = new Vector3(-1, 1, 1);
            dir = -1;

        }
        foreach (Warrior warrior in warriorlist)
        {
            Physics.IgnoreCollision(ammo.collider, warrior.collider);
        }
        foreach (Ammo otherammo in ammolist)
        {
            Physics.IgnoreCollision(ammo.collider, otherammo.collider);
        }
        ammolist.Add(ammo);
        
        //发射
        ammo.rigidbody.velocity = new Vector3(dir, 0, 0);
        return null;
    }
}
