using UnityEngine;
using System.Collections;

public class GameScene : MonoBehaviour 
{

	void Start ()
    {
        PageManager.Instance.ShowPage(GamePage.Instance);
	}

    void Update()
    {
        EventManager.Instance.Update();
    }
}
