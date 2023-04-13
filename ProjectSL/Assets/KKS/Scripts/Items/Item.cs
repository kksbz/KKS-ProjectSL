using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("������ ����")]
    public int itemID; // ������ ������ ���ο� ���� ID
    public Sprite icon; // ������ ������
    public ItemData itemData; // ������ ������

    void Awake()
    {
        itemData = Inventory.Instance.itemDatas[itemID - 1];
    } // Start
} // Item
