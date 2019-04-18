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

    private Transform slotIconGO;

    void Start()
    {
        slotIconGO = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
        slotIconGO.GetComponent<Image>().enabled = true;
    }
}
