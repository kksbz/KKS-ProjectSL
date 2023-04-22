using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    public GameObject optionBar; // 옵션바
    public GameObject bonfirePanel; // 화톳불 패널
    public GameObject InteractionBar; // 상호작용 오브젝트
    public TMP_Text InteractionText; // 상호작용 텍스트
    public WarpController warp; // 화톳불 워프 컨트롤러
} // UiManager

