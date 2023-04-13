using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorSlot : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject itemIcon;
    private Image icon; // 슬롯에 표시될 icon
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
        button.onClick.AddListener(() =>
        {
            Debug.Log("방어구 슬롯 선택함");
            Inventory.Instance.invenPanel.SetActive(true);
        });
    } // Start
} // ArmorSlot
