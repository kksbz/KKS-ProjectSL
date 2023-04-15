using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
    public Button useBt; // 사용 버튼
    public Button throwBt; // 버리기 버튼
    public Button destroyBt; // 파괴 버튼
    public Button cancelBt; // 취소 버튼
    private Slot slot; // 선택한 슬롯
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

    //! 선택된 슬롯 가져오는 함수
    public void SelectSlot(Slot _slot)
    {
        slot = _slot;
        Debug.Log($"선택된 슬롯 : {slot}");
    } // SelectSlot
} // SelectPanel
