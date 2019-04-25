using System;
using UnityEngine;
using UnityEngine.UI;

public class PotionPanel : MonoBehaviour
{
    [SerializeField] Transform potionSlotParent;
    [SerializeField] PotionSlot[] potionSlot;

    public event Action<BaseItemSlot> OnClickEvent;

    private void OnValidate()
    {
        potionSlot = potionSlotParent.GetComponentsInChildren<PotionSlot>();
    }
    /*
    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
        }
    }
    */

    public void AddPotion(EquippableItem item, int slot)
    {
        
    }

    public void RemovePotion(int slot)
    {

    }
}
