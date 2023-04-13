using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public GameObject slotPrefab; // 슬롯 프리팹
    public GameObject invenPanel; // 인벤토리 패널
    public ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    public GameObject selectPanel; // 선택창 패널

    public List<WeaponSlot> weaponSlotList;
    public List<ArmorSlot> armorSlotList;
    public List<ConsumptionSlot> consumptionSlotList;

    public List<ItemData> itemDatas = new List<ItemData>();
    public List<Item> inventory = new List<Item>();
    private int invenCount = 28;

    public override void InitManager()
    {
        StartCoroutine(GoogleSheetManager.InitData());

    } // InitManager

    private void Start()
    {
        InitSlot();
    } // Start

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Item hp = new Item();
            hp.icon = Resources.Load("Prefabs/Crystal_icon") as Sprite;
            hp.itemID = 1;
            hp.itemData = itemDatas[0];
            Item mp = new Item();
            mp.icon = Resources.Load("Prefabs/Crystal_icon") as Sprite;
            mp.itemID = 1;
            mp.itemData = itemDatas[1];
            Debug.Log($"{hp.itemData.itemName}, {mp.itemData.itemName}");
            weaponSlotList[0].AddItem(hp);
            weaponSlotList[2].AddItem(mp);
            Debug.Log($"{weaponSlotList[0].Item.itemData.itemName}, {weaponSlotList[2].Item.itemData.itemName}");
            Debug.Log(weaponSlotList[0].Item);
        }
    } // Update

    private void InitSlot()
    {
        for (int i = 0; i < invenCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab);
            slot.transform.parent = invenPanel.transform.GetChild(0).transform;
            inventory.Add(new Item());
        }
    }
    public void AddItem()
    {

    } // AddItem

    public void RemoveItem()
    {

    } // RemoveItem
} // Inventory
