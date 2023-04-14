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
    [SerializeField] private Image icon; // ���Կ� ǥ�õ� icon
    private ItemDescriptionPanel descriptionPanel; // ������ ���� �г�
    [SerializeField] private ItemType slotType; // ���Կ� ��� ������Ÿ�� ���� ����
    public ItemType SlotType { get; set; }
    //[SerializeField] private string slotType; // ���Կ� ��� ������Ÿ�� ���� ����
    //public string SlotType { get { return slotType; } set { slotType = value; } }
    [SerializeField] private ItemData item; // ���Կ� ��� ������ ����
    public ItemData Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item != null)
            {
                // �������� ������ �̹��� ���
                icon.sprite = Resources.Load<Sprite>(item.itemIcon);
                icon.color = new Color(1, 1, 1, 1);
                quantity.text = item.quantity.ToString();
                quantity.gameObject.SetActive(true);
            }
            else
            {
                // �������� ������ ���İ� 0���� ����
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
            Debug.Log("�Ҹ�ǰ ���� ������");
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
        Debug.Log($"��ȹ�� : {_item.itemName}");
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
            Debug.Log("���ִ� ���Կ� Ŀ�� ���");
            descriptionPanel.ShowItemData(item);
        }
    } // OnPointerEnter
} // ConsumptionSlot
