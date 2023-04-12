using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("������ ����")]
    public int itemID;
    public Sprite icon;
    [SerializeField] private ItemData itemData;

    void Start()
    {
        itemData = ItemManager.Instance.items[itemID - 1];
    }
}
