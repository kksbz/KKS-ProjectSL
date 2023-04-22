using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private GameObject fireEffect;
    public bool hasBonfire = false;
    public string bonfireName; // ȭ��� �̸�
    public Vector3 bonfirePos; // ȭ��� ��ġ

    private void Start()
    {
        bonfirePos = transform.position;
    } // Start

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            UiManager.Instance.InteractionText.text = "ȭ��� ��� : E Ű";
            UiManager.Instance.InteractionBar.SetActive(true);
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
                if (hasBonfire == false)
                {
                    // ȭ����� ó�� Ȱ��ȭ��Ű�� ȭ������Ʈ Ȱ��ȭ
                    hasBonfire = true;
                    fireEffect.SetActive(true);
                    // ������Ʈ�ѷ� ȭ��Ҹ���Ʈ�� ȭ��� �߰� �� �������� ����
                    UiManager.Instance.warp.bonfireList.Add(this);
                    UiManager.Instance.warp.CreateWarpSlot(this);
                }
                UiManager.Instance.bonfirePanel.SetActive(true);
                UiManager.Instance.InteractionBar.SetActive(false);
                UiManager.Instance.InteractionText.text = null;
            }
        }
    } // OnTriggerStay

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            UiManager.Instance.InteractionBar.SetActive(false);
            UiManager.Instance.InteractionText.text = null;
        }
    } // OnTriggerExit
} // Bonfire
