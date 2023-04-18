using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("아이템 정보")]
    [SerializeField] private int itemID; // 아이템 데이터 맵핑에 사용될 ID
    public ItemData itemData; // 아이템 데이터

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

    // 아이템 삭제 시 아이템 데이터도 삭제
    void OnDestroy()
    {
        itemData = null;
    } // OnDestroy
} // Item
