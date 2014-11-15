using UnityEngine;
using System.Collections;

public class UIBagItem : MonoBehaviour {
	static int itemAdd = 1;
	public static UIBagItem Instance
	{
		get
		{
			UIBagItem item = ResourceManager.Load("Prefab/Menu/BagPage/BagItem").GetComponent<UIBagItem>();
			item.m_itemId = itemAdd++;
			return item;
		}
	}

	void Awake()
	{
		gameObject.GetComponent<UIToggle>().group = m_itemGroup;

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
			gameObject.FindChild ("Level").GetComponent<UILabel> ().text = m_soldier.level.ToString();
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
			m_soldier = BagDataMrg.Instance.FindSoldier(value);
			ShowSoldier();

		}
	}

	public Soldier Soldier
	{
		get{
			return m_soldier;
		}
	}

	public int ItemId
	{
		get{
			return m_itemId;
		}
	}

	public int ItemGroup
	{
		get{
			return m_itemGroup - 100;
		}
		set{
			m_itemGroup = value + 100;
			gameObject.GetComponent<UIToggle>().group = m_itemGroup;
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

	int m_itemId;
	int m_itemGroup = 100;
	Soldier m_soldier;
}
