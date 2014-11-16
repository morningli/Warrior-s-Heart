using System.Collections.Generic;

public class BagDataMrg : Inventory
{
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
			soldier.introduction = "帅的一塌糊涂";

			AddBagItem(soldier);
		}
	}
}
