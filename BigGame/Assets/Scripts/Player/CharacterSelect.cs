using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public string Slot;

    public void SelectSlot(string slot)
    {
        Slot = slot;
    }

    public void SelectClass(CharacterClass characterClass)
    {
        //CharacterClass = characterClass;
    }
}
