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

	void Awake()
	{
		foreach (string id in BagDataMrg.Instance.soldier_all)
		{
			UIBagItem item = UIBagItem.Instance;
			item.SetObjectId(id);
			gameObject.FindChild("Grid").AddChild(item.gameObject);
			m_ItemHash.Add(id, item);
		}

		UIEventListener.Get (gameObject.FindChild("LabelAll")).onClick = OnClickForLabelAll;
		UIEventListener.Get (gameObject.FindChild("LabelWarrior")).onClick = OnClickForLabelWarrior;
		UIEventListener.Get (gameObject.FindChild("LabeSorcerer")).onClick = OnClickForLabeSorcerer;
		UIEventListener.Get (gameObject.FindChild("LabelArcher")).onClick = OnClickForLabelArcher;
	}

	void OnClickForLabelAll(GameObject bagLabel)
	{
		foreach (UIBagItem bagItem in m_ItemHash.Values)
		{
			bagItem.gameObject.SetActiveRecursively(false);
		}

		foreach (string id in BagDataMrg.Instance.soldier_all)
		{
			m_ItemHash[id].gameObject.SetActiveRecursively(true);
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();

		/*Vector3 vec = gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition;
		vec.y = 0;
		gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition = vec;*/
	}

	void OnClickForLabelWarrior(GameObject bagLabel)
	{
		foreach (UIBagItem bagItem in m_ItemHash.Values)
		{
			bagItem.gameObject.SetActiveRecursively(false);
		}
		
		foreach (string id in BagDataMrg.Instance.soldier_warrior)
		{
			m_ItemHash[id].gameObject.SetActiveRecursively(true);
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();

		/*Vector3 vec = gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition;
		vec.y = 0;
		gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition = vec;*/
	}

	void OnClickForLabeSorcerer(GameObject bagLabel)
	{
		foreach (UIBagItem bagItem in m_ItemHash.Values)
		{
			bagItem.gameObject.SetActiveRecursively(false);
		}
		
		foreach (string id in BagDataMrg.Instance.soldier_sorcerer)
		{
			m_ItemHash[id].gameObject.SetActiveRecursively(true);
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();

		/*Vector3 vec = gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition;
		vec.y = 0;
		gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition = vec;*/
	}

	void OnClickForLabelArcher(GameObject bagLabel)
	{
		foreach (UIBagItem bagItem in m_ItemHash.Values)
		{
			bagItem.gameObject.SetActiveRecursively(false);
		}
		
		foreach (string id in BagDataMrg.Instance.soldier_archer)
		{
			m_ItemHash[id].gameObject.SetActiveRecursively(true);
		}
		gameObject.FindChild("Grid").GetComponent<UIGrid> ().Reposition();

		/*Vector3 vec = gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition;
		vec.y = 0;
		gameObject.FindChild("BagList").GetComponent<Transform> ().localPosition = vec;*/
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
