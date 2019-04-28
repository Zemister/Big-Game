using System;

[Serializable]
public class CharacterSaveData //Specific character and its stats
{
    public int CharacterSlot;
    public int Level;
    public int Exp;
    public CharacterClass CharacterClass;

    public CharacterSaveData(int level, int exp, CharacterClass characterClass, int slot)
    {
        CharacterClass = characterClass;
        CharacterSlot = slot;
        Level = level;
        Exp = exp;
    }

}


[Serializable]
public class ItemSlotSaveData //Each Item Slots save data
{
    public string ItemID;
    public int Amount;

    public ItemSlotSaveData(string id, int amount)
    {
        ItemID = id;
        Amount = amount;
    }
}

[Serializable]
public class ItemContainerSaveData
{
    public ItemSlotSaveData[] SavedSlots;

    public ItemContainerSaveData(int numItems)
    {
        SavedSlots = new ItemSlotSaveData[numItems];
    }
}

