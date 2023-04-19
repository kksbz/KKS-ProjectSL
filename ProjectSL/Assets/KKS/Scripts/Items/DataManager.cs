using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System.IO;
public class DataManager : Singleton<DataManager>
{
    public List<string[]> itemDatas = new List<string[]>(); // 아이템 데이터 리스트
    private string path;
    public override void InitManager()
    {
        StartCoroutine(GoogleSheetManager.InitData());
        path = "C:/kksUnity/ProjectSL" + "/SavePlayerData";
    } // InitManager

    //! 플레이어 데이터 세이브하는 함수
    public void SaveData()
    {
        string data = null;
        foreach (var item in Inventory.Instance.inventory)
        {
            // 인벤토리안의 아이템들을 Json파일로 저장 아이템 구분: \n 사용
            data += JsonUtility.ToJson(item) + "\n";
        }
        // 외부폴더에 Json파일 생성
        File.WriteAllText(path, data);
        Debug.Log("세이브 됨");
    } // SaveData

    //! 세이브데이터 로드하는 함수
    public void LoadData()
    {
        List<string> newItemDatas = new List<string>();
        // 저장된 Json파일을 불러옴
        string data = File.ReadAllText(path);
        TextAsset inventoryData = new TextAsset(data);
        // \n을 기준으로 잘라서 배열에 데이터 저장
        string[] itemDatas = inventoryData.text.Split("\n");
        //Debug.Log(itemDatas.Length);
        for (int i = 0; i < itemDatas.Length - 1; i++)
        {
            bool isNullData = true;
            // 데이터의 값이 없으면 제외
            if (!string.IsNullOrWhiteSpace(itemDatas[i]))
            {
                //Debug.Log($"데이터가있음 : {itemDatas[i]}");
                isNullData = false;
            }
            // 데이터의 값이 있으면 List에 저장
            if (isNullData == false)
            {
                newItemDatas.Add(itemDatas[i]);
            }
        }
        for (int i = 0; i < newItemDatas.Count; i++)
        {
            //Debug.Log($"{i}번째 데이터 : {newItemDatas[i]}");
            // 불러온 아이템데이터를 ItemData타입으로 변환해서 인벤토리에 추가
            ItemData item = JsonUtility.FromJson<ItemData>(newItemDatas[i]);
            Inventory.Instance.AddItem(item);
        }
    } // LoadData
} // DataManager