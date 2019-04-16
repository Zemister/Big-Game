using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;

    public Transform slotIconGO;
    public Transform removeButton;

    void Start()
    {
        slotIconGO = transform.GetChild(0).GetChild(0);
        removeButton = transform.GetChild(1);
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
        slotIconGO.GetComponent<Image>().enabled = true;
        removeButton.GetComponent<Button>().interactable = true;
    }
}
