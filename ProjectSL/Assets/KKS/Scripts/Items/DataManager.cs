using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<ItemData> itemDatas = new List<ItemData>(); // 아이템 데이터 리스트

    public override void InitManager()
    {
        StartCoroutine(GoogleSheetManager.InitData());
    } // InitManager
} // DataManager
