using System.Collections;
using CharacterStats;
using UnityEngine;

[CreateAssetMenu(menuName = ("Item Effects/Stat Buff"))] //redoing pretty much whole itemeffect stuff
public class StatBuffItemEffect : UsableItemEffect
{
    public int StrengthBuff;
    public int DefenceBuff;
    public int AgilityBuff;
    public int WisdomBuff;
    public int VitalityBuff;
    public int DexterityBuff;

    public float Duration;

    public override void ExecuteEffect(UsableItem parentItem, Character character)
    {
        StatModifier statStrengthModifier = new StatModifier(StrengthBuff, StatModType.Flat, parentItem);
        character.Strength.AddModifier(statStrengthModifier);
        character.StartCoroutine(RemoveBuff(character, statStrengthModifier, Duration));
        StatModifier statDefenceModifier = new StatModifier(StrengthBuff, StatModType.Flat, parentItem);
        character.Defence.AddModifier(statDefenceModifier);
        character.StartCoroutine(RemoveBuff(character, statDefenceModifier, Duration));
        StatModifier statAgilityModifier = new StatModifier(StrengthBuff, StatModType.Flat, parentItem);
        character.Agility.AddModifier(statAgilityModifier);
        character.StartCoroutine(RemoveBuff(character, statAgilityModifier, Duration));
        StatModifier statWisdomModifier = new StatModifier(StrengthBuff, StatModType.Flat, parentItem);
        character.Wisdom.AddModifier(statWisdomModifier);
        character.StartCoroutine(RemoveBuff(character, statWisdomModifier, Duration));
        StatModifier statVitalityModifier = new StatModifier(StrengthBuff, StatModType.Flat, parentItem);
        character.Vitality.AddModifier(statVitalityModifier);
        character.StartCoroutine(RemoveBuff(character, statVitalityModifier, Duration));
        StatModifier statDexterityModifier = new StatModifier(StrengthBuff, StatModType.Flat, parentItem);
        character.Dexterity.AddModifier(statDexterityModifier);
        character.StartCoroutine(RemoveBuff(character, statDexterityModifier, Duration));

        character.UpdateStatValues();
    }

    public override string GetDescription()
    {
        return "Duration: " + Duration;
    }

    private static IEnumerator RemoveBuff(Character character, StatModifier statModifier, float duration)
    {
        yield return new WaitForSeconds(duration);
        character.Strength.RemoveModifier(statModifier);
        character.Defence.RemoveModifier(statModifier);
        character.Agility.RemoveModifier(statModifier);
        character.Wisdom.RemoveModifier(statModifier);
        character.Vitality.RemoveModifier(statModifier);
        character.Dexterity.RemoveModifier(statModifier);
        character.UpdateStatValues();
    }
}
