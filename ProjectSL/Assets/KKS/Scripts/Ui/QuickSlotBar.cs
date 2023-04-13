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
            Debug.Log("장비 인벤 선택함");
            inventory.SetActive(true);
        });

        inven.onClick.AddListener(() =>
        {
            Debug.Log("통합 인벤 선택함");

        });

        stat.onClick.AddListener(() =>
        {
            Debug.Log("스테이터스 선택함");

        });

        option.onClick.AddListener(() =>
        {
            Debug.Log("옵션창 선택함");

        });
    } // Start
} // QuickSlotBar
