using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void Pickup()
    {
        Inventory.Instance.AddItem(item.itemData);
        Destroy(item.gameObject);
    } // Pickup

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            UiManager.Instance.interactionText.text = "æ∆¿Ã≈€ »πµÊ : E ≈∞";
            UiManager.Instance.interactionBar.SetActive(true);
        }
    } // OnTriggerEnter

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == GData.PLAYER_MARK)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
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
} // ItemPickup
