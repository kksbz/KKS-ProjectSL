using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject slotPrefab; // 슬롯 프리팹
    public GameObject weaponPanel; // 무기 패널
    public GameObject armorPanel; // 방어구 패널
    public GameObject consumptionPanel; // 소모품 패널
    public int weaponSlotSize = 6; // 무기 슬롯수
    public int armorSlotSize = 8; // 방어구 슬롯수
    public int consumptionSlotSize = 8; // 소모품 슬롯수
    
    public List<GameObject> weaponList;
    public List<GameObject> armorList;
    public List<GameObject> consumptionList;

    private void Start()
    {
        SetupSlot();
    } // Start

    private void SetupSlot()
    {
        for (int i = 0; i < weaponSlotSize; i++)
        {
            GameObject weaponslot = Instantiate(slotPrefab);
            weaponslot.transform.parent = weaponPanel.transform;
            weaponList.Add(weaponslot);
        }

        for (int i = 0; i < armorSlotSize; i++)
        {
            GameObject armorslot = Instantiate(slotPrefab);
            armorslot.transform.parent = armorPanel.transform;
            armorList.Add(armorslot);
        }

        for (int i = 0; i < consumptionSlotSize; i++)
        {
            GameObject consumptionslot = Instantiate(slotPrefab);
            consumptionslot.transform.parent = consumptionPanel.transform;
            consumptionList.Add(consumptionslot);
        }
    } // SetupSlot

    public void AddItem()
    {

    } // AddItem

    public void RemoveItem()
    {

    } // RemoveItem
} // Inventory
