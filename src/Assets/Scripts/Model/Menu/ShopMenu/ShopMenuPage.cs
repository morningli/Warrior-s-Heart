using UnityEngine;
using System.Collections;

public class ShopMenuPage : BasePage {


	static ShopMenuPage m_instance;
	public static ShopMenuPage Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = ResourceManager.Load("Prefab/Menu/ShopMenuPage/ShopMenuPage").GetComponent<ShopMenuPage>();
			}
			return m_instance;
		}
	}
	
	
	void Awake()
	{
		UIEventListener.Get (gameObject.FindChild ("ShopBackground")).onClick = OnStartGameClick;
	}
	
	void OnStartGameClick(GameObject go)
	{
		Debug.Log ("134");
		//Application.LoadLevel ("Game");
	}
}
