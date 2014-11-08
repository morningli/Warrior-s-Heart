using UnityEngine;
using System.Collections;

public class UISortedLabel : MonoBehaviour {
	public static UISortedLabel Instance
	{
		get
		{
			return ResourceManager.Load("Prefab/Menu/BagPage/SortedLabel").GetComponent<UISortedLabel>();
		}
	}
	
	
	void Awake()
	{
		//UIEventListener.Get (gameObject.FindChild ("startGameButton")).onClick = OnStartGameClick;
		//gameObject.FindChild ("ObjectInfo").GetComponent<UILabel> ().text = "气血:90\n力量:90\n速度:90\n法术:90";
		//UIEventListener.Get (gameObject.FindChild("Select1")).onClick = OnClickForSelectSkill;
	}
	
	void OnClickForSelectSkill(GameObject go)
	{
		Debug.Log ("select");
		//Application.LoadLevel ("Game");
		//PageManager.Instance.ShowPage(SkillPage.Instance);
	}
	
	public void SetLabelId(string id)
	{
		m_strLabelId = id;
		gameObject.FindChild ("LabelName").GetComponent<UILabel> ().text = "Label" + id;
	}

	public string GetLabelId()
	{
		return m_strLabelId;
	}

	string m_strLabelId;
}
