using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleField : MonoBehaviour 
{
    static BattleField m_instance;
    public static BattleField Instance
    {
        get
        {
            return m_instance;
        }
    }
    List<Warrior> m_AttackerList;
    List<Warrior> m_DefenderList;


    void Awake()
    {
        m_instance = this;
    }
    public void StartBattle()
    {
        foreach (Warrior warrior in m_AttackerList)
        {
            warrior.WillStartBattle();
        }
        foreach (Warrior warrior in m_DefenderList)
        {
            warrior.WillStartBattle();
        }
        /////////////////////////



        /////////////////////////
        foreach (Warrior warrior in m_AttackerList)
        {
            warrior.DidStartBattle();
        }
        foreach (Warrior warrior in m_DefenderList)
        {
            warrior.DidStartBattle();
        }
    }
    void Update()
    {

    }
}
