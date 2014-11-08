using UnityEngine;
using System.Collections;

public class BagItem : MonoBehaviour {
	public static BagItem Instance
	{
		get
		{
			return ResourceManager.Load("Prefab/Menu/BagPage/BagItem").GetComponent<BagItem>();
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

	public void SetObjectId(string id)
	{
		m_strObjectId = id;
		gameObject.FindChild ("ObjectInfo").GetComponent<UILabel> ().text = "Object" + id;
	}

	public string GetObjectId()
	{
		return m_strObjectId;
	}

	string m_strObjectId;
}
