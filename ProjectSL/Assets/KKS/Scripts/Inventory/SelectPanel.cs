using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : MonoBehaviour
{
    public Button selectBt;
    public Button clearBt;
    public Button cancelBt;

    void Start()
    {
        selectBt.onClick.AddListener(() =>
        {

        });

        clearBt.onClick.AddListener(() =>
        {

        });

        cancelBt.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
    } // Start
} // SelectPanel
