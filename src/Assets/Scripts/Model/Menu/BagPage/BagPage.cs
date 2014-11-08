using UnityEngine;
using System.Collections;

public class BagPage : BasePage {
	static BagPage m_instance;
	public static BagPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/BagPage/BagPage").GetComponent<BagPage>();
			}
			return m_instance;
		}
	}

	ArrayList m_ItemList = new ArrayList();

	void Awake()
	{
		for (int i = 0; i < 19; ++i)
		{
			BagItem item = BagItem.Instance;
			item.SetObjectId(i.ToString());

			gameObject.FindChild("Grid").AddChild(item.gameObject);

			m_ItemList.Add(item);
		}

		for (int i = 0; i < 3; ++i)
		{
			SortedLabel label = SortedLabel.Instance;
			label.SetLabelId(i.ToString());
			if (i == 0)
			{
				label.GetComponent<UIToggle> ().startsActive = true;
			}
			gameObject.FindChild("LabelList").AddChild(label.gameObject);

			UIEventListener.Get(label.gameObject).onClick = OnClickForBagLabel;
		}

		//gameObject.FindChild("BagList").GetComponent<UIScrollView>().ResetPosition();
	}
	
	void OnClickForBagLabel(GameObject bagLabel)
	{
		SortedLabel label = bagLabel.GetComponent<SortedLabel>();
		int iId = int.Parse(label.GetLabelId());

		for (int i = 0; i < m_ItemList.Count; ++i)
		{
			BagItem item = m_ItemList[i] as BagItem;
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
	}
}
