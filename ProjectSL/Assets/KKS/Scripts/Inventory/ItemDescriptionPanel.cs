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
    public Image showIcon; // ������ ������ ������
    public TMP_Text showItemName; // ������ ������ �̸�
    public TMP_Text showDescription; // ������ ������ ����

    void Start()
    {
        showIcon = icon.GetComponent<Image>();
        showItemName = itemName.GetComponent<TMP_Text>();
        showDescription = description.GetComponent<TMP_Text>();

        showItemName.text = $"{Inventory.Instance.items[0].itemName}";
        showDescription.text = Inventory.Instance.items[0].description;
    } // Start
} // ItemDescriptionPanel
