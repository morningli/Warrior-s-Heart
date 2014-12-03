using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour 
{
    public static Ammo Create()
    {
        return ResourceManager.Load("Prefab/Game/Ammo").GetComponent<Ammo>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Floor")
        {
            GameObject.Destroy(this.GetComponent<ConstantForce>());
            GameObject.Destroy(this.GetComponent<BoxCollider>());
            GameObject.Destroy(this.GetComponent<Rigidbody>());
            BattleField.Instance.AddTrash(this.gameObject);
        }
        else
        {
            this.rigidbody.useGravity = true;
            BattleField.Instance.AttackerAmmoList.Remove(this);
            BattleField.Instance.DefenderAmmoList.Remove(this);
        }
    }
    void Update()
    {

    }
}
