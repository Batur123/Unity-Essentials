using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySamples.Items;

public class InventoryToggle : MonoBehaviour
{
    /*
     * 
     * Action: Toggle Inventory
     * Usage: Press I to open/close inventory.
     * 
     */

 
    public GameObject inventoryPanel;

    void ToggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryPanel.activeSelf)
            {
             //    Cursor.visible = true;
                inventoryPanel.SetActive(true);
            }
            else
            {
              //  Cursor.visible = false;
                inventoryPanel.SetActive(false);
            }
        }
    }

    void Start()
    {
        inventoryPanel.SetActive(false);
    }
    void Update()
    {
        ToggleInventory();
    }
}
