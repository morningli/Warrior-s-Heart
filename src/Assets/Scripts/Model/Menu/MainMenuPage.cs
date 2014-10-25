using UnityEngine;
using System.Collections;

public class MainMenuPage : BasePage 
{
	static MainMenuPage m_instance;
	public static MainMenuPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Login/MainMenuPage").GetComponent<MainMenuPage>();
			}
			return m_instance;
		}
	}
	

	void Awake()
	{
		UIEventListener.Get (gameObject.FindChild ("StartGame")).onClick = OnStartGameClick;
	}

	void OnStartGameClick(GameObject go)
	{
		Application.LoadLevel ("Game");
	}
}
