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
    public Image showIcon; // 보여질 아이템 아이콘
    public TMP_Text showItemName; // 보여질 아이템 이름
    public TMP_Text showDescription; // 보여질 아이템 설명

    void Start()
    {
        showIcon = icon.GetComponent<Image>();
        showItemName = itemName.GetComponent<TMP_Text>();
        showDescription = description.GetComponent<TMP_Text>();

        showItemName.text = $"{Inventory.Instance.items[0].itemName}";
        showDescription.text = Inventory.Instance.items[0].description;
    } // Start
} // ItemDescriptionPanel
