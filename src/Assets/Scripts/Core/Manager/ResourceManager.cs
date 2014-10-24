using UnityEngine;
using System.Collections;

public class ResourceManager
{
    public static GameObject Load(string name)
    {
        Object obj= Resources.Load(name);
        return GameObject.Instantiate(obj) as GameObject;
    }
}
