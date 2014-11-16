using System;
using System.Collections.Generic;

using UnityEngine;

public enum DataType{
	EnumDataType_Soldier,	//战士数据

}

public enum DataSubType
{
	EnumSubDataType_All,	//表示所有子类型

	//战士专用
	EnumSubDataType_Soldier_Warrior,
	EnumSubDataType_Soldier_Sorcerer,
	EnumSubDataType_Soldier_Archer,
}

[Serializable]
public class BagData
{
	public string 	id;			//ID
	public string 	name;		//名字
	public string 	icon;		//图标,[0,27]对应"Logo"的"未标题-1_03-x"
	public DataType	type;  		//物品类型
	public DataSubType subType;	//物品子类型

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
	public Dictionary<DataType, Dictionary<DataSubType, List<string> > > bagItemClassify 
		= new Dictionary<DataType, Dictionary<DataSubType, List<string> > >();
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
			bagItemClassify[item.type] = new Dictionary<DataSubType, List<string> >();

		if (!bagItemClassify[item.type].ContainsKey(item.subType))
			bagItemClassify[item.type][item.subType] = new List<string>();

		if (!bagItemClassify[item.type].ContainsKey(DataSubType.EnumSubDataType_All))
			bagItemClassify[item.type][DataSubType.EnumSubDataType_All] = new List<string>();

		//子分类
		bagItemClassify[item.type][item.subType].Add(item.id);
		//主分类
		bagItemClassify[item.type][DataSubType.EnumSubDataType_All].Add(item.id);
	}

	public void RemoveBagItem(string id)
	{
		BagData item = FindBagItem(id);

		List<string> subTypeList = GetClassifyList(item.type, item.subType);
		if (subTypeList != null)
		{
			subTypeList.Remove(id);
		}

		List<string> allTypeList = GetClassifyList(item.type, DataSubType.EnumSubDataType_All);
		if (allTypeList != null)
		{
			allTypeList.Remove(id);
		}
	}

	public List<string> GetClassifyList(DataType type, DataSubType subType)
	{
		if (!bagItemClassify.ContainsKey(type))
			return null;	
		if (!bagItemClassify[type].ContainsKey(subType))
			return null;
		return bagItemClassify[type][subType];
	}
}

[Serializable]
public class Soldier : BagData
{
	public string TypeIcon
	{
		get
		{
			switch (subType)
			{
			case DataSubType.EnumSubDataType_Soldier_Warrior: 	//近
				return "HOW_hero_jin";
			case DataSubType.EnumSubDataType_Soldier_Sorcerer:	//法
				return "HOW_hero_fa";
			case DataSubType.EnumSubDataType_Soldier_Archer:	//远
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
			switch (subType)
			{
			case DataSubType.EnumSubDataType_Soldier_Warrior: 	//近
				return new Color(255/255f,113/255f,36/255f);
			case DataSubType.EnumSubDataType_Soldier_Sorcerer:	//法
					return new Color(61/255f,157/255f,239/255f);
			case DataSubType.EnumSubDataType_Soldier_Archer:		//远
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
		type		= DataType.EnumDataType_Soldier; 		
		subType 	= (DataSubType)Soldier.RandomHelper.Next(1,5);
		level 		= Soldier.RandomHelper.Next(1,10);
		quality 	= Soldier.RandomHelper.Next(1,5);

		strong 		= 50 + Soldier.RandomHelper.Next(1,20);
		attack 		= 50 + Soldier.RandomHelper.Next(1,20);
		celerity 	= 50 + Soldier.RandomHelper.Next(1,20);
		power 		= 50 + Soldier.RandomHelper.Next(1,20);

		fighting 	= false;
	}
}


