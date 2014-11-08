using UnityEngine;
using System.Collections;

public class UISkillDetail : BasePage {
	static UISkillDetail m_instance;
	public static UISkillDetail Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/HeroPage/SkillDetail").GetComponent<UISkillDetail>();
			}
			return m_instance;
		}
	}
	
	void Awake()
	{
		//UIEventListener.Get (gameObject.FindChild ("startGameButton")).onClick = OnStartGameClick;
		//gameObject.FindChild ("InfoData").GetComponent<UILabel> ().text = "气血:90\n力量:90\n速度:90\n法术:90";
		UIEventListener.Get (gameObject.FindChild("Sprite")).onClick = OnClickForEquip;
	}
	
	void OnClickForEquip(GameObject go)
	{
		Debug.Log ("equip skill " + m_strCurrentCardId);
		//Application.LoadLevel ("Game");
		PageManager.Instance.ShowPage(UIHeroPage.Instance, PageManager.AnimationType.MiddleZoomIn);
	}

	public void SetCardId(string cardid)
	{
		m_strCurrentCardId = cardid;
		//展示卡片数据
		gameObject.FindChild("SkillInfo").GetComponent<UILabel>().text = "技能["+m_strCurrentCardId+"]";
	}

	private string m_strCurrentCardId;
}
