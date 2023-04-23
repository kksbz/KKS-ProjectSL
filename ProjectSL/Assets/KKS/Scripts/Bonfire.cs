using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private GameObject fireEffect;
    public string bonfireName; // ȭ��� �̸�
    public BonfireData bonfireData; // ȭ��� ������

    private void Start()
    {
        bonfireData = new BonfireData(false, bonfireName, transform.position);
    } // Start

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            UiManager.Instance.interactionText.text = "ȭ��� ��� : E Ű";
            UiManager.Instance.interactionBar.SetActive(true);
        }
    } // OnTriggerEnter

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (bonfireData.hasBonfire == false)
                {
                    // ȭ����� ó�� Ȱ��ȭ��Ű�� ȭ������Ʈ Ȱ��ȭ
                    bonfireData.hasBonfire = true;
                    fireEffect.SetActive(true);
                    // ������Ʈ�ѷ� ȭ��Ҹ���Ʈ�� ȭ��� �߰� �� �������� ����
                    UiManager.Instance.warp.bonfireList.Add(bonfireData);
                    UiManager.Instance.warp.CreateWarpSlot(bonfireData);
                }
                UiManager.Instance.bonfirePanel.SetActive(true);
                UiManager.Instance.interactionBar.SetActive(false);
                UiManager.Instance.interactionText.text = null;
            }
        }
    } // OnTriggerStay

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            UiManager.Instance.interactionBar.SetActive(false);
            UiManager.Instance.interactionText.text = null;
        }
    } // OnTriggerExit
} // Bonfire
