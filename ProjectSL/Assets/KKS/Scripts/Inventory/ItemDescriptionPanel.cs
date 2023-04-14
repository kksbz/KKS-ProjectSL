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
    public void ShowItemData(ItemData item)
    {
        showIcon.sprite = Resources.Load<Sprite>(item.itemIcon);
        showItemName.text = item.itemName;
        showDescription.text = item.description;
    } // ShowItemData
} // ItemDescriptionPanel
