using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject itemIcon;
    private Image icon; // ���Կ� ǥ�õ� icon
    private GameObject selectPanel; // ���� ���ý� ���� ����â
    private Item item; // ���Կ� ��� ������ ����
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
        button.onClick.AddListener(() => Debug.Log("��ư Ŭ����"));
    } // Start
} // Slot
