using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ItemData;

public class ConsumptionSlot : MonoBehaviour, IPublicSlot, IPointerEnterHandler
{
    private Button button;
    [SerializeField] TMP_Text quantity;
    [SerializeField] private Image icon; // 슬롯에 표시될 icon
    private ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    [SerializeField] private ItemType slotType; // 슬롯에 담길 아이템타입 제한 변수
    public ItemType SlotType { get; set; }
    //[SerializeField] private string slotType; // 슬롯에 담길 아이템타입 제한 변수
    //public string SlotType { get { return slotType; } set { slotType = value; } }
    [SerializeField] private ItemData item; // 슬롯에 담길 아이템 변수
    public ItemData Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item != null)
            {
                // 아이템이 있으면 이미지 출력
                icon.sprite = Resources.Load<Sprite>(item.itemIcon);
                icon.color = new Color(1, 1, 1, 1);
                quantity.text = item.quantity.ToString();
                quantity.gameObject.SetActive(true);
            }
            else
            {
                // 아이템이 없으면 알파값 0으로 숨김
                icon.color = new Color(1, 1, 1, 0);
                quantity.gameObject.SetActive(false);
            }
        }
    } // Item

    void Awake()
    {
        button = GetComponent<Button>();
        descriptionPanel = Inventory.Instance.descriptionPanel;
        button.onClick.AddListener(() =>
        {
            Debug.Log("소모품 슬롯 선택함");
            Inventory.Instance.InitEquipInven(slotType);
            Inventory.Instance.invenPanel.SetActive(true);
            Inventory.Instance.equipPanel.SetActive(false);
        });
    } // Start

    public void AddItem(ItemData _item)
    {
        if (_item == null)
        {
            Item = null;
            return;
        }
        Debug.Log($"템획득 : {_item.itemName}");
        Item = _item;
        Debug.Log(Item);
        Debug.Log(Item.itemIcon);
    } // AddItem

    public void RemoveItem()
    {
        ItemData item = new ItemData(null);
        item = null;
        Item = item;
    } // RemoveItem

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log("템있는 슬롯에 커서 들옴");
            descriptionPanel.ShowItemData(item);
        }
    } // OnPointerEnter
} // ConsumptionSlot
