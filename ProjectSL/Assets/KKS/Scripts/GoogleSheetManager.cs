using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager
{
    // ������ ������ ���̺� �ּ�
    const string ITEMDATA_URL = "https://docs.google.com/spreadsheets/d/1fc7zvkSFdMGstxoSrExcC7ZaMutmBfqONeRNgoNVqW8/export?format=csv&range=A2:P";
    // ����ġ ���̺� �ּ�
    const string ExperienceDATA_URL = "https://docs.google.com/spreadsheets/d/1fc7zvkSFdMGstxoSrExcC7ZaMutmBfqONeRNgoNVqW8/export?format=csv&range=A2:C&gid=1728483937";
    //! ���۽�Ʈ�� ��� ������ URL�� �������� �Լ�
    public static IEnumerator InitItemData()
    {
        UnityWebRequest wwwItemDatas = UnityWebRequest.Get(ITEMDATA_URL);
        yield return wwwItemDatas.SendWebRequest();
        string itemDataBase = wwwItemDatas.downloadHandler.text;
        // URL�� ������ ���۽�Ʈ�� �����۵����͸� �Ľ���
        List<string[]> itemDatas = CSVReader.CSVRead(itemDataBase);
        // �����͸Ŵ��� itemDatas ������ �Ľ̵� �����۸���Ʈ�� ĳ��
        DataManager.Instance.itemDatas = itemDatas;
        //Debug.Log(itemDataBase);
        Debug.Log("������ �ҷ����� �Ϸ�");
    } // Start

    public static IEnumerator InitExperienceData()
    {
        UnityWebRequest wwwExperienceDatas = UnityWebRequest.Get(ExperienceDATA_URL);
        yield return wwwExperienceDatas.SendWebRequest();
        string experienceBase = wwwExperienceDatas.downloadHandler.text;
        List<string[]> experienceDatas = CSVReader.CSVRead(experienceBase);

        Dictionary<int, int> experienceDic = new Dictionary<int, int>();
        foreach (string[] experienceData in experienceDatas)
        {
            int key = int.Parse(experienceData[0]);
            int value = int.Parse(experienceData[1]);
            experienceDic.Add(key, value);
        }
        DataManager.Instance.experienceDatas = experienceDic;
        //foreach(var data in DataManager.Instance.experienceDatas)
        //{
        //    Debug.Log($"Ű�� : {data.Key}, ������ : {data.Value}");
        //}
    } // InitExperienceData
} // GoogleSheetManager
