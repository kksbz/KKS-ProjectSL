using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionPanel : MonoBehaviour
{
    public GameObject icon;
    public GameObject itemName;
    public GameObject description;
    [SerializeField] private Image showIcon; // 보여질 아이템 아이콘
    [SerializeField] private TMP_Text showItemName; // 보여질 아이템 이름
    [SerializeField] private TMP_Text showDescription; // 보여질 아이템 설명

    void Start()
    {
        showIcon = icon.GetComponent<Image>();
        showItemName = itemName.GetComponent<TMP_Text>();
        showDescription = description.GetComponent<TMP_Text>();
    } // Start

    //! 아이템 설명 패널에 보여질 데이터 정하는 함수
    public void ShowItemData(ItemData item)
    {
        showIcon.sprite = Resources.Load<Sprite>(item.itemIcon);
        showItemName.text = item.itemName;
        showDescription.text = item.description;
    } // ShowItemData
} // ItemDescriptionPanel
