using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject playerLeftArm;
    public GameObject playerRightArm;
    public PlayerCharacter player;

    //! 현재 씬이 타이틀씬인지 아닌지 확인하는 함수
    public bool CheckActiveTitleScene()
    {
        return SceneManager.GetActiveScene().name != GData.SCENENAME_TITLE;
    } // CheckActiveTitleScene

    //! 화톳불 이용시 씬 로드하는 함수
    public void LoadBonfire(BonfireData bonfire)
    {
        StartCoroutine(LoadBonfireScene(bonfire));
    } // LoadBonfire

    //! 뉴게임 선택 시 씬 로드하는 함수
    public void NewGamePlay(int num)
    {
        StartCoroutine(NewGameLoadScene(num));
    } // NewGamePlay

    //! 세이브데이터 로드 시 해당 씬 로드하는 함수
    public void LoadSaveDataScene(int num)
    {
        StartCoroutine(LoadSaveDataPlayScene(num));
    } // LoadSaveDataScene

    //! 타이틀씬 불러오는 함수
    public void GoTitleScene()
    {
        StartCoroutine(LoadTitleScene());
    } // GoTitleScene

    //! 화톳불 이용 시 씬이동 코루틴함수
    private IEnumerator LoadBonfireScene(BonfireData bonfire)
    {
        // 자동저장 슬롯에 현재데이터 저장
        DataManager.Instance.slotNum = 0;
        DataManager.Instance.SaveData();
        // 로딩창 활성화
        UiManager.Instance.loadingPanel.gameObject.SetActive(true);
        float fadeTime = UiManager.Instance.loadingPanel.FadeInLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        var asyncLoad = SceneManager.LoadSceneAsync(GData.SCENENAME_PLAY);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        // 씬이 불러와지면 플레이어 데이터 로드
        DataManager.Instance.LoadData();
        player.transform.position = bonfire.bonfirePos;
        DataManager.Instance.SaveData();
        yield return new WaitForSeconds(3f);
        //Debug.Log($"씬로드 끝");
        UiManager.Instance.loadingPanel.FadeOutLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        // 로딩창 비활성화
        UiManager.Instance.loadingPanel.gameObject.SetActive(false);
    } // LoadScene

    //! 뉴게임 선택 시 씬이동 코루틴함수
    private IEnumerator NewGameLoadScene(int num)
    {
        // 로딩창 활성화
        UiManager.Instance.loadingPanel.gameObject.SetActive(true);
        float fadeTime = UiManager.Instance.loadingPanel.FadeInLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        var asyncLoad = SceneManager.LoadSceneAsync(GData.SCENENAME_PLAY);
        //Debug.Log($"씬로드 시작");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        //Debug.Log($"씬로드 끝");
        yield return new WaitForSeconds(3f);
        GameManager.Instance.player.PlayerNameSelect(DataManager.Instance.selectPlayerName);
        // 뉴게임 시작시 기본 무기, 방패, 회복약 가지고 시작
        ItemData hpPotion = new ItemData(DataManager.Instance.itemDatas[0]);
        hpPotion.Quantity = hpPotion.maxQuantity;
        ItemData mpPotion = new ItemData(DataManager.Instance.itemDatas[1]);
        mpPotion.Quantity = mpPotion.maxQuantity;
        ItemData weapon = new ItemData(DataManager.Instance.itemDatas[8]);
        ItemData shield = new ItemData(DataManager.Instance.itemDatas[4]);

        Inventory.Instance.AddItem(hpPotion);
        Inventory.Instance.AddItem(mpPotion);
        Inventory.Instance.AddItem(weapon);
        Inventory.Instance.AddItem(shield);
        DataManager.Instance.slotNum = num;
        DataManager.Instance.SaveData();
        UiManager.Instance.loadingPanel.FadeOutLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        // 로딩창 비활성화
        UiManager.Instance.loadingPanel.gameObject.SetActive(false);
    } // LoadScene

    //! 세이브데이터 불러와서 해당 데이터 플레이씬 불러오는 코루틴함수
    private IEnumerator LoadSaveDataPlayScene(int num)
    {
        // 로딩창 활성화
        UiManager.Instance.loadingPanel.gameObject.SetActive(true);
        float fadeTime = UiManager.Instance.loadingPanel.FadeInLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        var asyncLoad = SceneManager.LoadSceneAsync(GData.SCENENAME_PLAY);
        //Debug.Log($"씬로드 시작");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        //Debug.Log($"씬로드 끝");
        DataManager.Instance.slotNum = num;
        DataManager.Instance.LoadData();
        InitPlayer(DataManager.Instance.playerStatusSaveData);
        yield return new WaitForSeconds(3f);
        UiManager.Instance.loadingPanel.FadeOutLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        // 로딩창 비활성화
        UiManager.Instance.loadingPanel.gameObject.SetActive(false);
    } // LoadSaveDataPlayScene

    //! 플레이어 Dead상태에 따른 데이터 로드하는 함수
    public void InitPlayer(StatusSaveData _playerStatusData)
    {
        if (_playerStatusData._isPlayerDead == true)
        {
            // 플레이어가 죽었을 경우
            float neardistance = Mathf.Infinity;
            // 활성화 시킨 화톳불이 없을 경우 교회앞에서 부활
            Vector3 revivePos = new Vector3(74f, 9.287268f, -122f);

            // 죽은위치에서 활성화된 가장 가까운 화톳불의 위치에서 부활시킴
            for (int i = 0; i < UiManager.Instance.warp.bonfireList.Count; i++)
            {
                float _dis = Vector3.SqrMagnitude(_playerStatusData._playerPos - UiManager.Instance.warp.bonfireList[i].bonfirePos);
                if (_dis < neardistance)
                {
                    neardistance = _dis;
                    revivePos = UiManager.Instance.warp.bonfireList[i].bonfirePos;
                }
            }
            player.transform.position = revivePos;
            // 소울을 모두 잃고 죽은 위치에 가지고있던 소울을 드랍 시킴
            if (Inventory.Instance.Soul > 0)
            {
                GameObject Soul = Instantiate(Resources.Load<GameObject>("KKS/Prefabs/Objecct/DropSoul"));
                int _soul = Inventory.Instance.Soul;
                Soul.GetComponent<DropSoul>().souls = _soul;
                //Debug.Log($"잃어버린 소울 값 : {_soul} / {Inventory.Instance.Soul} / 실제 값 : {Soul.GetComponent<DropSoul>().souls}");
                UiManager.Instance.soulBag.GetSoul(-Inventory.Instance.Soul);
                Soul.transform.position = _playerStatusData._playerPos;
            }
            // 에스트병 보유횟수 초기화
            for (int i = 0; i < Inventory.Instance.inventory.Count; i++)
            {
                if (Inventory.Instance.inventory[i].itemID == 1)
                {
                    Inventory.Instance.inventory[i].Quantity = Inventory.Instance.inventory[i].maxQuantity;
                }
                if (Inventory.Instance.inventory[i].itemID == 2)
                {
                    Inventory.Instance.inventory[i].Quantity = Inventory.Instance.inventory[i].maxQuantity;
                    break;
                }
            }
        }
        else
        {
            // 플레이어가 살아있을 경우
            player.transform.position = _playerStatusData._playerPos;
            player.HealthSys.HP = _playerStatusData._currentHealthPoint;
            player.HealthSys.MP = _playerStatusData._currentManaPoint;
        }
    } // InitPlayer

    //! 타이틀씬 불러오는 코루틴함수
    private IEnumerator LoadTitleScene()
    {
        // 자동저장슬롯에 데이터 저장
        DataManager.Instance.slotNum = 0;
        DataManager.Instance.SaveData();
        UiManager.Instance.optionPanel.gameObject.SetActive(false);
        UiManager.Instance.loadingPanel.gameObject.SetActive(true);
        float fadeTime = UiManager.Instance.loadingPanel.FadeInLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        var asyncLoad = SceneManager.LoadSceneAsync(GData.SCENENAME_TITLE);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        UiManager.Instance.loadingPanel.FadeOutLoadingPanel();
        yield return new WaitForSeconds(fadeTime);
        UiManager.Instance.loadingPanel.gameObject.SetActive(false);
    } // GoTitleScene
} // GameManager
