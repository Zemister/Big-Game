using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Items/Usable Item")]
public class UsableItem : Item
{
    public bool IsConsumable;

    public List<UsableItemEffect> Effects;

    public virtual void Use(Character character)
    {
        foreach (UsableItemEffect effect in Effects)
        {
            effect.ExecuteEffect(this, character);
        }
    }
}
