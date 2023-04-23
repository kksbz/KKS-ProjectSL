using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    [SerializeField] private GameObject fireEffect;
    public string bonfireName; // 화톳불 이름
    public BonfireData bonfireData; // 화톳불 데이터

    private void Start()
    {
        bonfireData = new BonfireData(false, bonfireName, transform.position);
    } // Start

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            UiManager.Instance.interactionText.text = "화톳불 사용 : E 키";
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
                    // 화톳불을 처음 활성화시키면 화염이펙트 활성화
                    bonfireData.hasBonfire = true;
                    fireEffect.SetActive(true);
                    // 워프컨트롤러 화톳불리스트에 화톳불 추가 및 워프슬롯 생성
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
