using System;
using System.Collections.Generic;

using UnityEngine;

public enum DataType{
	EnumDataType_Soldier_All,	//不表示实际类型
	EnumDataType_Soldier_Warrior,
	EnumDataType_Soldier_Sorcerer,
	EnumDataType_Soldier_Archer,
}

[Serializable]
public class BagData
{
	public string 	id;			//ID
	public string 	name;		//名字
	public string 	icon;		//图标,[0,27]对应"Logo"的"未标题-1_03-x"
	public DataType	type;  		//物品类型,[1,3]对应近、法、远

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

[Serializable]
public class Inventory
{
	[NonSerialized]
	public Dictionary<DataType, List<string> > bagItemClassify = new Dictionary<DataType, List<string> >();
	public List<BagData> bagItemList = new List<BagData>();

	public BagData FindBagItem(string id)
	{
		foreach (BagData item in bagItemList)
		{
			if (item.id == id)
			{
				return item;
			}
		}
		return null;
	}

	public void AddBagItem(BagData item)
	{
		bagItemList.Add(item);

		if (!bagItemClassify.ContainsKey(item.type))
			bagItemClassify[item.type] = new List<string>();
		bagItemClassify[item.type].Add(item.id);

		if (!bagItemClassify.ContainsKey(DataType.EnumDataType_Soldier_All))
			bagItemClassify[DataType.EnumDataType_Soldier_All] = new List<string>();
		bagItemClassify[DataType.EnumDataType_Soldier_All].Add(item.id);
	}

	public void RemoveBagItem(string id)
	{
		bagItemClassify[FindBagItem(id).type].Remove(id);
		bagItemClassify[DataType.EnumDataType_Soldier_All].Remove(id);
	}
}

[Serializable]
public class Soldier : BagData
{
	public string TypeIcon
	{
		get
		{
			switch (type)
			{
			case DataType.EnumDataType_Soldier_Warrior: 	//近
				return "HOW_hero_jin";
			case DataType.EnumDataType_Soldier_Sorcerer:	//法
				return "HOW_hero_fa";
			case DataType.EnumDataType_Soldier_Archer:		//远
				return "HOW_hero_yuan";
			default:
				return "HOW_hero_jin";
			}
		}
	}

	public Color TypeColor
	{
		get
		{
			switch (type)
			{
			case DataType.EnumDataType_Soldier_Warrior: 	//近
				return new Color(255/255f,113/255f,36/255f);
			case DataType.EnumDataType_Soldier_Sorcerer:	//法
					return new Color(61/255f,157/255f,239/255f);
			case DataType.EnumDataType_Soldier_Archer:		//远
				return new Color(9/255f,160/255f,84/255f);
			default:
				return new Color(255/255f,113/255f,36/255f);
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

	static System.Random RandomHelper = new System.Random(unchecked((int)DateTime.Now.Ticks));

	public Soldier()
	{
		type 		= (DataType)Soldier.RandomHelper.Next(1,5);
		level 		= Soldier.RandomHelper.Next(1,10);
		quality 	= Soldier.RandomHelper.Next(1,5);

		strong 		= 50 + Soldier.RandomHelper.Next(1,20);
		attack 		= 50 + Soldier.RandomHelper.Next(1,20);
		celerity 	= 50 + Soldier.RandomHelper.Next(1,20);
		power 		= 50 + Soldier.RandomHelper.Next(1,20);

		fighting 	= false;
	}
}


