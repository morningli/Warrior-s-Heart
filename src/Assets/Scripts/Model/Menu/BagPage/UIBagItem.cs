using UnityEngine;
using System.Collections;

public class UIBagItem : MonoBehaviour {

	public static UIBagItem Instance
	{
		get
		{
			return ResourceManager.Load("Prefab/Menu/BagPage/BagItem").GetComponent<UIBagItem>();
		}
	}

	void Awake()
	{
		UIEventListener.Get (gameObject.FindChild("EquipButton")).onClick = OnClickForEuip;
	}

	void OnClickForEuip(GameObject button)
	{
		m_soldier.fighting = !m_soldier.fighting;
		
		ShowSoldier();
	}

	void ShowSoldier()
	{
		if (m_soldier != null)
		{
			gameObject.FindChild ("Name").GetComponent<UILabel> ().text = m_soldier.name;
			gameObject.FindChild ("Name").GetComponent<UILabel> ().color = m_soldier.TypeColor;

			gameObject.FindChild ("Level").GetComponent<UILabel> ().text = "+" + m_soldier.level.ToString();
			gameObject.FindChild ("Level").GetComponent<UILabel> ().color = m_soldier.TypeColor;

			gameObject.FindChild ("AttributeIcon").GetComponent<UISprite> ().spriteName = m_soldier.TypeIcon;
			gameObject.FindChild ("Logo").GetComponent<UISprite> ().spriteName = m_soldier.icon;
			gameObject.FindChild ("LogoBackGround").GetComponent<UISprite> ().spriteName = m_soldier.QualityIcon;
			
			gameObject.FindChild ("EquipButtonLabel").GetComponent<UILabel> ().text = m_soldier.FightButtonString;
		}
	}

	public string ObjectId
	{
		get{
			return m_soldier.id;
		}
		set{
			m_soldier = (Soldier)BagDataMrg.Instance.FindBagItem(value);
			ShowSoldier();

		}
	}

	public Soldier Soldier
	{
		get{
			return m_soldier;
		}
	}

	public bool CurrentFocus
	{
		get{
			return gameObject.GetComponent<UIToggle>().value;
		}
		set{
			gameObject.GetComponent<UIToggle>().value = value;
		}
	}

	Soldier m_soldier;
}
