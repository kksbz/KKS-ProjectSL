using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotBar : MonoBehaviour
{
    [SerializeField] private QuickSlot leftArm; // 왼손 퀵슬롯
    [SerializeField] private QuickSlot rightArm; // 오른손 퀵슬롯
    [SerializeField] private QuickSlot attackC; // 공격소모품 퀵슬롯
    [SerializeField] private QuickSlot recoveryC; // 회복소모품 퀵슬롯
    [SerializeField] private List<WeaponSlot> leftWeaponList; // 왼손 무기슬롯
    [SerializeField] private List<WeaponSlot> rightWeaponList; // 오른손 무기슬롯
    [SerializeField] private List<ConsumptionSlot> attackC_List; // 공격소모품 슬롯
    [SerializeField] private List<ConsumptionSlot> recoveryC_List; // 회복소모품 슬롯
    public int leftArmNum = 0;
    public int rightArmNum = 0;
    public int attackC_Num = 0;
    public int recoveryC_Num = 0;

    // { Property
    public ItemData QuickSlotRightWeapon { get { return rightArm.Item; } }
    public ItemData QuickSlotLeftWeapon { get { return leftArm.Item; } }
    public ItemData QuickSlotAttackConsumption { get { return attackC.Item; } }
    public ItemData QuickSlotRecoveryConsumption { get { return recoveryC.Item; } }
    // } Property
    public GameObject GetCurrentRightWeaponObject { get { return rightWeaponList[rightArmNum].equipItem; } }
    public GameObject GetCurrentLeftWeaponObject { get { return leftWeaponList[leftArmNum].equipItem; } }
    public GameObject GetCurrentAttackConsumptionObject { get { return attackC_List[attackC_Num].equipItem; } }
    public GameObject GetCurrentRecoveryConsumptionObject { get { return recoveryC_List[recoveryC_Num].equipItem; } }

    public List<WeaponSlot> LeftWeaponList { get { return leftWeaponList; } }
    public List<WeaponSlot> RightWeaponList { get { return rightWeaponList; } }
    //

    // Start is called before the first frame update
    void Start()
    {
        rightWeaponList = Inventory.Instance.weaponSlotList.GetRange(0, 3);
        leftWeaponList = Inventory.Instance.weaponSlotList.GetRange(3, 3);
        attackC_List = Inventory.Instance.consumptionSlotList.GetRange(0, 3);
        recoveryC_List = Inventory.Instance.consumptionSlotList.GetRange(3, 3);
        leftArm.Item = null;
        rightArm.Item = null;
        attackC.Item = null;
        recoveryC.Item = null;
    } // Start

    // Update is called once per frame
    void Update()
    {
        InPutQuickSlot();
    } // Update

    //! 퀵슬롯 단축키
    private void InPutQuickSlot()
    {
        if (GameManager.Instance.CheckActiveTitleScene() == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                // 쉬프트 + 마우스휠업
                if (scroll > 0f)
                {
                    if (rightWeaponList[rightArmNum].Item != null)
                    {
                        // 이전 오른손 퀵슬롯의 아이템 비활성화
                        rightWeaponList[rightArmNum].equipItem.SetActive(false);
                    }
                    // 오른손 퀵슬롯 번호 초기화
                    if (rightArmNum == rightWeaponList.Count - 1)
                    {
                        rightArmNum = -1;
                    }
                    rightArmNum++;
                    rightArm.Item = rightWeaponList[rightArmNum].Item;
                    Inventory.Instance._onEquipSlotUpdated();
                    // 선택한 오른손 퀵슬롯의 아이템이 존재할때
                    if (rightWeaponList[rightArmNum].Item != null)
                    {
                        // 오른손 퀵슬롯의 아이템 활성화
                        rightWeaponList[rightArmNum].equipItem.SetActive(true);
                        //Debug.Log($"선택한 오른손 퀵슬롯 번호 : {rightArmNum}");
                    }
                }
                // 쉬프트 + 마우스휠다운
                else if (scroll < 0f)
                {
                    if (leftWeaponList[leftArmNum].Item != null)
                    {
                        // 이전 왼손 퀵슬롯의 아이템 비활성화
                        leftWeaponList[leftArmNum].equipItem.SetActive(false);
                    }
                    // 왼손 퀵슬롯 번호 초기화
                    if (leftArmNum == leftWeaponList.Count - 1)
                    {
                        leftArmNum = -1;
                    }
                    leftArmNum++;
                    leftArm.Item = leftWeaponList[leftArmNum].Item;
                    Inventory.Instance._onEquipSlotUpdated();
                    // 선택한 왼손 퀵슬롯의 아이템이 존재할때
                    if (leftWeaponList[leftArmNum].Item != null)
                    {
                        // 왼손 퀵슬롯의 아이템 활성화
                        leftWeaponList[leftArmNum].equipItem.SetActive(true);
                        //Debug.Log($"선택한 왼손 퀵슬롯 번호: {leftArmNum}");
                    }
                }
            }
            else
            {
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                // 마우스휠업
                if (scroll > 0f)
                {
                    if (attackC_List[attackC_Num].Item != null)
                    {
                        // 이전 공격소모품 퀵슬롯의 아이템 비활성화
                        attackC_List[attackC_Num].equipItem.SetActive(false);
                    }
                    // 공격소모품 퀵슬롯 번호 초기화
                    if (attackC_Num == attackC_List.Count - 1)
                    {
                        attackC_Num = -1;
                    }
                    attackC_Num++;
                    attackC.Item = attackC_List[attackC_Num].Item;
                    Inventory.Instance._onEquipSlotUpdated();
                    // 선택한 공격소모품 퀵슬롯의 아이템이 존재할때
                    if (attackC_List[attackC_Num].Item != null)
                    {
                        //attackC_List[attackC_Num].equipItem.SetActive(true);
                    }
                }
                // 마우스휠다운
                else if (scroll < 0f)
                {
                    if (recoveryC_List[recoveryC_Num].Item != null)
                    {
                        // 이전 회복소모품 퀵슬롯의 아이템 비활성화
                        recoveryC_List[recoveryC_Num].equipItem.SetActive(false);
                    }
                    // 회복소모품 퀵슬롯 번호 초기화
                    if (recoveryC_Num == recoveryC_List.Count - 1)
                    {
                        recoveryC_Num = -1;
                    }
                    recoveryC_Num++;
                    recoveryC.Item = recoveryC_List[recoveryC_Num].Item;
                    Inventory.Instance._onEquipSlotUpdated();
                    // 선택한 회복소모품 퀵슬롯의 아이템이 존재할때
                    if (recoveryC_List[recoveryC_Num].Item != null)
                    {
                        //recoveryC_List[recoveryC_Num].equipItem.SetActive(true);
                    }
                }
            }
        }
    } // InPutQuickSlot

    //! 세이브데이터 로드시 퀵슬롯정보 가져오는 함수
    public void LoadQuickSlotData()
    {
        // 오른손 퀵슬롯의 아이템이 존재할때
        if (rightWeaponList[rightArmNum].Item != null && rightWeaponList[rightArmNum].equipItem != null)
        {
            rightArm.Item = rightWeaponList[rightArmNum].Item;
            rightWeaponList[rightArmNum].equipItem.SetActive(true);
        }
        else
        {
            rightArm.Item = null;
        }

        // 왼손 퀵슬롯의 아이템이 존재할때
        if (leftWeaponList[leftArmNum].Item != null && leftWeaponList[leftArmNum].equipItem != null)
        {
            leftArm.Item = leftWeaponList[leftArmNum].Item;
            leftWeaponList[leftArmNum].equipItem.SetActive(true);
        }
        else
        {
            leftArm.Item = null;
        }

        // 공격소모품 퀵슬롯의 아이템이 존재할때
        if (attackC_List[attackC_Num].Item != null && attackC_List[attackC_Num].equipItem != null)
        {
            attackC.Item = attackC_List[attackC_Num].Item;
        }
        else
        {
            attackC.Item = null;
        }

        // 회복소모품 퀵슬롯의 아이템이 존재할때
        if (recoveryC_List[recoveryC_Num].Item != null && recoveryC_List[recoveryC_Num].equipItem != null)
        {
            recoveryC.Item = recoveryC_List[recoveryC_Num].Item;
        }
        else
        {
            recoveryC.Item = null;
        }
        Inventory.Instance._onEquipSlotUpdated();
    } // LoadQuickSlotData
} // QuickSlotBar
