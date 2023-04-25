using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotBar : MonoBehaviour
{
    [SerializeField] private QuickSlot LeftArm; // 왼손 퀵슬롯
    [SerializeField] private QuickSlot RightArm; // 오른손 퀵슬롯
    [SerializeField] private QuickSlot attackC; // 공격용 소모품 퀵슬롯
    [SerializeField] private QuickSlot recoveryC; // 회복용 소모품 퀵슬롯
    [SerializeField] private List<WeaponSlot> LeftWeaponList; // 왼손 무기 리스트
    [SerializeField] private List<WeaponSlot> RightWeaponList; // 오른손 무기 리스트
    [SerializeField] private List<ConsumptionSlot> AttackC_List; // 공격용 소모품 리스트
    [SerializeField] private List<ConsumptionSlot> RecoveryC_List; // 회복용 소모품 리스트
    public int leftArmNum = -1;
    public int rightArmNum = -1;
    public int attackC_Num = -1;
    public int recoveryC_Num = -1;
    // Start is called before the first frame update
    void Start()
    {
        RightWeaponList = Inventory.Instance.weaponSlotList.GetRange(0, 3);
        LeftWeaponList = Inventory.Instance.weaponSlotList.GetRange(3, 3);
        AttackC_List = Inventory.Instance.consumptionSlotList.GetRange(0, 3);
        RecoveryC_List = Inventory.Instance.consumptionSlotList.GetRange(3, 3);
        LeftArm.Item = null;
        RightArm.Item = null;
        attackC.Item = null;
        recoveryC.Item = null;
    } // Start

    // Update is called once per frame
    void Update()
    {
        InPutQuickSlot();
    } // Update

    //! 퀵슬롯 사용 커멘드
    private void InPutQuickSlot()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            // 마우스 휠을 위로 스크롤했을 때 오른손 무기 장착
            if (scroll > 0f)
            {
                if (rightArmNum != -1)
                {
                    if (RightWeaponList[rightArmNum].Item != null)
                    {
                        // 이전 슬롯의 아이템 오브젝트 비활성화
                        RightWeaponList[rightArmNum].equipItem.SetActive(false);
                    }
                }
                // 슬롯의 크기를 벗어나면 인덱스 초기화
                if (rightArmNum == RightWeaponList.Count - 1)
                {
                    rightArmNum = -1;
                }
                rightArmNum++;
                RightArm.Item = RightWeaponList[rightArmNum].Item;

                // 퀵슬롯에 무기가 있을 때
                if (RightWeaponList[rightArmNum].Item != null)
                {
                    // 무기 오브젝트를 플레이어의 오른손으로 위치 조정하고 활성화
                    RightWeaponList[rightArmNum].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                    RightWeaponList[rightArmNum].equipItem.transform.localPosition = Vector3.zero;
                    RightWeaponList[rightArmNum].equipItem.transform.localRotation = Quaternion.identity;
                    RightWeaponList[rightArmNum].equipItem.SetActive(true);
                    //Debug.Log($"쉬프트+휠업 : {rightArmNum}");
                }
            }
            // 마우스 휠을 아래로 스크롤했을 때 왼손 무기 장착
            else if (scroll < 0f)
            {
                if (leftArmNum != -1)
                {
                    if (LeftWeaponList[leftArmNum].Item != null)
                    {
                        // 이전 슬롯의 아이템 오브젝트 비활성화
                        LeftWeaponList[leftArmNum].equipItem.SetActive(false);
                    }
                }
                // 슬롯의 크기를 벗어나면 인덱스 초기화
                if (leftArmNum == LeftWeaponList.Count - 1)
                {
                    leftArmNum = -1;
                }
                leftArmNum++;
                LeftArm.Item = LeftWeaponList[leftArmNum].Item;

                // 퀵슬롯에 무기가 있을 때
                if (LeftWeaponList[leftArmNum].Item != null)
                {
                    // 무기 오브젝트를 플레이어의 오른손으로 위치 조정하고 활성화
                    LeftWeaponList[leftArmNum].equipItem.transform.parent = GameManager.Instance.playerLeftArm.transform;
                    LeftWeaponList[leftArmNum].equipItem.transform.localPosition = Vector3.zero;
                    LeftWeaponList[leftArmNum].equipItem.transform.localRotation = Quaternion.identity;
                    LeftWeaponList[leftArmNum].equipItem.SetActive(true);
                    //Debug.Log($"쉬프트+휠다운 : {leftArmNum}");
                }
            }
        }
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            // 마우스 휠을 위로 스크롤했을 때 공격용 소모품 장착
            if (scroll > 0f)
            {
                if (attackC_Num != -1)
                {
                    if (AttackC_List[attackC_Num].Item != null)
                    {
                        // 이전 슬롯의 아이템 오브젝트 비활성화
                        AttackC_List[attackC_Num].equipItem.SetActive(false);
                    }
                }
                // 슬롯의 크기를 벗어나면 인덱스 초기화
                if (attackC_Num == AttackC_List.Count - 1)
                {
                    attackC_Num = -1;
                }
                attackC_Num++;
                attackC.Item = AttackC_List[attackC_Num].Item;

                // 퀵슬롯에 공격용 소모품이 있을 때
                if (AttackC_List[attackC_Num].Item != null)
                {
                    // 공격용 소모품 오브젝트를 플레이어의 오른손으로 위치 조정하고 활성화
                    AttackC_List[attackC_Num].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                    AttackC_List[attackC_Num].equipItem.transform.localPosition = Vector3.zero;
                    AttackC_List[attackC_Num].equipItem.transform.localRotation = Quaternion.identity;
                    AttackC_List[attackC_Num].equipItem.SetActive(true);
                }
            }
            // 마우스 휠을 아래로 스크롤했을 때 회복용 소모품 장착
            else if (scroll < 0f)
            {
                if (recoveryC_Num != -1)
                {
                    if (RecoveryC_List[recoveryC_Num].Item != null)
                    {
                        // 이전 슬롯의 아이템 오브젝트 비활성화
                        RecoveryC_List[recoveryC_Num].equipItem.SetActive(false);
                    }
                }
                // 슬롯의 크기를 벗어나면 인덱스 초기화
                if (recoveryC_Num == RecoveryC_List.Count - 1)
                {
                    recoveryC_Num = -1;
                }
                recoveryC_Num++;
                recoveryC.Item = RecoveryC_List[recoveryC_Num].Item;

                // 퀵슬롯에 회복용 소모품이 있을 때
                if (RecoveryC_List[recoveryC_Num].Item != null)
                {
                    // 회복용 소모품 오브젝트를 플레이어의 오른손으로 위치 조정하고 활성화
                    RecoveryC_List[recoveryC_Num].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                    RecoveryC_List[recoveryC_Num].equipItem.transform.localPosition = Vector3.zero;
                    RecoveryC_List[recoveryC_Num].equipItem.transform.localRotation = Quaternion.identity;
                    RecoveryC_List[recoveryC_Num].equipItem.SetActive(true);
                }
            }
        }
    } // InPutQuickSlot

    //! 데이터 로드시 퀵슬롯 아이템 갱신하는 함수
    public void InitQuickSlotData()
    {
        // 오른손 무기 퀵슬롯 갱신
        if (rightArmNum != -1)
        {
            if (RightWeaponList[rightArmNum].Item != null)
            {
                RightArm.Item = RightWeaponList[rightArmNum].Item;
                RightWeaponList[rightArmNum].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                RightWeaponList[rightArmNum].equipItem.transform.localPosition = Vector3.zero;
                RightWeaponList[rightArmNum].equipItem.transform.localRotation = Quaternion.identity;
                RightWeaponList[rightArmNum].equipItem.SetActive(true);
            }
        }

        // 왼손 무기 퀵슬롯 갱신
        if (leftArmNum != -1)
        {
            if (LeftWeaponList[leftArmNum].Item != null)
            {
                LeftArm.Item = LeftWeaponList[leftArmNum].Item;
                LeftWeaponList[leftArmNum].equipItem.transform.parent = GameManager.Instance.playerLeftArm.transform;
                LeftWeaponList[leftArmNum].equipItem.transform.localPosition = Vector3.zero;
                LeftWeaponList[leftArmNum].equipItem.transform.localRotation = Quaternion.identity;
                LeftWeaponList[leftArmNum].equipItem.SetActive(true);
            }
        }

        // 공격용 소모품 퀵슬롯 갱신
        if (attackC_Num != -1)
        {
            if (AttackC_List[attackC_Num].Item != null)
            {
                attackC.Item = AttackC_List[attackC_Num].Item;
                AttackC_List[attackC_Num].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                AttackC_List[attackC_Num].equipItem.transform.localPosition = Vector3.zero;
                AttackC_List[attackC_Num].equipItem.transform.localRotation = Quaternion.identity;
            }
        }

        // 회복용 소모품 퀵슬롯 갱신
        if (recoveryC_Num != -1)
        {
            if (RecoveryC_List[recoveryC_Num].Item != null)
            {
                recoveryC.Item = RecoveryC_List[recoveryC_Num].Item;
                RecoveryC_List[recoveryC_Num].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                RecoveryC_List[recoveryC_Num].equipItem.transform.localPosition = Vector3.zero;
                RecoveryC_List[recoveryC_Num].equipItem.transform.localRotation = Quaternion.identity;
            }
        }
    } // InitQuickSlotData
} // QuickSlotBar
