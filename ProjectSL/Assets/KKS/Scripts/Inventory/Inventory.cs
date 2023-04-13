using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public GameObject slotPrefab; // 슬롯 프리팹
    public GameObject selectPanel; // 장비창 선택패널

    public List<GameObject> weaponSlotList;
    public List<GameObject> armorSlotList;
    public List<GameObject> consumptionSlotList;

    public List<ItemData> items = new List<ItemData>();

    public override void InitManager()
    {
        StartCoroutine(GoogleSheetManager.InitData());
    } // InitManager

    private void Start()
    {

    } // Start

    public void AddItem()
    {

    } // AddItem

    public void RemoveItem()
    {

    } // RemoveItem
} // Inventory
