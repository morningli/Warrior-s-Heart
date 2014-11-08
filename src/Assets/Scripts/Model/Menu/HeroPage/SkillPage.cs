using UnityEngine;
using System.Collections;

public class SkillPage : BasePage {
	static SkillPage m_instance;
	public static SkillPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/HeroPage/SkillPage").GetComponent<SkillPage>();
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
			CardInList card = CardInList.Instance;

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
		CardInList card = go.GetComponent<CardInList>();
		//Debug.Log(card.GetCardId());
		SkillDetail skillPage = SkillDetail.Instance;
		skillPage.SetCardId(card.GetCardId());
		PageManager.Instance.ShowPage(skillPage);
	}
}
