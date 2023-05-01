using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour
{
    [Header("������ ��ư ����")]
    [SerializeField] private Button plusBt; // �÷��� ��ư
    [SerializeField] private Button minusBt; // ���̳ʽ� ��ư
    [SerializeField] private Button decisionBt; // ���� ��ư
    [SerializeField] private Button vigorBt; // ����� ��ư
    [SerializeField] private Button attunementBt; // ���߷� ��ư
    [SerializeField] private Button enduranceBt; // ������ ��ư
    [SerializeField] private Button vitalityBt; // ü�� ��ư
    [SerializeField] private Button strengthBt; // �ٷ� ��ư
    [SerializeField] private Button dexterityBt; // �ⷮ ��ư
    [Header("������ �ؽ�Ʈ ����")]
    [SerializeField] private TMP_Text levelText; // ���� ���� �ؽ�Ʈ
    [SerializeField] private TMP_Text resultLevelText; // ��� ���� �ؽ�Ʈ
    [SerializeField] private TMP_Text soulText; // ���� �����ҿ� �ؽ�Ʈ
    [SerializeField] private TMP_Text resultSoulText; // ��� �����ҿ� �ؽ�Ʈ
    [SerializeField] private TMP_Text wantSoulText; // �ʿ��� �ҿ� �ؽ�Ʈ
    [SerializeField] private TMP_Text[] statusTexts; // ���� ���� �ؽ�Ʈ �迭
    [SerializeField] private TMP_Text[] resultStatusTexts; // ��� ���� �ؽ�Ʈ �迭
    private int selectNum; // ������ ���� ��ȣ
    void Start()
    {
        // �÷��� ��ư
        plusBt.onClick.AddListener(() =>
        {

        });

        // ���̳ʽ� ��ư
        minusBt.onClick.AddListener(() =>
        {

        });

        // ���� ��ư
        decisionBt.onClick.AddListener(() =>
        {

        });

        // ����� ��ư
        vigorBt.onClick.AddListener(() =>
        {

        });

        // ���߷� ��ư
        attunementBt.onClick.AddListener(() =>
        {

        });

        // ������ ��ư
        enduranceBt.onClick.AddListener(() =>
        {

        });

        // ü�� ��ư
        vitalityBt.onClick.AddListener(() =>
        {

        });

        // �ٷ� ��ư
        strengthBt.onClick.AddListener(() =>
        {

        });

        // �ⷮ ��ư
        dexterityBt.onClick.AddListener(() =>
        {

        });
    } // Start
} // LevelUpPanel
