using UnityEngine;
using System.Collections;

public struct BagData
{
	public string ID;			//ID
	public string Name;			//名字
	public string Icon;			//图标
	public string Introduction;	//简介
}

public struct Soldier:BagData
{
	public int	type;  		//战士类型 
	public int	level;  	//战士类型
	public int	quality;	//战士品质

	public int	strong;		//强壮
	public int	attack;		//力量
	public int 	celerity;	//敏捷
	public int 	power;		//法术

	//TODO 其他属性

}