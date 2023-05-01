using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager
{
    // 아이템 데이터 테이블 주소
    const string ITEMDATA_URL = "https://docs.google.com/spreadsheets/d/1fc7zvkSFdMGstxoSrExcC7ZaMutmBfqONeRNgoNVqW8/export?format=csv&range=A2:P";
    // 경험치 테이블 주소
    const string ExperienceDATA_URL = "https://docs.google.com/spreadsheets/d/1fc7zvkSFdMGstxoSrExcC7ZaMutmBfqONeRNgoNVqW8/export?format=csv&range=A2:C&gid=1728483937";
    //! 구글시트에 담긴 정보를 URL로 가져오는 함수
    public static IEnumerator InitItemData()
    {
        UnityWebRequest wwwItemDatas = UnityWebRequest.Get(ITEMDATA_URL);
        yield return wwwItemDatas.SendWebRequest();
        string itemDataBase = wwwItemDatas.downloadHandler.text;
        // URL로 가져온 구글시트의 아이템데이터를 파싱함
        List<string[]> itemDatas = CSVReader.CSVRead(itemDataBase);
        // 데이터매니저 itemDatas 변수에 파싱된 아이템리스트를 캐싱
        DataManager.Instance.itemDatas = itemDatas;
        //Debug.Log(itemDataBase);
        Debug.Log("데이터 불러오기 완료");
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
        //    Debug.Log($"키값 : {data.Key}, 벨류값 : {data.Value}");
        //}
    } // InitExperienceData
} // GoogleSheetManager
