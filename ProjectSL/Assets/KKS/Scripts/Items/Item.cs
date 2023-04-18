using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("������ ����")]
    [SerializeField] private int itemID; // ������ ������ ���ο� ���� ID
    public ItemData itemData; // ������ ������

    void Awake()
    {
        foreach (string[] _itemData in DataManager.Instance.itemDatas)
        {
            if (_itemData[0] == itemID.ToString())
            {
                itemData = new ItemData(_itemData);
            }
        }
        //itemData = new ItemData(DataManager.Instance.itemDatas[itemID - 1]);
    } // Start

    // ������ ���� �� ������ �����͵� ����
    void OnDestroy()
    {
        itemData = null;
    } // OnDestroy
} // Item
