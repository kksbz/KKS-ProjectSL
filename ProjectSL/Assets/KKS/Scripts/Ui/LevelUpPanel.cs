using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{
    [Header("레벨업 버튼 모음")]
    [SerializeField] private Button plusBt; // 플러스 버튼
    [SerializeField] private Button minusBt; // 마이너스 버튼
    [SerializeField] private Button decisionBt; // 결정 버튼
    [SerializeField] private Button vigorBt; // 생명력 버튼
    [SerializeField] private Button attunementBt; // 집중력 버튼
    [SerializeField] private Button enduranceBt; // 지구력 버튼
    [SerializeField] private Button vitalityBt; // 체력 버튼
    [SerializeField] private Button strengthBt; // 근력 버튼
    [SerializeField] private Button dexterityBt; // 기량 버튼
    [Header("레벨업 텍스트 모음")]
    [SerializeField] private TMP_Text levelText; // 현재 레벨 텍스트
    [SerializeField] private TMP_Text resultLevelText; // 결과 레벨 텍스트
    [SerializeField] private TMP_Text soulText; // 현재 보유소울 텍스트
    [SerializeField] private TMP_Text resultSoulText; // 결과 보유소울 텍스트
    [SerializeField] private TMP_Text wantSoulText; // 필요한 소울 텍스트
    [SerializeField] private TMP_Text[] statusTexts; // 현재 스텟 텍스트 배열
    [SerializeField] private TMP_Text[] resultStatusTexts; // 결과 스텟 텍스트 배열
    private int selectNum; // 선택한 스텟 번호
    void Start()
    {
        // 플러스 버튼
        plusBt.onClick.AddListener(() =>
        {

        });

        // 마이너스 버튼
        minusBt.onClick.AddListener(() =>
        {

        });

        // 결정 버튼
        decisionBt.onClick.AddListener(() =>
        {

        });

        // 생명력 버튼
        vigorBt.onClick.AddListener(() =>
        {

        });

        // 집중력 버튼
        attunementBt.onClick.AddListener(() =>
        {

        });

        // 지구력 버튼
        enduranceBt.onClick.AddListener(() =>
        {

        });

        // 체력 버튼
        vitalityBt.onClick.AddListener(() =>
        {

        });

        // 근력 버튼
        strengthBt.onClick.AddListener(() =>
        {

        });

        // 기량 버튼
        dexterityBt.onClick.AddListener(() =>
        {

        });
    } // Start
} // LevelUpPanel
