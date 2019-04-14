using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOpenClose : MonoBehaviour{

    public CanvasGroup inventoryPanel;
    private bool invOpenClosed;

    void start()
    {
        showInventory();
    }
    
    public void showInventory()
    {
        inventoryPanel.GetComponent<CanvasGroup>().alpha = 1f;
        inventoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        invOpenClosed = true;
    }

    public void hideInventory()
    {
        inventoryPanel.GetComponent<CanvasGroup>().alpha = 0f;
        inventoryPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        invOpenClosed = false;
    }

    private void OnMouseDown()
    {
        if (invOpenClosed)
        {
            hideInventory();
        } 
        if (!invOpenClosed)
        {
            showInventory();
        }
    }
}
