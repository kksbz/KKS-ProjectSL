using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] List<Sprite> panelSprites; // 패널스프라이트 리스트
    [SerializeField] private Image panelImage; // 패널이미지
    [SerializeField] private TMP_Text panelText; // 패널텍스트
    [SerializeField] private SaveAndLoadPanel saveAndLoadPanel; // 저장 및 불러오기 패널
    [SerializeField] private GameObject checkPanel; // 선택창패널
    [SerializeField] private GameObject manualPanel;
    [SerializeField] private TMP_Text checkText; // 선택창에 표시될 텍스트
    [SerializeField] private Button checkPanelSelectBt; // 선택창패널 선택버튼
    [SerializeField] private Button checkPanelCancleBt; // 선택창패널 취소버튼
    [SerializeField] private Button goTitleBt; // 타이틀로 가기 버튼
    [SerializeField] private Button OptionBt; // 옵션 버튼
    [SerializeField] private Button SaveBt; // 저장 버튼
    [SerializeField] private Button LoadBt; // 불러오기 버튼
    [SerializeField] private Button ExitBt; // 나가기 버튼
    public GameObject goBackText; // 뒤로가기 텍스트
    private bool isExitGame = false;

    private void Start()
    {
        // 타이틀씬으로 가기
        goTitleBt.onClick.AddListener(() =>
        {
            checkText.text = "타이틀화면으로 돌아가시겠습니까?";
            isExitGame = false;
            checkPanel.SetActive(true);
        });
        // 게임종료
        ExitBt.onClick.AddListener(() =>
        {
            checkText.text = "게임을 종료하시겠습니까?";
            isExitGame = true;
            checkPanel.SetActive(true);
        });
        // 옵션
        OptionBt.onClick.AddListener(() =>
        {
            panelImage.sprite = panelSprites[1];
            panelText.text = "설정";
            manualPanel.SetActive(true);
            goBackText.SetActive(true);
        });
        // 저장하기
        SaveBt.onClick.AddListener(() =>
        {
            panelImage.sprite = panelSprites[2];
            panelText.text = "저장하기";
            saveAndLoadPanel.isSave = true;
            saveAndLoadPanel.gameObject.SetActive(true);
            goBackText.SetActive(true);
        });
        // 불러오기
        LoadBt.onClick.AddListener(() =>
        {
            panelImage.sprite = panelSprites[3];
            panelText.text = "불러오기";
            saveAndLoadPanel.isSave = false;
            saveAndLoadPanel.gameObject.SetActive(true);
            goBackText.SetActive(true);
        });

        // 선택창패널 선택버튼
        checkPanelSelectBt.onClick.AddListener(() =>
        {
            if (isExitGame == true)
            {
                // 게임종료 선택창일 경우 자동저장슬롯에 데이터저장 후 종료
                DataManager.Instance.slotNum = 0;
                DataManager.Instance.SaveData();
                Application.Quit();
                //UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                // 게임종료 선택창이 아닐 경우 타이틀씬으로 이동
                checkPanel.SetActive(false);
                GameManager.Instance.GoTitleScene();
            }
        });
        // 선택창패널 취소버튼
        checkPanelCancleBt.onClick.AddListener(() =>
        {
            checkPanel.SetActive(false);
        });
    } // Start

    private void OnEnable()
    {
        panelImage.sprite = panelSprites[0];
        panelText.text = "설정";
        goBackText.SetActive(false);
        manualPanel.SetActive(false);
        saveAndLoadPanel.gameObject.SetActive(false);
    } // OnEnable

    private void Update()
    {
        if (goBackText.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                saveAndLoadPanel.gameObject.SetActive(false);
                manualPanel.SetActive(false);
                panelImage.sprite = panelSprites[0];
                panelText.text = "설정";
                goBackText.SetActive(false);
            }
        }
    } // Update
} // OptionPanel
