using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject itemIcon;
    private Image icon; // 슬롯에 표시될 icon
    private GameObject selectPanel; // 슬롯 선택시 나올 선택창
    private Item item; // 슬롯에 담길 아이템 변수
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;
            if (item != null)
            {
                icon.sprite = item.icon;
                icon.color = new Color(1, 1, 1, 1);
            }
            else
            {
                icon.color = new Color(1, 1, 1, 0);
            }
        }
    }

    void Start()
    {
        button = GetComponent<Button>();
        icon = itemIcon.GetComponent<Image>();
        selectPanel = Inventory.Instance.selectPanel;
        RectTransform panelRect = selectPanel.GetComponent<RectTransform>();
        RectTransform buttonRect = gameObject.GetComponent<RectTransform>();
        button.onClick.AddListener(() =>
        {
            Debug.Log("슬롯 선택함");
            // 설명창의 위치를 슬롯의 왼쪽과 일치시켜주고 거기에 슬롯의 x길이만큼 오른쪽으로 더해줌
            float xPos = (panelRect.sizeDelta.x - buttonRect.sizeDelta.x) * 0.5f + buttonRect.sizeDelta.x;
            // 설명창의 위치를 슬롯의 오른쪽으로 설정
            selectPanel.transform.position = transform.position + new Vector3(xPos, 0, 0);
            selectPanel.SetActive(true);
        });
    } // Start
} // Slot
