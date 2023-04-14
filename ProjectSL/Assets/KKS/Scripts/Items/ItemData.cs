using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[Serializable]
public class ItemData
{
    public enum ItemType
    {
        NONE,
        CONSUMPTION,
        WEAPON,
        HELMET,
        CHEST,
        GLOVES,
        PANTS,
        RING
    } // ItemType

    public int itemID; // 고유번호
    public string itemName; // 이름
    public ItemType itemType; // 타입
    public int itemValue; // 벨류 (데미지 or 회복량)
    public int buyPrice; // 구매가격
    public int sellPrice; // 판매가격
    public int quantity = 1; // 현재 수량
    public int maxQuantity; // 최대 수량
    public string description; // 설명
    public string itemIcon; // 이미지주소

    public ItemData(string[] data)
    {
        if (data == null)
        {
            return;
        }
        itemID = int.Parse(data[0]);
        itemName = data[1];
        itemType = (ItemType)Enum.Parse(typeof(ItemType), data[2]);
        itemValue = int.Parse(data[3]);
        buyPrice = int.Parse(data[4]);
        sellPrice = int.Parse(data[5]);
        maxQuantity = int.Parse(data[6]);
        description = data[7];
        itemIcon = data[8];
    } // ItemData
} // ItemData
