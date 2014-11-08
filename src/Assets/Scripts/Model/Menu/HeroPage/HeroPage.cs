using UnityEngine;
using System.Collections;

public class HeroPage : BasePage {
	static HeroPage m_instance;
	public static HeroPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/HeroPage/HeroPage").GetComponent<HeroPage>();
			}
			return m_instance;
		}
	}

	void Awake()
	{
		//UIEventListener.Get (gameObject.FindChild ("startGameButton")).onClick = OnStartGameClick;
		gameObject.FindChild ("InfoData").GetComponent<UILabel> ().text = "气血:90\n力量:90\n速度:90\n法术:90";
		UIEventListener.Get (gameObject.FindChild("Select1")).onClick = OnClickForSelectSkill;
	}
	
	void OnClickForSelectSkill(GameObject go)
	{
		Debug.Log ("select");
		//Application.LoadLevel ("Game");
		PageManager.Instance.ShowPage(SkillPage.Instance);
	}
}
