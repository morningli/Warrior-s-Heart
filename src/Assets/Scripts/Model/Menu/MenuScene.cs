﻿using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour 
{
	void Start()
	{
		PageManager.Instance.ShowPage(ShopMenuPage.Instance);
	}

    void Update()
    {
        EventManager.Instance.Update();
    }
}
