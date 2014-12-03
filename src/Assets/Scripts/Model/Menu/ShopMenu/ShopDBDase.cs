using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum ENUM_ItemType
{
	Comm_Item,
};

enum ENUM_ItemState
{
	COMM_STATE,	  //普通类型
	SOLDED_STATE, //卖完
};

public struct ShopItem
{	
	public string strItemShopID;//商品id
	public string strItemName; 
	public int iItemType;  //定义物品类型 参考ItemType
	public int iGoldPrice;
	public int iDiamondPices;
	public int iItemState; //物品状态 参考
	public int iItemNum;
}

public class ShopDBbase  {

	List<ShopItem> m_listShopItem;
	int m_iMoney;
	int m_GoldPrice;
}
