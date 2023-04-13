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
        selectPanel = Inventory.Instance.selectPanel;
        RectTransform panelRect = selectPanel.GetComponent<RectTransform>();
        RectTransform buttonRect = gameObject.GetComponent<RectTransform>();
        button.onClick.AddListener(() =>
        {
            Debug.Log("���� ������");
            // ����â�� ��ġ�� ������ ���ʰ� ��ġ�����ְ� �ű⿡ ������ x���̸�ŭ ���������� ������
            float xPos = (panelRect.sizeDelta.x - buttonRect.sizeDelta.x) * 0.5f + buttonRect.sizeDelta.x;
            // ����â�� ��ġ�� ������ ���������� ����
            selectPanel.transform.position = transform.position + new Vector3(xPos, 0, 0);
            selectPanel.SetActive(true);
        });
    } // Start
} // Slot
