using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour, IPointerEnterHandler
{
    private Button button;
    [SerializeField] private Image icon; // ���Կ� ǥ�õ� icon
    [SerializeField] private GameObject equipIcon; // �������� ǥ�� icon
    [SerializeField] private TMP_Text quantity; // ����ǥ�� Text
    private ItemDescriptionPanel descriptionPanel; // ������ ���� �г�
    private GameObject equipSlot; // ������ ��� ����
    [SerializeField] private ItemData item; // ���Կ� ��� ������ ����
    private bool isEquipItem = false;
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
                // �������� ������ ���İ� 0���� ����
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

    //! ���õ� ���� �������� �Լ�
    public void SelectSlot(GameObject _slot)
    {
        equipSlot = _slot;
        Debug.Log($"���õ� ���� : {equipSlot}");
    } // SelectSlot

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log("���ִ� ���Կ� Ŀ�� ���");
            descriptionPanel.ShowItemData(item);
        }
    } // OnPointerEnter
} // EquipSlot
