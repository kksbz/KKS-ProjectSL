using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, PublicSlot, IPointerEnterHandler
{
    private Button button;
    [SerializeField] private Image icon; // 슬롯에 표시될 icon
    private ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    private SelectPanel selectPanel;
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
            }
            else
            {
                Debug.Log(item);
                // 아이템이 없으면 알파값 0으로 숨김
                icon.color = new Color(1, 1, 1, 0);
            }
        }
    } // Item

    void Awake()
    {
        button = GetComponent<Button>();
        descriptionPanel = Inventory.Instance.descriptionPanel;
        selectPanel = Inventory.Instance.selectPanel;
        RectTransform panelRect = selectPanel.GetComponent<RectTransform>();
        RectTransform buttonRect = gameObject.GetComponent<RectTransform>();
        button.onClick.AddListener(() =>
        {
            Debug.Log("슬롯 선택함");
            // 설명창의 위치를 슬롯의 왼쪽과 일치시켜주고 거기에 슬롯의 x길이만큼 오른쪽으로 더해줌
            float xPos = (panelRect.sizeDelta.x - buttonRect.sizeDelta.x) * 0.5f + buttonRect.sizeDelta.x;
            // 설명창의 위치를 슬롯의 오른쪽으로 설정
            selectPanel.transform.position = transform.position + new Vector3(xPos, 0, 0);
            selectPanel.gameObject.SetActive(true);
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
} // Slot
