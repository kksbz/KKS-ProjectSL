using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IPointerEnterHandler
{
    private Button button;
    [SerializeField] private Image icon; // 슬롯에 표시될 icon
    [SerializeField] private GameObject equipIcon; // 장착여부 표시 icon
    [SerializeField] private TMP_Text quantity; // 수량표시 Text
    private ItemDescriptionPanel descriptionPanel; // 아이템 설명 패널
    private GameObject equipSlot; // 선택한 장비 슬롯
    [SerializeField] private ItemData item; // 슬롯에 담길 아이템 변수
    private bool isEquipItem = false;
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
                if (item.maxQuantity != 1)
                {
                    quantity.text = item.quantity.ToString();
                    quantity.gameObject.SetActive(true);
                }
                else
                {
                    quantity.gameObject.SetActive(false);
                }
            }
            else
            {
                // 아이템이 없으면 알파값 0으로 숨김
                icon.color = new Color(1, 1, 1, 0);
            }
        }
    } // Item

    void Awake()
    {
        button = GetComponent<Button>();
        descriptionPanel = Inventory.Instance.descriptionPanel;
        button.onClick.AddListener(() =>
        {
            if (isEquipItem == false)
            {
                equipSlot.GetComponent<IPublicSlot>().AddItem(item);
                equipIcon.SetActive(true);
            }
            else
            {
                equipSlot.GetComponent<IPublicSlot>().RemoveItem();
                equipIcon.SetActive(false);
            }
            isEquipItem = !isEquipItem;
        });
    } // Start

    //! 선택된 슬롯 가져오는 함수
    public void SelectSlot(GameObject _slot)
    {
        equipSlot = _slot;
        Debug.Log($"선택된 슬롯 : {equipSlot}");
    } // SelectSlot

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log("템있는 슬롯에 커서 들옴");
            descriptionPanel.ShowItemData(item);
        }
    } // OnPointerEnter
} // EquipSlot
