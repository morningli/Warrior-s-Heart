using System;
using System.Collections.Generic;

[Serializable]
public class BagData
{
	public string id;			//ID
	public string name;			//名字
	public string icon;			//图标,[0,27]对应"Logo"的"未标题-1_03-x"

	public int IconNumber
	{
		set
		{
			int num = value % 27 + 1;
			icon = "未标题-1_03-" + num.ToString().PadLeft(2,'0');; 
		}
	}
	public string introduction;	//简介
}

public enum SoldierType{
	enum_soldier_type_warrior = 1,
	enum_soldier_type_sorcerer,
	enum_soldier_type_archer,
}

[Serializable]
public class Soldier : BagData
{
	public SoldierType	type;  		//战士类型,[1,3]对应近、法、远

	public string TypeIcon
	{
		get
		{
			switch (type)
			{
			case SoldierType.enum_soldier_type_warrior: 	//近
				return "HOW_hero_jin";
			case SoldierType.enum_soldier_type_sorcerer:	//法
				return "HOW_hero_fa";
			case SoldierType.enum_soldier_type_archer:		//远
				return "HOW_hero_yuan";
			default:
				return "HOW_hero_jin";
			}
		}
	}
	public int	level;  	//战士等级
	public int	quality;	//战士品质，[1-5]对应"LogoBackGround"的"HOW_hero_avatarbgx"

	public string QualityIcon
	{
		get
		{
			return "HOW_hero_avatarbg" + quality.ToString();
		}
	}
	public int	strong;		//强壮
	public int	attack;		//力量
	public int 	celerity;	//敏捷
	public int 	power;		//法术

	//TODO 其他属性
	public bool  fighting;	//出战

	public string FightButtonString
	{
		get
		{
			return  fighting ? "休战" : "出战";
		}
	}

	static Random RandomHelper = new Random(unchecked((int)DateTime.Now.Ticks));

	public Soldier()
	{
		Random rd = new Random(unchecked((int)DateTime.Now.Ticks));

		type 		= (SoldierType)Soldier.RandomHelper.Next(1,5);
		level 		= Soldier.RandomHelper.Next(1,10);
		quality 	= Soldier.RandomHelper.Next(1,5);

		strong 		= 50 + Soldier.RandomHelper.Next(1,20);
		attack 		= 50 + Soldier.RandomHelper.Next(1,20);
		celerity 	= 50 + Soldier.RandomHelper.Next(1,20);
		power 		= 50 + Soldier.RandomHelper.Next(1,20);

		fighting 	= false;
	}
}

[Serializable]
public class Army
{
	public List<Soldier> soldiers = new List<Soldier>();

	public void Conscribe(ref Soldier soldier)
	{
		soldiers.Add(soldier);
	}

	public void Fire(ref Soldier soldier)
	{
		soldiers.Remove(soldier);
	}
}
