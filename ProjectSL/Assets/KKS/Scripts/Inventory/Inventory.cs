using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : Singleton<Inventory>
{
    public GameObject slotPrefab; // 슬롯 프리팹
    public GameObject equipPanel; // 장비인벤 패널
    public GameObject invenPanel; // 인벤토리 패널
    public ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    public SelectPanel selectPanel; // 선택창 패널

    public List<WeaponSlot> weaponSlotList;
    public List<ArmorSlot> armorSlotList;
    public List<ConsumptionSlot> consumptionSlotList;

    public List<ItemData> inventory = new List<ItemData>(); // 인벤토리
    public List<EquipSlot> equipSlots = new List<EquipSlot>(); // 장비인벤 슬롯
    private int invenCount = 28;

    private void Start()
    {
        InitSlot();
    } // Start

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ItemData hp = DataManager.Instance.itemDatas[0];
            ItemData mp = DataManager.Instance.itemDatas[1];
            AddItem(hp);
            AddItem(mp);
        }
    } // Update

    //! 슬롯 초기화
    private void InitSlot()
    {
        ItemData item = new ItemData(null);
        item = null;
        for (int i = 0; i < weaponSlotList.Count; i++)
        {
            weaponSlotList[i].AddItem(item);
        }

        for (int i = 0; i < armorSlotList.Count; i++)
        {
            armorSlotList[i].AddItem(item);
        }

        for (int i = 0; i < consumptionSlotList.Count; i++)
        {
            consumptionSlotList[i].AddItem(item);
        }

        for (int i = 0; i < invenCount; i++)
        {
            GameObject slot = Instantiate(slotPrefab);
            EquipSlot equipSlot = slot.GetComponent<EquipSlot>();
            slot.transform.parent = invenPanel.transform.GetChild(0).transform;
            equipSlots.Add(equipSlot);
            inventory.Add(item);
            equipSlots[i].Item = inventory[i];
        }
    } // InitSlot
    public void AddItem(ItemData item)
    {
        ItemData itemData = DataManager.Instance.itemDatas[item.itemID - 1];

        // 인벤토리에 같은 아이템이 있는지 체크
        foreach (ItemData _item in inventory)
        {
            // 같은 아이템이 있고 보유수량이 최대수량보다 작을 때
            if (_item != null)
            {
                if (_item.itemID == item.itemID && _item.quantity < itemData.maxQuantity)
                {
                    _item.quantity++;
                    break;
                }
            }
        }
        Debug.Log("템획득했소");
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                break;
            }
        }
        InitInventorySlot();
    } // AddItem

    public void InitInventorySlot()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            equipSlots[i].Item = inventory[i];
        }
    } // InitInventorySlot

    public void RemoveItem(ItemData item)
    {
        inventory.Remove(item);
    } // RemoveItem
} // Inventory
