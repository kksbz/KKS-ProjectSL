using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("������ ����")]
    public int itemID; // ������ ������ ���ο� ���� ID
    public ItemData itemData; // ������ ������

    void Awake()
    {
        itemData = DataManager.Instance.itemDatas[itemID - 1];
    } // Start
} // Item
