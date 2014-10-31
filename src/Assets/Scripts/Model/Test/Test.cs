using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Test : MonoBehaviour 
{
	void Start () 
    {
        OrderedList<BattleEventHandler> list = new OrderedList<BattleEventHandler>(new EventHandlerComparer());
        for (int i = 0; i < 100; i++)
        {
            BattleEventHandler handle=new BattleEventHandler();
            handle.priority=Random.Range(0, 100);
            list.Add(handle);
        }

        for (int i = 0; i < 100; i++)
        {
            Debug.Log(list[i].priority);
        }
	}


}
