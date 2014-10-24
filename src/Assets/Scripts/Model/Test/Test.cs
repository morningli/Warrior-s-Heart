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
        Debug.Log(Setting.Instance.currentSetting.GetInt("StartSpeed"));
        Debug.Log(Setting.Instance.currentSetting.GetInt("AddSpeed"));
	}

}
