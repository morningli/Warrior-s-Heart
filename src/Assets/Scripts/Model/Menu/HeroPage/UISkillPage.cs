using UnityEngine;
using System.Collections;

public class UISkillPage : BasePage {
	static UISkillPage m_instance;
	public static UISkillPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/HeroPage/SkillPage").GetComponent<UISkillPage>();
			}
			return m_instance;
		}
	}
	
	//private ArrayList m_listSkillAvailable;

	void Awake()
	{
		//UIEventListener.Get (gameObject.FindChild ("startGameButton")).onClick = OnStartGameClick;
		//gameObject.FindChild ("InfoData").GetComponent<UILabel> ().text = "气血:90\n力量:90\n速度:90\n法术:90";
		//UIEventListener.Get (gameObject.FindChild("Object/Select1")).onClick = OnClickForSelectSkill;

		for (int i = 0; i < 10; i++) 
		{
			UICardInList card = UICardInList.Instance;

			card.SetCardName("五谷丰登(" + i + ")");
			card.SetCardDecs("增加全体战士士气，全体攻击+10%");
			card.SetCardId(i.ToString());

			gameObject.FindChild("UIGrid").AddChild(card.gameObject);
			UIEventListener.Get(card.gameObject).onClick = OnClickForSkillCard;

			//m_listSkillAvailable.Add(card);
		}
	}

	void OnClickForSkillCard(GameObject go)
	{
		UICardInList card = go.GetComponent<UICardInList>();
		//Debug.Log(card.GetCardId());
		UISkillDetail skillPage = UISkillDetail.Instance;
		skillPage.SetCardId(card.GetCardId());

		PageManager.Instance.HideDialog();
		PageManager.Instance.ShowPage(skillPage, PageManager.AnimationType.NULL);
	}
}
