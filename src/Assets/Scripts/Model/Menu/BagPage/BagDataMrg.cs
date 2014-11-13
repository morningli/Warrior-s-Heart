using System.Collections.Generic;

public class BagDataMrg{
	static BagDataMrg m_instance;
	public static BagDataMrg Instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = new BagDataMrg();
			}
			return m_instance;
		}
	}

	public BagDataMrg()
	{
		for (int i = 0; i < 40; i++)
		{
			Soldier soldier = new Soldier();
			soldier.id = i.ToString();
			soldier.name = "战士 ["+i.ToString()+"]";
			soldier.IconNumber = i;

			switch (soldier.type)
			{
			case SoldierType.enum_soldier_type_warrior: 	//近
				soldier_warrior.Add(soldier.id);
				break;
			case SoldierType.enum_soldier_type_sorcerer:	//法
				soldier_sorcerer.Add(soldier.id);
				break;
			case SoldierType.enum_soldier_type_archer:		//远
				soldier_archer.Add(soldier.id);
				break;
			}
			soldier_all.Add(soldier.id);

			army.Conscribe(ref soldier);
		}
	}

	public Soldier FindSoldier(string soldierId)
	{
		foreach (Soldier soldier in army.soldiers)
		{
			if (soldier.id == soldierId)
			{
				return soldier;
			}
		}
		return null;
	}

	public List<string> soldier_all = new List<string>();
	public List<string> soldier_warrior = new List<string>();
	public List<string> soldier_sorcerer = new List<string>();
	public List<string> soldier_archer = new List<string>();

	public Army army = new Army();
}
