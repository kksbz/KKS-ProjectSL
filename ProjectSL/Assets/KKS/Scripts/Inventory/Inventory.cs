using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static ItemData;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private GameObject invenObj;
    private int invenCount = 28;
    public GameObject equipSlotPrefab; // 장비슬롯 프리팹
    public GameObject totalSlotPrefab; // 통합인벤 슬롯 프리팹
    public GameObject equipSlotPanel; // 장비슬롯 패널
    public GameObject equipInvenPanel; // 장비인벤토리 패널
    public GameObject totalInvenPanel; // 통합인벤 패널
    public TMP_Text equipInvenText; // 장비인벤토리 패널 상단 텍스트
    public TMP_Text totalInvenText; // 통합인벤토리 패널 상단 텍스트
    public ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    public SelectPanel selectPanel; // 선택창 패널

    public List<WeaponSlot> weaponSlotList;
    public List<ArmorSlot> armorSlotList;
    public List<ConsumptionSlot> consumptionSlotList;

    public List<ItemData> inventory = new List<ItemData>(); // 인벤토리
    public List<EquipSlot> equipSlots = new List<EquipSlot>(); // 장비인벤 슬롯
    public List<Slot> totalSlots = new List<Slot>(); // 장비인벤 슬롯
    public IPublicSlot selectSlot; // 선택한 슬롯 담을 변수

    private void Start()
    {
        InitSlot();
    } // Start

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            invenObj.SetActive(false);
            equipSlotPanel.SetActive(true);
            equipInvenPanel.SetActive(false);
            selectPanel.gameObject.SetActive(false);
            totalInvenPanel.SetActive(false);
        }
    } // Update

    //! 슬롯 초기화
    private void InitSlot()
    {
        for (int i = 0; i < weaponSlotList.Count; i++)
        {
            weaponSlotList[i].AddItem(null);
        }

        for (int i = 0; i < armorSlotList.Count; i++)
        {
            armorSlotList[i].AddItem(null);
        }

        for (int i = 0; i < consumptionSlotList.Count; i++)
        {
            consumptionSlotList[i].AddItem(null);
        }

        for (int i = 0; i < invenCount; i++)
        {
            // 장비인벤 슬롯 세팅
            GameObject slot = Instantiate(equipSlotPrefab);
            EquipSlot equipSlot = slot.GetComponent<EquipSlot>();
            slot.transform.parent = equipInvenPanel.transform.GetChild(0).transform;
            // 통합인벤 슬롯 세팅
            GameObject tSlot = Instantiate(totalSlotPrefab);
            Slot totalSlot = tSlot.GetComponent<Slot>();
            tSlot.transform.parent = totalInvenPanel.transform.GetChild(0).transform;
            equipSlots.Add(equipSlot);
            totalSlots.Add(totalSlot);
            inventory.Add(null);
            equipSlots[i].Item = null;
            totalSlots[i].Item = null;
        }
    } // InitSlot

    //! 인벤토리에 아이템 추가하는 함수
    public void AddItem(ItemData item)
    {
        ItemData itemData = new ItemData(DataManager.Instance.itemDatas[item.itemID - 1]);
        // 인벤토리에 같은 아이템이 있는지 체크
        foreach (ItemData _item in inventory)
        {
            if (_item != null)
            {
                if (_item.itemID == item.itemID)
                {
                    // 같은 아이템이 있고 보유수량이 최대수량보다 작을 때
                    if (_item.Quantity < itemData.maxQuantity)
                    {
                        _item.Quantity++;
                        return;
                    }
                }
            }
        }
        Debug.Log($"템획득했소 {inventory[1]}");
        // 인벤토리에 같은 아이템이 없을 경우
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

    //! 아이템 버리는 함수
    public void ThrowItem(ItemData item)
    {
        inventory.Remove(item);
    } // ThrowItem

    //! 아이템 파괴하는 함수
    public void RemoveItem(ItemData item)
    {
        inventory.Remove(item);
    } // RemoveItem

    //! 정해진 itemType을 장비해야하는 슬롯일 경우 장비인벤슬롯에 같은 itemType인 아이템만 보여주는 함수
    public void InitSameTypeEquipSlot(ItemType _itemType)
    {
        Debug.Log(_itemType);
        List<ItemData> sameTypes = new List<ItemData>();
        foreach (ItemData _item in inventory)
        {
            // 같은 타입의 아이템만 따로 캐싱
            if (_item != null && _item.itemType == _itemType)
            {
                sameTypes.Add(_item);
            }
        }
        Debug.Log($"{sameTypes.Count}");
        // itemID 기준으로 오름차순 정렬
        sameTypes = sameTypes.OrderBy(x => x.itemID).ToList();
        for (int i = 0; i < equipSlots.Count; i++)
        {
            if (i < sameTypes.Count)
            {
                // 캐싱해둔 같은 타입의 아이템을 슬롯에 표시
                equipSlots[i].Item = sameTypes[i];
            }
            else
            {
                // 빈곳 표시를 위한 null값
                equipSlots[i].Item = null;
            }
        }
    } // InitEquipInven

    //! 선택한 itemType인 아이템만 통합인벤에 보여주는 함수
    public void InitSameTypeTotalSlot(ItemType _itemType)
    {
        Debug.Log(_itemType);
        List<ItemData> sameTypes = new List<ItemData>();
        foreach (ItemData _item in inventory)
        {
            // 같은 타입의 아이템만 따로 캐싱
            if (_item != null && _item.itemType == _itemType)
            {
                sameTypes.Add(_item);
            }
        }
        Debug.Log($"{sameTypes.Count}");
        // itemID 기준으로 오름차순 정렬
        sameTypes = sameTypes.OrderBy(x => x.itemID).ToList();
        for (int i = 0; i < totalSlots.Count; i++)
        {
            if (i < sameTypes.Count)
            {
                // 캐싱해둔 같은 타입의 아이템을 슬롯에 표시
                totalSlots[i].Item = sameTypes[i];
            }
            else
            {
                // 빈곳 표시를 위한 null값
                totalSlots[i].Item = null;
            }
        }
    } // InitEquipInven
} // Inventory
