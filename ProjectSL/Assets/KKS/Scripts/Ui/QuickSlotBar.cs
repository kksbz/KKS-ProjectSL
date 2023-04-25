using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotBar : MonoBehaviour
{
    [SerializeField] private QuickSlot LeftArm; // �޼� ������
    [SerializeField] private QuickSlot RightArm; // ������ ������
    [SerializeField] private QuickSlot attackC; // ���ݿ� �Ҹ�ǰ ������
    [SerializeField] private QuickSlot recoveryC; // ȸ���� �Ҹ�ǰ ������
    [SerializeField] private List<WeaponSlot> LeftWeaponList; // �޼� ���� ����Ʈ
    [SerializeField] private List<WeaponSlot> RightWeaponList; // ������ ���� ����Ʈ
    [SerializeField] private List<ConsumptionSlot> AttackC_List; // ���ݿ� �Ҹ�ǰ ����Ʈ
    [SerializeField] private List<ConsumptionSlot> RecoveryC_List; // ȸ���� �Ҹ�ǰ ����Ʈ
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

    //! ������ ��� Ŀ���
    private void InPutQuickSlot()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            // ���콺 ���� ���� ��ũ������ �� ������ ���� ����
            if (scroll > 0f)
            {
                if (rightArmNum != -1)
                {
                    if (RightWeaponList[rightArmNum].Item != null)
                    {
                        // ���� ������ ������ ������Ʈ ��Ȱ��ȭ
                        RightWeaponList[rightArmNum].equipItem.SetActive(false);
                    }
                }
                // ������ ũ�⸦ ����� �ε��� �ʱ�ȭ
                if (rightArmNum == RightWeaponList.Count - 1)
                {
                    rightArmNum = -1;
                }
                rightArmNum++;
                RightArm.Item = RightWeaponList[rightArmNum].Item;

                // �����Կ� ���Ⱑ ���� ��
                if (RightWeaponList[rightArmNum].Item != null)
                {
                    // ���� ������Ʈ�� �÷��̾��� ���������� ��ġ �����ϰ� Ȱ��ȭ
                    RightWeaponList[rightArmNum].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                    RightWeaponList[rightArmNum].equipItem.transform.localPosition = Vector3.zero;
                    RightWeaponList[rightArmNum].equipItem.transform.localRotation = Quaternion.identity;
                    RightWeaponList[rightArmNum].equipItem.SetActive(true);
                    //Debug.Log($"����Ʈ+�پ� : {rightArmNum}");
                }
            }
            // ���콺 ���� �Ʒ��� ��ũ������ �� �޼� ���� ����
            else if (scroll < 0f)
            {
                if (leftArmNum != -1)
                {
                    if (LeftWeaponList[leftArmNum].Item != null)
                    {
                        // ���� ������ ������ ������Ʈ ��Ȱ��ȭ
                        LeftWeaponList[leftArmNum].equipItem.SetActive(false);
                    }
                }
                // ������ ũ�⸦ ����� �ε��� �ʱ�ȭ
                if (leftArmNum == LeftWeaponList.Count - 1)
                {
                    leftArmNum = -1;
                }
                leftArmNum++;
                LeftArm.Item = LeftWeaponList[leftArmNum].Item;

                // �����Կ� ���Ⱑ ���� ��
                if (LeftWeaponList[leftArmNum].Item != null)
                {
                    // ���� ������Ʈ�� �÷��̾��� ���������� ��ġ �����ϰ� Ȱ��ȭ
                    LeftWeaponList[leftArmNum].equipItem.transform.parent = GameManager.Instance.playerLeftArm.transform;
                    LeftWeaponList[leftArmNum].equipItem.transform.localPosition = Vector3.zero;
                    LeftWeaponList[leftArmNum].equipItem.transform.localRotation = Quaternion.identity;
                    LeftWeaponList[leftArmNum].equipItem.SetActive(true);
                    //Debug.Log($"����Ʈ+�ٴٿ� : {leftArmNum}");
                }
            }
        }
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            // ���콺 ���� ���� ��ũ������ �� ���ݿ� �Ҹ�ǰ ����
            if (scroll > 0f)
            {
                if (attackC_Num != -1)
                {
                    if (AttackC_List[attackC_Num].Item != null)
                    {
                        // ���� ������ ������ ������Ʈ ��Ȱ��ȭ
                        AttackC_List[attackC_Num].equipItem.SetActive(false);
                    }
                }
                // ������ ũ�⸦ ����� �ε��� �ʱ�ȭ
                if (attackC_Num == AttackC_List.Count - 1)
                {
                    attackC_Num = -1;
                }
                attackC_Num++;
                attackC.Item = AttackC_List[attackC_Num].Item;

                // �����Կ� ���ݿ� �Ҹ�ǰ�� ���� ��
                if (AttackC_List[attackC_Num].Item != null)
                {
                    // ���ݿ� �Ҹ�ǰ ������Ʈ�� �÷��̾��� ���������� ��ġ �����ϰ� Ȱ��ȭ
                    AttackC_List[attackC_Num].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                    AttackC_List[attackC_Num].equipItem.transform.localPosition = Vector3.zero;
                    AttackC_List[attackC_Num].equipItem.transform.localRotation = Quaternion.identity;
                    AttackC_List[attackC_Num].equipItem.SetActive(true);
                }
            }
            // ���콺 ���� �Ʒ��� ��ũ������ �� ȸ���� �Ҹ�ǰ ����
            else if (scroll < 0f)
            {
                if (recoveryC_Num != -1)
                {
                    if (RecoveryC_List[recoveryC_Num].Item != null)
                    {
                        // ���� ������ ������ ������Ʈ ��Ȱ��ȭ
                        RecoveryC_List[recoveryC_Num].equipItem.SetActive(false);
                    }
                }
                // ������ ũ�⸦ ����� �ε��� �ʱ�ȭ
                if (recoveryC_Num == RecoveryC_List.Count - 1)
                {
                    recoveryC_Num = -1;
                }
                recoveryC_Num++;
                recoveryC.Item = RecoveryC_List[recoveryC_Num].Item;

                // �����Կ� ȸ���� �Ҹ�ǰ�� ���� ��
                if (RecoveryC_List[recoveryC_Num].Item != null)
                {
                    // ȸ���� �Ҹ�ǰ ������Ʈ�� �÷��̾��� ���������� ��ġ �����ϰ� Ȱ��ȭ
                    RecoveryC_List[recoveryC_Num].equipItem.transform.parent = GameManager.Instance.playerRightArm.transform;
                    RecoveryC_List[recoveryC_Num].equipItem.transform.localPosition = Vector3.zero;
                    RecoveryC_List[recoveryC_Num].equipItem.transform.localRotation = Quaternion.identity;
                    RecoveryC_List[recoveryC_Num].equipItem.SetActive(true);
                }
            }
        }
    } // InPutQuickSlot

    //! ������ �ε�� ������ ������ �����ϴ� �Լ�
    public void InitQuickSlotData()
    {
        // ������ ���� ������ ����
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

        // �޼� ���� ������ ����
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

        // ���ݿ� �Ҹ�ǰ ������ ����
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

        // ȸ���� �Ҹ�ǰ ������ ����
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
