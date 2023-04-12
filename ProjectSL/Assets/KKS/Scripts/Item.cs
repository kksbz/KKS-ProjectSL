using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("아이템 정보")]
    public int itemID;
    public Sprite icon;
    [SerializeField] private ItemData itemData;

    void Start()
    {
        itemData = ItemManager.Instance.items[itemID - 1];
    }
}
