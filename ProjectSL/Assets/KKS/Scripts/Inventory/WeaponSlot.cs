using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour, IPointerEnterHandler
{
    private Button button;
    [SerializeField] private GameObject itemIcon;
    private Image icon; // 슬롯에 표시될 icon
    private ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    private Item item; // 슬롯에 담길 아이템 변수
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item != null)
            {
                // 아이템이 있으면 이미지 출력
                icon.sprite = item.icon;
                icon.color = new Color(1, 1, 1, 1);
            }
            else
            {
                // 아이템이 없으면 알파값 0으로 숨김
                icon.color = new Color(1, 1, 1, 0);
            }
        }
    }

    void Start()
    {
        button = GetComponent<Button>();
        icon = itemIcon.GetComponent<Image>();
        descriptionPanel = Inventory.Instance.descriptionPanel;
        button.onClick.AddListener(() =>
        {
            Debug.Log("무기 슬롯 선택함");
            Inventory.Instance.invenPanel.SetActive(true);
        });
    } // Start

    public void AddItem(Item _item)
    {
        //Debug.Log($"템획득 : {_item.itemData.itemName}");
        Item = _item;
    } // AddItem

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (item != null)
        {
            Debug.Log("템있는 슬롯에 커서 들옴");
            descriptionPanel.ShowItemData(item);
        }
    } // OnPointerEnter
} // WeaponSlot
