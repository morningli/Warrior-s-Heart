using UnityEngine;
using System.Collections;

public class ProfilePage : BasePage {


	static ProfilePage m_instance;
	public static ProfilePage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/ProfilePage").GetComponent<ProfilePage>();
			}
			return m_instance;
		}
	}
	
	
	void Awake()
	{
		UIEventListener.Get (gameObject.FindChild ("startGameButton")).onClick = OnStartGameClick;
	}
	
	void OnStartGameClick(GameObject go)
	{
		Debug.Log ("134");
		//Application.LoadLevel ("Game");
	}
}
