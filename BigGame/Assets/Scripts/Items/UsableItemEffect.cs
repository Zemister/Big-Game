using UnityEngine;

public abstract class UsableItemEffect : ScriptableObject
{
    public abstract void ExecuteEffect(EquippableItem parentItem, Character character);
}
