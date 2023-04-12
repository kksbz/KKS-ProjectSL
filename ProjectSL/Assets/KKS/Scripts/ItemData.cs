using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public int itemID; // 고유번호
    public string itemName; // 이름
    public string itemType; // 타입
    public int itemValue; // 벨류 (데미지 or 회복량)
    public int buyPrice; // 구매가격
    public int sellPrice; // 판매가격
    public int quantity; // 최대 수량
    public string description; // 설명

    public ItemData(string[] data)
    {
        itemID = int.Parse(data[0]);
        itemName = data[1];
        itemType = data[2];
        itemValue = int.Parse(data[3]);
        buyPrice = int.Parse(data[4]);
        sellPrice = int.Parse(data[5]);
        quantity = int.Parse(data[6]);
        description = data[7];
    } // ItemData
} // ItemData
