using UnityEngine;
using System.Collections;

public class MenuScene : MonoBehaviour 
{
	void Start()
	{
		PageManager.Instance.ShowPage(MainMenuPage.Instance);
	}

    void Update()
    {
        EventManager.Instance.Update();
    }
}
