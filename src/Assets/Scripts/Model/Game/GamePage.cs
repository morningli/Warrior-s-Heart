using UnityEngine;
using System.Collections;

public class GamePage : BasePage 
{
    static GamePage m_instance;
    public static GamePage Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = ResourceManager.Load("Prefab/Game/GamePage").GetComponent<GamePage>();
            }
            return m_instance;
        }
    }
}
