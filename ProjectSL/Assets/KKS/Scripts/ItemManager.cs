using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public List<ItemData> items = new List<ItemData>();
    public override void InitManager()
    {
        StartCoroutine(GoogleSheetManager.InitData());
    }
} // ItemManager
