using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotBar : MonoBehaviour
{
    public Button equip;
    public Button inven;
    public Button stat;
    public Button option;
    public GameObject inventory;

    void Start()
    {
        equip.onClick.AddListener(() =>
        {
            Debug.Log("��� �κ� ������");
            inventory.SetActive(true);
        });

        inven.onClick.AddListener(() =>
        {
            Debug.Log("���� �κ� ������");

        });

        stat.onClick.AddListener(() =>
        {
            Debug.Log("�������ͽ� ������");

        });

        option.onClick.AddListener(() =>
        {
            Debug.Log("�ɼ�â ������");

        });
    } // Start
} // QuickSlotBar
