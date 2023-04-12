using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager
{
    const string URL = "https://docs.google.com/spreadsheets/d/1fc7zvkSFdMGstxoSrExcC7ZaMutmBfqONeRNgoNVqW8/export?format=csv&range=A2:I";
    //! ���۽�Ʈ�� ��� ������ URL�� �������� �Լ�
    public static IEnumerator InitData()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string itemDataBase = www.downloadHandler.text;

        // URL�� ������ ���۽�Ʈ�� �����۵����͸� �Ľ���
        List<string[]> itemDatas = CSVReader.CSVRead(itemDataBase);
        List<ItemData> items = CSVDataParser.ItemDataParser(itemDatas);
        // �����۸Ŵ��� items ������ �Ľ̵� �����۸���Ʈ�� ĳ��
        ItemManager.Instance.items = items;
        Debug.Log("������ �ҷ����� �Ϸ�");
    } // Start
} // GoogleSheetManager
