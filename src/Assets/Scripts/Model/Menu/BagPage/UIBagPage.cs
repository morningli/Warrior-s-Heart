﻿using UnityEngine;
using System.Collections;

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

	ArrayList m_ItemList = new ArrayList();

	void Awake()
	{
		for (int i = 0; i < 19; ++i)
		{
			UIBagItem item = UIBagItem.Instance;
			item.SetObjectId(i.ToString());

			gameObject.FindChild("Grid").AddChild(item.gameObject);

			m_ItemList.Add(item);
		}
		/*
		for (int i = 0; i < 3; ++i)
		{
			UISortedLabel label = UISortedLabel.Instance;
			label.SetLabelId(i.ToString());
			if (i == 0)
			{
				label.GetComponent<UIToggle> ().startsActive = true;
			}
			gameObject.FindChild("LabelList").AddChild(label.gameObject);

			UIEventListener.Get(label.gameObject).onClick = OnClickForBagLabel;
		}*/


		//gameObject.FindChild("BagList").GetComponent<UIScrollView>().ResetPosition();

		UIEventListener.Get (gameObject.FindChild("LabelAll")).onClick = OnClickForLabelAll;
		UIEventListener.Get (gameObject.FindChild("LabelWarrior")).onClick = OnClickForLabelWarrior;
		UIEventListener.Get (gameObject.FindChild("LabeSorcerer")).onClick = OnClickForLabeSorcerer;
		UIEventListener.Get (gameObject.FindChild("LabelArcher")).onClick = OnClickForLabelArcher;
	}

	void OnClickForLabelAll(GameObject bagLabel)
	{
		for (int i = 0; i < m_ItemList.Count; ++i)
		{
			UIBagItem item = m_ItemList[i] as UIBagItem;
			item.gameObject.SetActiveRecursively(true);
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();
	}

	void OnClickForLabelWarrior(GameObject bagLabel)
	{
		for (int i = 0; i < m_ItemList.Count; ++i)
		{
			UIBagItem item = m_ItemList[i] as UIBagItem;
			int iCur = int.Parse(item.GetObjectId());
			
			if (iCur % 2 != 0)
			{
				item.gameObject.SetActiveRecursively(false);
			}
			else
			{
				item.gameObject.SetActiveRecursively(true);
			}
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();
	}

	void OnClickForLabeSorcerer(GameObject bagLabel)
	{
		for (int i = 0; i < m_ItemList.Count; ++i)
		{
			UIBagItem item = m_ItemList[i] as UIBagItem;
			int iCur = int.Parse(item.GetObjectId());
			
			if (iCur % 3 != 0)
			{
				item.gameObject.SetActiveRecursively(false);
			}
			else
			{
				item.gameObject.SetActiveRecursively(true);
			}
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();
	}

	void OnClickForLabelArcher(GameObject bagLabel)
	{
		for (int i = 0; i < m_ItemList.Count; ++i)
		{
			UIBagItem item = m_ItemList[i] as UIBagItem;
			int iCur = int.Parse(item.GetObjectId());
			
			if (iCur % 4 != 0)
			{
				item.gameObject.SetActiveRecursively(false);
			}
			else
			{
				item.gameObject.SetActiveRecursively(true);
			}
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();
	}
	
	/*void OnClickForBagLabel(GameObject bagLabel)
	{
		UISortedLabel label = bagLabel.GetComponent<UISortedLabel>();
		int iId = int.Parse(label.GetLabelId());

		for (int i = 0; i < m_ItemList.Count; ++i)
		{
			UIBagItem item = m_ItemList[i] as UIBagItem;
			int iCur = int.Parse(item.GetObjectId());

			if (iCur % (iId + 1) != 0)
			{
				item.gameObject.SetActiveRecursively(false);
			}
			else
			{
				item.gameObject.SetActiveRecursively(true);
			}
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();

		Debug.Log ("select " + label.GetLabelId());
	}*/
}
