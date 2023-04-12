using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Button button;
    [SerializeField] private GameObject itemIcon;
    private Sprite icon; // 슬롯에 표시될 icon
    private Item item; // 슬롯에 담길 아이템 변수

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        icon = itemIcon.GetComponent<Sprite>();
        button.onClick.AddListener(() => Debug.Log("버튼 클릭함"));
    } // Start
} // Slot
