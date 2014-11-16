using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIBagPage : BasePage {
	static UIBagPage m_instance;
	public static UIBagPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/BagPage/BagPage").GetComponent<UIBagPage>();
			}
			return m_instance;
		}
	}

	Dictionary<string, UIBagItem> m_ItemHash = new Dictionary<string, UIBagItem>();

	UIBagItem current_choose_item;
	UIBagItem next_possible_item;

	DataType	current_choose_type = DataType.EnumDataType_Soldier;
	DataSubType current_choose_item_list;

	DataSubType ItemListActive
	{
		get{
			return current_choose_item_list;
		}
		set{
			current_choose_item_list = value;

			current_choose_item = null;
			next_possible_item = null;

			foreach (UIBagItem item in m_ItemHash.Values)
			{
				List<string> dataList = BagDataMrg.Instance.GetClassifyList(current_choose_type, current_choose_item_list);
				if (dataList != null)
				{
					if (dataList.Contains(item.ObjectId))
					{
						gameObject.FindChild("BagList").AddChild(item.gameObject);

						if (current_choose_item == null)
						{
							current_choose_item = item;
						}
						else if (next_possible_item = null)
						{
							next_possible_item = item;
						}
					
					}
					else
					{
						gameObject.FindChild("BufferList").AddChild(item.gameObject);
					}
				}
			}

			//刷新界面
			gameObject.FindChild("BagList").GetComponent<UIGrid> ().Reposition();
			gameObject.FindChild("BagList").GetComponent<UIScrollView> ().ResetPosition();

			SetCurrentItem(current_choose_item);
		}
	}

	int GetNextItemInList<T>(List<T> list, T cur)
	{
		int index = list.IndexOf(cur);
		if (index < 0)
		{
			if (list.Count > 0)
			{
				return 0;
			}
		}
		else if (index == 0)
		{
			if (list.Count > 2)
			{
				return 1;
			}
		}
		else
		{
			return index - 1;
		}
		return -1;
	}

	void SetCurrentItem(UIBagItem cur_item)
	{
		if (cur_item == null)
			return;
		
		cur_item.CurrentFocus = true;

		//设置当前item
		current_choose_item = cur_item;

		//设置详情页
		Soldier soldier = current_choose_item.Soldier;
		
		gameObject.FindChild("DetailLogo").GetComponent<UISprite>().spriteName = "HOW_npc1";
		gameObject.FindChild("DetailName").GetComponent<UILabel>().text = soldier.name;
		gameObject.FindChild("DetailName").GetComponent<UILabel> ().color = soldier.TypeColor;

		gameObject.FindChild("DetailAttributeIcon").GetComponent<UISprite>().spriteName = soldier.TypeIcon;
		gameObject.FindChild("DetailLevel").GetComponent<UILabel>().text = "+" + soldier.level.ToString();
		gameObject.FindChild("DetailLevel").GetComponent<UILabel> ().color = soldier.TypeColor;
		
		gameObject.FindChild("DetailBrief").GetComponent<UILabel>().text = soldier.introduction;
		
		gameObject.FindChild ("DetailAttribute1").GetComponent<UILabel> ().text = 
			"强壮 ： " + soldier.strong + "\n"
				+ "力量 ： " + soldier.attack + "\n"
				+ "敏捷 ： " + soldier.celerity + "\n"
				+ "法术 ： " +soldier.power + "\n"; 

		//设置下一个元素
		List<string> dataList = BagDataMrg.Instance.GetClassifyList(current_choose_type, ItemListActive);
		next_possible_item = m_ItemHash[dataList[GetNextItemInList(dataList, current_choose_item.ObjectId)]];
	}

	void SetItemListAll()
	{
		List<string> dataList = BagDataMrg.Instance.GetClassifyList(current_choose_type, DataSubType.EnumSubDataType_All);
		if (dataList != null)
		{
			foreach (string id in dataList)
			{
				if (!m_ItemHash.ContainsKey(id))
				{
					UIBagItem item = UIBagItem.Instance;
					//设置item
					item.ObjectId = id;
					//gameObject.FindChild("BagList").AddChild(item.gameObject);
					UIEventListener.Get(item.gameObject).onClick = OnClickForItem;
					//保存item
					m_ItemHash.Add(item.ObjectId, item);
				}
			}
		}
	}

	void Awake()
	{
		SetItemListAll();

		ItemListActive = DataSubType.EnumSubDataType_All;

		UIEventListener.Get (gameObject.FindChild("LabelAll")).onClick = OnClickForLabelAll;
		UIEventListener.Get (gameObject.FindChild("LabelWarrior")).onClick = OnClickForLabelWarrior;
		UIEventListener.Get (gameObject.FindChild("LabeSorcerer")).onClick = OnClickForLabeSorcerer;
		UIEventListener.Get (gameObject.FindChild("LabelArcher")).onClick = OnClickForLabelArcher;

		UIEventListener.Get (gameObject.FindChild("Fire")).onClick = OnClickForButtonFire;
	}

	void OnClickForItem(GameObject bagItem)
	{
		SetCurrentItem(bagItem.GetComponent<UIBagItem>());
	}

	void OnClickForButtonFire(GameObject bagItem)
	{
		BagDataMrg.Instance.RemoveBagItem(current_choose_item.ObjectId);

		//隐藏当前item
		if (current_choose_item != null)
			current_choose_item.gameObject.SetActive(false);

		//高亮下一个item
		if(next_possible_item != null)
		{
			SetCurrentItem(next_possible_item);
		}

		//刷新界面
		gameObject.FindChild("BagList").GetComponent<UIGrid> ().Reposition();
	}

	void OnClickForLabelAll(GameObject bagLabel)
	{
		ItemListActive = DataSubType.EnumSubDataType_All;
	}

	void OnClickForLabelWarrior(GameObject bagLabel)
	{
		ItemListActive = DataSubType.EnumSubDataType_Soldier_Warrior;
	}

	void OnClickForLabeSorcerer(GameObject bagLabel)
	{
		ItemListActive = DataSubType.EnumSubDataType_Soldier_Sorcerer;
	}

	void OnClickForLabelArcher(GameObject bagLabel)
	{
		ItemListActive = DataSubType.EnumSubDataType_Soldier_Archer;
	}
}
