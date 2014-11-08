using UnityEngine;
using System.Collections;

public class CardInList : MonoBehaviour {
	public static CardInList Instance
	{
		get
		{
			return ResourceManager.Load("Prefab/Menu/HeroPage/CardInList").GetComponent<CardInList>();
		}
	}
	
	void Awake()
	{
		//UIEventListener.Get (gameObject.FindChild ("startGameButton")).onClick = OnStartGameClick;
		//gameObject.FindChild ("InfoData").GetComponent<UILabel> ().text = "气血:90\n力量:90\n速度:90\n法术:90";
		//UIEventListener.Get (gameObject.FindChild("Object/Select1")).onClick = OnClickForSelectSkill;
	}

	public void SetCardName(string name)
	{
		gameObject.FindChild ("CardName").GetComponent<UILabel>().text = name;
	}

	public void SetCardDecs(string desc)
	{
		gameObject.FindChild ("CardDesc").GetComponent<UILabel>().text = desc;
	}

	public void SetCardId(string cardid)
	{
		m_strCardId = cardid;
	}

	public string GetCardId()
	{
		return m_strCardId;
	}

	private string m_strCardId;
}
