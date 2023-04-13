using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("������ ����")]
    public int itemID; // ������ ������ ���ο� ���� ID
    public Sprite icon; // ������ ������
    [SerializeField] private ItemData itemData;

    void Start()
    {
        itemData = Inventory.Instance.items[itemID - 1];
    } // Start
} // Item
