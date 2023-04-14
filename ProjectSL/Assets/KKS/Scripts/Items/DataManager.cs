using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public List<ItemData> itemDatas = new List<ItemData>(); // ������ ������ ����Ʈ

    public override void InitManager()
    {
        StartCoroutine(GoogleSheetManager.InitData());
    } // InitManager
} // DataManager
