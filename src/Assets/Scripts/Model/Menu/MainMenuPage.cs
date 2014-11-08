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
				m_instance = ResourceManager.Load("Prefab/Menu/MainMenuPage/MainMenuPage").GetComponent<MainMenuPage>();
			}
			return m_instance;
		}
	}
	

	void Awake()
	{
		UIEventListener.Get(gameObject.FindChild ("MilitaryButton")).onClick = OnStartGameClick;
	}

	void OnStartGameClick(GameObject go)
	{
		Debug.Log("2134");
	}
}
