using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveManager : MonoBehaviour
{
    private const string InventoryFileName = "Inventory";
    private const string EquipmentFileName = "Equipment";
    private string[] SlotFileName = { "Slot 0", "Slot 1", "Slot 2", "Slot 3" }; 

    public void SaveCharacter(Character c, int slot)
    {
        var saveData = new CharacterSaveData(c.PlayerLevel, c.PlayerExp, c.CharacterClass, c.CharacterSlot);

        CharacterSaveIO.SaveCharacter(saveData, SlotFileName[slot]);
    }

    public void LoadCharacter(Character c, int slot)
    {
        CharacterSaveData savedCharacter = CharacterSaveIO.LoadCharacter(SlotFileName[slot]);

        c.CharacterClass = savedCharacter.CharacterClass;
        c.PlayerLevel = savedCharacter.Level;
        c.PlayerExp = savedCharacter.Exp;
        c.CharacterSlot = savedCharacter.CharacterSlot;
    }
}



/*
public void LoadInventory(PlayerManager character)
{
    ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(InventoryFileName);
    if (savedSlots == null) return;

    character.Inventory.Clear();

    for(int i = 0; i < savedSlots.SavedSlots.Length; i++)
    {
        ItemSlot itemSlot = character.Inventory.ItemSlots[i];
        ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

        if (savedSlot == null)
        {
            itemSlot.Item = null;
            itemSlot.Amount = 0;
        } else
        {
            //itemSlot.Item = ;
            itemSlot.Amount = savedSlot.Amount;
        }
    }
}

public void LoadEquipment(PlayerManager character)
{
    ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(EquipmentFileName);
    if (savedSlots == null) return;

    foreach (ItemSlotSaveData savedSlot in savedSlots.SavedSlots)
    {
        if (savedSlot == null)
        {
            continue;
        }

        Item item = null;
        character.Inventory.AddItem(item);
        character.Equip((EquippableItem)item);
    }
}

public void SaveInventory(PlayerManager character)
{
    SaveItems(character.Inventory.ItemSlots, InventoryFileName);
}

public void SaveEquipment(PlayerManager character)
{
    SaveItems(character.Equipment.EquipmentSlots, EquipmentFileName);
}

private void SaveItems(IList<ItemSlot> itemSlots, string fileName)
{
    var saveData = new ItemContainerSaveData(itemSlots.Count);

    for (int i = 0; i < saveData.SavedSlots.Length; i++)
    {
        ItemSlot itemSlot = itemSlots[i];

        if (itemSlot.Item == null)
        {
            saveData.SavedSlots[i] = null;
        } else
        {
            saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID, itemSlot.Amount);
        }
    }

    ItemSaveIO.SaveItems(saveData, fileName);
}
*/
