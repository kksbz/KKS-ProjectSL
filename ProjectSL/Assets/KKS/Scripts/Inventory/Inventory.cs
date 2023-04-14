using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static ItemData;
using static UnityEditor.Progress;

public class Inventory : Singleton<Inventory>
{
    public GameObject slotPrefab; // ���� ������
    public GameObject equipPanel; // ����κ� �г�
    public GameObject invenPanel; // �κ��丮 �г�
    public ItemDescriptionPanel descriptionPanel; // ������ ���� �г�
    public SelectPanel selectPanel; // ����â �г�

    public List<WeaponSlot> weaponSlotList;
    public List<ArmorSlot> armorSlotList;
    public List<ConsumptionSlot> consumptionSlotList;

    public List<ItemData> inventory = new List<ItemData>(); // �κ��丮
    public List<EquipSlot> equipSlots = new List<EquipSlot>(); // ����κ� ����
    public IPublicSlot selectSlot; // ������ ���� ���� ����
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

    //! ���� �ʱ�ȭ
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

    public void InitInventorySlot()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            equipSlots[i].Item = inventory[i];
        }
    } // InitInventorySlot

    public void AddItem(ItemData item)
    {
        ItemData itemData = DataManager.Instance.itemDatas[item.itemID - 1];
        // �κ��丮�� ���� �������� �ִ��� üũ
        foreach (ItemData _item in inventory)
        {
            if (_item != null)
            {
                // ���� �������� �ְ� ���������� �ִ�������� ���� ��
                if (_item.itemID == item.itemID && _item.quantity < itemData.maxQuantity)
                {
                    _item.quantity++;
                    return;
                }
            }
        }
        Debug.Log("��ȹ���߼�");
        // �κ��丮�� ���� �������� ���� ���
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log($"{inventory[i].itemName}");
                return;
            }
        }
    } // AddItem

    public void RemoveItem(ItemData item)
    {
        inventory.Remove(item);
    } // RemoveItem

    //! ������ itemType�� ����ؾ��ϴ� ������ ��� ����κ����Կ� ���� itemType�� �����۸� �����ִ� �Լ�
    public void InitEquipInven(ItemType _itemType)
    {
        Debug.Log(_itemType);
        List<ItemData> sameTypes = new List<ItemData>();
        foreach (ItemData _item in inventory)
        {
            // ���� Ÿ���� �����۸� ���� ĳ��
            if (_item != null && _item.itemType == _itemType)
            {
                sameTypes.Add(_item);
            }
        }
        Debug.Log($"{sameTypes.Count}");
        // itemID �������� �������� ����
        sameTypes = sameTypes.OrderBy(x => x.itemID).ToList();
        for (int i = 0; i < equipSlots.Count; i++)
        {
            if (i < sameTypes.Count)
            {
                // ĳ���ص� ���� Ÿ���� �������� ���Կ� ǥ��
                equipSlots[i].Item = sameTypes[i];
            }
            else
            {
                // ��� ǥ�ø� ���� null��
                ItemData item = new ItemData(null);
                item = null;
                equipSlots[i].Item = item;
            }
        }
    } // InitEquipInven
} // Inventory
