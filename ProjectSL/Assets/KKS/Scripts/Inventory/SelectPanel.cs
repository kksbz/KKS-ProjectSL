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
    private GameObject slot; // ������ ����
    void Start()
    {
        useBt.onClick.AddListener(() =>
        {
            ItemData hp = DataManager.Instance.itemDatas[0];
            slot.GetComponent<PublicSlot>().AddItem(hp);
            Inventory.Instance.equipPanel.SetActive(true);
            Inventory.Instance.invenPanel.SetActive(false);
            gameObject.SetActive(false);
        });

        throwBt.onClick.AddListener(() =>
        {

        });

        destroyBt.onClick.AddListener(() =>
        {

        });

        cancelBt.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    } // Start

    //! ���õ� ���� �������� �Լ�
    public void SelectSlot(GameObject _slot)
    {
        slot = _slot;
        Debug.Log($"���õ� ���� : {slot}");
    } // SelectSlot
} // SelectPanel
