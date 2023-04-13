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
    [SerializeField] private Image showIcon; // ������ ������ ������
    [SerializeField] private TMP_Text showItemName; // ������ ������ �̸�
    [SerializeField] private TMP_Text showDescription; // ������ ������ ����

    void Start()
    {
        showIcon = icon.GetComponent<Image>();
        showItemName = itemName.GetComponent<TMP_Text>();
        showDescription = description.GetComponent<TMP_Text>();
    } // Start

    //! ������ ���� �гο� ������ ������ ���ϴ� �Լ�
    public void ShowItemData(Item item)
    {
        showIcon.sprite = item.icon;
        showItemName.text = item.itemData.itemName;
        showDescription.text = item.itemData.description;
    } // ShowItemData
} // ItemDescriptionPanel
