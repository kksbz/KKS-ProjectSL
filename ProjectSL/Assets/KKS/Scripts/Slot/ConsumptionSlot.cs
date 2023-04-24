using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static ItemData;

public class ConsumptionSlot : MonoBehaviour, IPublicSlot, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    [SerializeField] private Image icon; // 슬롯에 표시될 icon
    [SerializeField] private TMP_Text quantity; // 수량표시 Text
    private ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    public GameObject equipItem; // 슬롯에 장착한 소모품 아이템 오브젝트
    public GameObject SlotObj { get { return gameObject; } }

    [SerializeField] private ItemType slotType; // 슬롯에 담길 아이템타입 제한 변수
    public ItemType SlotType { get { return slotType; } set { slotType = value; } }
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
                quantity.text = item.Quantity.ToString();
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
            Inventory.Instance.selectSlot = this;
            Inventory.Instance.InitSameTypeEquipSlot(slotType);
            if (slotType == ItemType.ATTACK_CONSUMPTION)
            {
                Inventory.Instance.equipInvenText.text = "공격용 소모품";
            }
            else
            {
                Inventory.Instance.equipInvenText.text = "회복용 소모품";
            }
            Inventory.Instance.equipInvenPanel.SetActive(true);
            Inventory.Instance.equipSlotPanel.SetActive(false);
        });
    } // Start

    public void AddItem(ItemData _item)
    {
        Item = _item;
        if (_item != null)
        {
            equipItem = Instantiate(Resources.Load<GameObject>($"KKS/Prefabs/Item/{_item.itemID}"));
            equipItem.GetComponent<Item>().pickupArea.SetActive(false);
            equipItem.SetActive(false);
        }
    } // AddItem

    public void RemoveItem()
    {
        Item = null;
        // 생성된 아이템 파괴
        Destroy(equipItem);
        equipItem = null;
    } // RemoveItem

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log("템있는 슬롯에 커서 들옴");
            descriptionPanel.ShowItemData(item);
        }
    } // OnPointerEnter

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.HideItemData();
    } // OnPointerExit
} // ConsumptionSlot
