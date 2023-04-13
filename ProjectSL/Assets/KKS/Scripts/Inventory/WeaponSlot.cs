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
    private Image icon; // ���Կ� ǥ�õ� icon
    private ItemDescriptionPanel descriptionPanel; // ������ ���� �г�
    private Item item; // ���Կ� ��� ������ ����
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item != null)
            {
                // �������� ������ �̹��� ���
                icon.sprite = item.icon;
                icon.color = new Color(1, 1, 1, 1);
            }
            else
            {
                // �������� ������ ���İ� 0���� ����
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
            Debug.Log("���� ���� ������");
            Inventory.Instance.invenPanel.SetActive(true);
        });
    } // Start

    public void AddItem(Item _item)
    {
        //Debug.Log($"��ȹ�� : {_item.itemData.itemName}");
        Item = _item;
    } // AddItem

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (item != null)
        {
            Debug.Log("���ִ� ���Կ� Ŀ�� ���");
            descriptionPanel.ShowItemData(item);
        }
    } // OnPointerEnter
} // WeaponSlot
