using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static bool UIExists;

    //Inventory inventory;

    void Start()
    {
        //inventory = Inventory.instance;
        //inventory.onItemChangedCallback += UpdateUI;
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI ()
    {
        Debug.Log("UPDATING UI");
    }
}
