using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public int itemID; // ������ȣ
    public string itemName; // �̸�
    public string itemType; // Ÿ��
    public int itemValue; // ���� (������ or ȸ����)
    public int buyPrice; // ���Ű���
    public int sellPrice; // �ǸŰ���
    public int quantity; // �ִ� ����
    public string description; // ����

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
