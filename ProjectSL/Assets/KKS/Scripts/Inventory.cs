using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject slotPrefab; // ���� ������
    public GameObject weaponPanel; // ���� �г�
    public GameObject armorPanel; // �� �г�
    public GameObject consumptionPanel; // �Ҹ�ǰ �г�
    public int weaponSlotSize = 6; // ���� ���Լ�
    public int armorSlotSize = 8; // �� ���Լ�
    public int consumptionSlotSize = 8; // �Ҹ�ǰ ���Լ�
    
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
