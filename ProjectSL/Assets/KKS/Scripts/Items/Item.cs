using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("아이템 정보")]
    public int itemID; // 아이템 데이터 맵핑에 사용될 ID
    public Sprite icon; // 아이템 아이콘
    [SerializeField] private ItemData itemData;

    void Start()
    {
        itemData = Inventory.Instance.items[itemID - 1];
    } // Start
} // Item
