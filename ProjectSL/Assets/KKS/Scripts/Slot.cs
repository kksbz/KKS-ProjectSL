using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject itemIcon;
    private Sprite icon; // ���Կ� ǥ�õ� icon
    private Item item; // ���Կ� ��� ������ ����

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        icon = itemIcon.GetComponent<Sprite>();
        button.onClick.AddListener(() => Debug.Log("��ư Ŭ����"));
    } // Start
} // Slot
