using UnityEngine;
using System.Collections;

public class UIHeroPage : BasePage {
	static UIHeroPage m_instance;
	public static UIHeroPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/HeroPage/HeroPage").GetComponent<UIHeroPage>();
			}
			return m_instance;
		}
	}

	HeroData m_data;

	void Awake()
	{
		PageWillAppear();
		//选择技能
		UIEventListener.Get (gameObject.FindChild("Select1")).onClick = OnClickForSelectSkill;
	}

	//展示页面
	public override void PageWillAppear()
	{
		Debug.Log("enter PageWillAppear");

		if (m_data == null)
		{
			m_data = new HeroData();
		}

		//获取英雄数据
		DataManager.Instance.GetConfigData("HeroPage", "HeroInfo", ref m_data);
		//展示英雄信息
		gameObject.FindChild ("InfoData").GetComponent<UILabel> ().text 
			= "气血:" + m_data.physical 
				+ "\n力量:" + m_data.strength 
				+ "\n速度:" + m_data.velocity 
				+ "\n法术:" + m_data.magic
				+ "\n技能:" + m_data.skill;
	}

	//点击数据更新
	void OnClickForSelectSkill(GameObject go)
	{
		Debug.Log ("select");

		/*m_data.physical += 1;
		m_data.strength += 1;
		m_data.velocity += 1;
		m_data.magic += 1;
		DataManager.Instance.SetConfigData("HeroPage", "HeroInfo", m_data);*/

		PageManager.Instance.ShowDialog(UISkillPage.Instance, PageManager.AnimationType.NULL);
	}
}
