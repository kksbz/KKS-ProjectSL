using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private GameObject fireEffect;
    public bool hasBonfire = false;
    public string bonfireName; // 화톳불 이름
    public Vector3 bonfirePos; // 화톳불 위치

    private void Start()
    {
        bonfirePos = transform.position;
    } // Start

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            UiManager.Instance.InteractionText.text = "화톳불 사용 : E 키";
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
                    // 화톳불을 처음 활성화시키면 화염이펙트 활성화
                    hasBonfire = true;
                    fireEffect.SetActive(true);
                    // 워프컨트롤러 화톳불리스트에 화톳불 추가 및 워프슬롯 생성
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
