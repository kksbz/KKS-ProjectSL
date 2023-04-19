using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.IO;
public class DataManager : Singleton<DataManager>
{
    public List<string[]> itemDatas = new List<string[]>(); // ������ ������ ����Ʈ
    private string path;
    public override void InitManager()
    {
        StartCoroutine(GoogleSheetManager.InitData());
        path = "C:/kksUnity/ProjectSL" + "/SavePlayerData";
    } // InitManager

    //! �÷��̾� ������ ���̺��ϴ� �Լ�
    public void SaveData()
    {
        string data = null;
        foreach (var item in Inventory.Instance.inventory)
        {
            // �κ��丮���� �����۵��� Json���Ϸ� ���� ������ ����: \n ���
            data += JsonUtility.ToJson(item) + "\n";
        }
        // �ܺ������� Json���� ����
        File.WriteAllText(path, data);
        Debug.Log("���̺� ��");
    } // SaveData

    //! ���̺굥���� �ε��ϴ� �Լ�
    public void LoadData()
    {
        List<string> newItemDatas = new List<string>();
        // ����� Json������ �ҷ���
        string data = File.ReadAllText(path);
        TextAsset inventoryData = new TextAsset(data);
        // \n�� �������� �߶� �迭�� ������ ����
        string[] itemDatas = inventoryData.text.Split("\n");
        //Debug.Log(itemDatas.Length);
        for (int i = 0; i < itemDatas.Length - 1; i++)
        {
            bool isNullData = true;
            // �������� ���� ������ ����
            if (!string.IsNullOrWhiteSpace(itemDatas[i]))
            {
                //Debug.Log($"�����Ͱ����� : {itemDatas[i]}");
                isNullData = false;
            }
            // �������� ���� ������ List�� ����
            if (isNullData == false)
            {
                newItemDatas.Add(itemDatas[i]);
            }
        }
        for (int i = 0; i < newItemDatas.Count; i++)
        {
            //Debug.Log($"{i}��° ������ : {newItemDatas[i]}");
            // �ҷ��� �����۵����͸� ItemDataŸ������ ��ȯ�ؼ� �κ��丮�� �߰�
            ItemData item = JsonUtility.FromJson<ItemData>(newItemDatas[i]);
            Inventory.Instance.AddItem(item);
        }
    } // LoadData
} // DataManager