using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour 
{
    public static Ammo Create()
    {
        return ResourceManager.Load("Prefab/Game/Ammo").GetComponent<Ammo>();
    }
}
