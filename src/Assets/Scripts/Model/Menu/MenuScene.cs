using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour 
{
	void Start()
	{
		PageManager.Instance.ShowPage(UIHeroPage.Instance);
	}

    void Update()
    {
        EventManager.Instance.Update();
    }
}
