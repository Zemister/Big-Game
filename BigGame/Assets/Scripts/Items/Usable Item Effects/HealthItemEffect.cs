using UnityEngine;

[CreateAssetMenu(menuName = "Item Effects/Heal")]
public class HealthItemEffect : UsableItemEffect
{
    public int HealthAmount;

    public override void ExecuteEffect(UsableItem parentItem, Character character)
    {
        character.Agility.BaseValue += HealthAmount;
        character.UpdateStatValues();
    }

    public override string GetDescription()
    {
        return "Heals for " + HealthAmount + " health.";
    }
}
