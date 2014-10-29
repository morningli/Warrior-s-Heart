using UnityEngine;
using System.Collections;

public class LoginScene : MonoBehaviour 
{
    void Start()
    {
        PageManager.Instance.ShowPage(LogoPage.Instance);
    }

    void Update()
    {
        EventManager.Instance.Update();
    }
}
