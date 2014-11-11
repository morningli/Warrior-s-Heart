using UnityEngine;
using System.Collections;

public class Util 
{
    public static Transform FindTransform(string name,Transform tran)
    {
        if (tran.name.Equals(name))
        {
            return tran;
        }
        for (int i = 0; i < tran.childCount; i++)
        {
            Transform t = tran.GetChild(i);
            t = FindTransform(name, t);
            if (t!=null)
            {
                return t;
            }
        }
        return null;
    }
    public static GameObject FindChild(string name,GameObject obj)
    {
        Transform t=FindTransform(name,obj.transform);
        if (!t)
	    {
		    return null; 
	    }
        return t.gameObject;
    }
    public static void AddChild(GameObject obj,GameObject parent)
    {
        obj.transform.parent = parent.transform;
        obj.transform.localScale = new Vector3(1, 1, 1);
        obj.transform.localPosition = new Vector3(0, 0, 0);
    }
}
