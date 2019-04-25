using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;
    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
            equipmentSlots[i].OnPointerExitEvent += OnPointerExitEvent;
            equipmentSlots[i].OnRightClickEvent += OnRightClickEvent;
            equipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            equipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
            equipmentSlots[i].OnDragEvent += OnDragEvent;
            equipmentSlots[i].OnDropEvent += OnDropEvent;
        }
    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    //here will have to check if the equipment is usable by the class
    //check item.ClassEquipment and compare it to character.class or something
    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        if(item.EquipmentType == EquipmentType.Potion) //if the item is a potion
        {
            for (int i = 0; i < equipmentSlots.Length; i++) //run through all equipment slots
            {
                if (equipmentSlots[i].Item == null && equipmentSlots[i].EquipmentType == item.EquipmentType) //if the equipment slot is null
                {
                    previousItem = (EquippableItem)equipmentSlots[i].Item; //replace the previous item
                    equipmentSlots[i].Item = item; //this slot is = to the item
                    equipmentSlots[i].Amount = 1; //amount = 1
                    return true;
                }
            }
        }

        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                equipmentSlots[i].Amount = 1;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                equipmentSlots[i].Amount = 0;
                return true;
            }
        }
        return false;
    }
}
