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
    private GameObject slot; // 선택한 슬롯
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

    //! 선택된 슬롯 가져오는 함수
    public void SelectSlot(GameObject _slot)
    {
        slot = _slot;
        Debug.Log($"선택된 슬롯 : {slot}");
    } // SelectSlot
} // SelectPanel
