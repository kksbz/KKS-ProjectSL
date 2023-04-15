using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
    public Button useBt; // ��� ��ư
    public Button throwBt; // ������ ��ư
    public Button destroyBt; // �ı� ��ư
    public Button cancelBt; // ��� ��ư
    private Slot slot; // ������ ����
    void Start()
    {
        useBt.onClick.AddListener(() =>
        {
            Inventory.Instance.equipSlotPanel.SetActive(true);
            Inventory.Instance.equipInvenPanel.SetActive(false);
            gameObject.SetActive(false);
        });

        throwBt.onClick.AddListener(() =>
        {
            Inventory.Instance.ThrowItem(slot.Item);
            gameObject.SetActive(false);
        });

        destroyBt.onClick.AddListener(() =>
        {
            Inventory.Instance.RemoveItem(slot.Item);
            Inventory.Instance.InitSameTypeTotalSlot(slot.Item.itemType);
            gameObject.SetActive(false);
        });

        cancelBt.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    } // Start

    //! ���õ� ���� �������� �Լ�
    public void SelectSlot(Slot _slot)
    {
        slot = _slot;
        Debug.Log($"���õ� ���� : {slot}");
    } // SelectSlot
} // SelectPanel
