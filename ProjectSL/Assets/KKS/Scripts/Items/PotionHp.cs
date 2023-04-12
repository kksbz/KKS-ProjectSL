using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHp : MonoBehaviour
{
    [SerializeField] private ItemData potionData;
    // Start is called before the first frame update
    void Start()
    {
        potionData = ItemManager.Instance.items[0];
    }
} // PotionHp
