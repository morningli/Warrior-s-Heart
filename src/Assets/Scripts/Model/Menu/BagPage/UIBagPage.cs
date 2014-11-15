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

	Dictionary<int, UIBagItem> m_ItemHash = new Dictionary<int, UIBagItem>();

	List<int> m_itemListAll = new List<int>();
	List<int> m_itemListWarrior = new List<int>();
	List<int> m_itemListSorcerer = new List<int>();
	List<int> m_itemListArcher = new List<int>();

	UIBagItem current_choose_item;
	UIBagItem next_possible_item;
	ItemListType current_choose_item_list;

	enum ItemListType
	{
		ItemListTypeAll,
		ItemListTypeWarrior,
		ItemListTypeSorcerer,
		ItemListTypeArcher,
	};

	ItemListType ItemListActive
	{
		get{
			return current_choose_item_list;
		}
		set{
			current_choose_item_list = value;

			switch (current_choose_item_list)
			{
			case ItemListType.ItemListTypeWarrior:
				{
					gameObject.FindChild("GridAll").SetActive(false);
					gameObject.FindChild("GridWarrior").SetActive(true);
					gameObject.FindChild("GridSorcerer").SetActive(false);
					gameObject.FindChild("GridArcher").SetActive(false);

					int itemId = m_itemListWarrior.Count > 0 ? m_itemListWarrior[0] : -1;
					if (m_ItemHash.ContainsKey(itemId))
					{
						SetCurrentItem(m_ItemHash[itemId]);
					}
				}
				break;
			case ItemListType.ItemListTypeSorcerer:
				{
					gameObject.FindChild("GridAll").SetActive(false);
					gameObject.FindChild("GridWarrior").SetActive(false);
					gameObject.FindChild("GridSorcerer").SetActive(true);
					gameObject.FindChild("GridArcher").SetActive(false);

					int itemId = m_itemListSorcerer.Count > 0 ? m_itemListSorcerer[0] : -1;
					if (m_ItemHash.ContainsKey(itemId))
					{
						SetCurrentItem(m_ItemHash[itemId]);
					}
				}
				break;
			case ItemListType.ItemListTypeArcher:
				{
					gameObject.FindChild("GridAll").SetActive(false);
					gameObject.FindChild("GridWarrior").SetActive(false);
					gameObject.FindChild("GridSorcerer").SetActive(false);
					gameObject.FindChild("GridArcher").SetActive(true);

					int itemId = m_itemListArcher.Count > 0 ? m_itemListArcher[0] : -1;
					if (m_ItemHash.ContainsKey(itemId))
					{
						SetCurrentItem(m_ItemHash[itemId]);
					}
				}
				break;
			case ItemListType.ItemListTypeAll:
				{
					gameObject.FindChild("GridAll").SetActive(true);
					gameObject.FindChild("GridWarrior").SetActive(false);
					gameObject.FindChild("GridSorcerer").SetActive(false);
					gameObject.FindChild("GridArcher").SetActive(false);
					
					int itemId = m_itemListAll.Count > 0 ? m_itemListAll[0] : -1;
					if (m_ItemHash.ContainsKey(itemId))
					{
						SetCurrentItem(m_ItemHash[itemId]);
					}
				}
				break;
			default:break;
			}
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
		gameObject.FindChild("DetailAttributeIcon").GetComponent<UISprite>().spriteName = soldier.TypeIcon;
		gameObject.FindChild("DetailLevel").GetComponent<UILabel>().text = soldier.level.ToString();
		
		gameObject.FindChild("DetailBrief").GetComponent<UILabel>().text = soldier.introduction;
		
		gameObject.FindChild ("DetailAttribute1").GetComponent<UILabel> ().text = 
			"强壮 ： " + soldier.strong + "\n"
				+ "力量 ： " + soldier.attack + "\n"
				+ "敏捷 ： " + soldier.celerity + "\n"
				+ "法术 ： " +soldier.power + "\n"; 

		//设置下一个元素
		switch (ItemListActive)
		{	
		case ItemListType.ItemListTypeWarrior:
			next_possible_item = m_ItemHash[m_itemListWarrior[GetNextItemInList(m_itemListWarrior, current_choose_item.ItemId)]];
			break;
		case ItemListType.ItemListTypeSorcerer:
			next_possible_item = m_ItemHash[m_itemListSorcerer[GetNextItemInList(m_itemListSorcerer, current_choose_item.ItemId)]];
			break;
		case ItemListType.ItemListTypeArcher:
			next_possible_item = m_ItemHash[m_itemListArcher[GetNextItemInList(m_itemListArcher, current_choose_item.ItemId)]];
			break;
		case ItemListType.ItemListTypeAll:
			next_possible_item = m_ItemHash[m_itemListAll[GetNextItemInList(m_itemListAll, current_choose_item.ItemId)]];
			break;
		default:break;
		}
	}

	void SetItemListAll()
	{
		foreach (string id in BagDataMrg.Instance.soldier_all)
		{
			UIBagItem item = UIBagItem.Instance;

			//设置item
			item.ObjectId = id;
			item.ItemGroup = (int)ItemListType.ItemListTypeAll;
			gameObject.FindChild("GridAll").AddChild(item.gameObject);
			UIEventListener.Get(item.gameObject).onClick = OnClickForItem;

			m_ItemHash.Add(item.ItemId, item);
			m_itemListAll.Add(item.ItemId);
		}
	}
	void SetItemListWarrior()
	{
		foreach (string id in BagDataMrg.Instance.soldier_warrior)
		{
			UIBagItem item = UIBagItem.Instance;
			
			//设置item
			item.ObjectId = id;
			item.ItemGroup = (int)ItemListType.ItemListTypeWarrior;
			gameObject.FindChild("GridWarrior").AddChild(item.gameObject);
			UIEventListener.Get(item.gameObject).onClick = OnClickForItem;
			
			m_ItemHash.Add(item.ItemId, item);
			m_itemListWarrior.Add(item.ItemId);
		}
	}
	void SetItemListSorcerer()
	{
		foreach (string id in BagDataMrg.Instance.soldier_sorcerer)
		{
			UIBagItem item = UIBagItem.Instance;
			
			//设置item
			item.ObjectId = id;
			item.ItemGroup = (int)ItemListType.ItemListTypeSorcerer;
			gameObject.FindChild("GridSorcerer").AddChild(item.gameObject);
			UIEventListener.Get(item.gameObject).onClick = OnClickForItem;
			
			m_ItemHash.Add(item.ItemId, item);
			m_itemListSorcerer.Add(item.ItemId);
		}
	}
	void SetItemListArcher()
	{
		foreach (string id in BagDataMrg.Instance.soldier_archer)
		{
			UIBagItem item = UIBagItem.Instance;
			
			//设置item
			item.ObjectId = id;
			item.ItemGroup = (int)ItemListType.ItemListTypeArcher;
			gameObject.FindChild("GridArcher").AddChild(item.gameObject);
			UIEventListener.Get(item.gameObject).onClick = OnClickForItem;
			
			m_ItemHash.Add(item.ItemId, item);
			m_itemListArcher.Add(item.ItemId);
		}
	}

	void Awake()
	{
		SetItemListAll();
		SetItemListWarrior();
		SetItemListSorcerer();
		SetItemListArcher();

		ItemListActive = ItemListType.ItemListTypeAll;



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
		BagDataMrg.Instance.FireSoldier(current_choose_item.ObjectId);

		//隐藏当前item
		if (current_choose_item != null)
			current_choose_item.gameObject.SetActive(false);

		//高亮下一个item
		if(next_possible_item != null)
		{
			SetCurrentItem(next_possible_item);
		}

		//刷新界面
		switch (ItemListActive)
		{	
		case ItemListType.ItemListTypeWarrior:
			gameObject.FindChild("GridWarrior").GetComponent<UIGrid> ().Reposition();
			break;
		case ItemListType.ItemListTypeSorcerer:
			gameObject.FindChild("GridSorcerer").GetComponent<UIGrid> ().Reposition();
			break;
		case ItemListType.ItemListTypeArcher:
			gameObject.FindChild("GridArcher").GetComponent<UIGrid> ().Reposition();
			break;
		case ItemListType.ItemListTypeAll:
			gameObject.FindChild("GridAll").GetComponent<UIGrid> ().Reposition();
			break;
		default:break;
		}
	}

	void OnClickForLabelAll(GameObject bagLabel)
	{
		ItemListActive = ItemListType.ItemListTypeAll;
	}

	void OnClickForLabelWarrior(GameObject bagLabel)
	{
		ItemListActive = ItemListType.ItemListTypeWarrior;
	}

	void OnClickForLabeSorcerer(GameObject bagLabel)
	{
		ItemListActive = ItemListType.ItemListTypeSorcerer;
	}

	void OnClickForLabelArcher(GameObject bagLabel)
	{
		ItemListActive = ItemListType.ItemListTypeArcher;
	}
}
