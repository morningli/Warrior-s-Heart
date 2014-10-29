using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Test : MonoBehaviour 
{
    float mx = 1;
    float tx
    {
        get
        {
            return mx;
        }
        set
        {
            mx = value;
            Debug.Log(mx);
        }
    }

    float getit()
    {
        return tx;
    }
    void setit(float x)
    {
        tx = x;
    }
	void Start () 
    {
        
	}

    void Update()
    {
        Debug.Log(Time.time);
    }

}
