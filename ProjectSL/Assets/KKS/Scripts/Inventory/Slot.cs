using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, PublicSlot, IPointerEnterHandler
{
    private Button button;
    [SerializeField] private Image icon; // ���Կ� ǥ�õ� icon
    private ItemDescriptionPanel descriptionPanel; // ������ ���� �г�
    private SelectPanel selectPanel;
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
            }
            else
            {
                Debug.Log(item);
                // �������� ������ ���İ� 0���� ����
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
            Debug.Log("���� ������");
            // ����â�� ��ġ�� ������ ���ʰ� ��ġ�����ְ� �ű⿡ ������ x���̸�ŭ ���������� ������
            float xPos = (panelRect.sizeDelta.x - buttonRect.sizeDelta.x) * 0.5f + buttonRect.sizeDelta.x;
            // ����â�� ��ġ�� ������ ���������� ����
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
} // Slot
