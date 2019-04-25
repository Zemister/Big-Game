using CharacterStats;
using System.Collections;
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chest,
    Weapon1,
    Weapon2,
    Gloves,
    Boots,
    Accessory1,
    Accessory2,
    Potion,
}

public enum Class
{
    class1,
    class2,
    class3,
    class4,
    class5,
    class6,
    noclass,
}

public enum Something
{
}

[CreateAssetMenu(menuName = "Items/Equippable Item")]
public class EquippableItem : Item
{
    public int HealthBonus;
    public int ManaBonus;
    public int DefenceBonus;
    public int StrengthBonus;
    public int DexterityBonus;
    public int WisdomBonus;
    public int VitalityBonus;
    public int AgilityBonus;

    [Space]
    public float HealthPercentBonus;

    public float ManaPercentBonus;
    public float DefencePercentBonus;
    public float StrengthPercentBonus;
    public float DexterityPercentBonus;
    public float WisdomPercentBonus;
    public float VitalityPercentBonus;
    public float AgilityPercentBonus;

    [Space]
    public int WeaponDamage;

    public float WeaponDamagePercentBonus;
    public float WeaponFireRate;
    public float WeaponRange;
    public float ProjectileSpeed;
    public Sprite ProjectileSprite;

    [Space]
    public float Cooldown;

    public float Duration;
    public bool canUse;
    public int Health;
    public int Mana;
    public int StrengthBuff;
    public int DefenceBuff;
    public int AgilityBuff;
    public int WisdomBuff;
    public int VitalityBuff;
    public int DexterityBuff;

    [Space]
    public EquipmentType EquipmentType;

    public Class ClassItem;

    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip(Character c)
    {
        if (WeaponDamage != 0)
            c.WeaponDamage.AddModifier(new StatModifier(WeaponDamage, StatModType.Flat, this));
        if (WeaponDamagePercentBonus != 0)
            c.WeaponDamage.AddModifier(new StatModifier(WeaponDamagePercentBonus, StatModType.PercentMult, this));
        if (WeaponFireRate != 0)
            c.WeaponFireRate.AddModifier(new StatModifier(WeaponFireRate, StatModType.Flat, this));
        if (WeaponRange != 0)
            c.WeaponRange.AddModifier(new StatModifier(WeaponRange, StatModType.Flat, this));
        if (ProjectileSpeed != 0)
            c.ProjectileSpeed.AddModifier(new StatModifier(ProjectileSpeed, StatModType.Flat, this));
        if (ProjectileSprite != null)
            c.ProjectileSprite = ProjectileSprite;

        if (HealthBonus != 0)
            c.Health.AddModifier(new StatModifier(HealthBonus, StatModType.Flat, this));
        if (ManaBonus != 0)
            c.Mana.AddModifier(new StatModifier(ManaBonus, StatModType.Flat, this));
        if (DefenceBonus != 0)
            c.Defence.AddModifier(new StatModifier(DefenceBonus, StatModType.Flat, this));
        if (StrengthBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthBonus, StatModType.Flat, this));
        if (DexterityBonus != 0)
            c.Dexterity.AddModifier(new StatModifier(DexterityBonus, StatModType.Flat, this));
        if (WisdomBonus != 0)
            c.Wisdom.AddModifier(new StatModifier(WisdomBonus, StatModType.Flat, this));
        if (VitalityBonus != 0)
            c.Vitality.AddModifier(new StatModifier(VitalityBonus, StatModType.Flat, this));
        if (AgilityBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityBonus, StatModType.Flat, this));

        if (HealthPercentBonus != 0)
            c.Health.AddModifier(new StatModifier(HealthPercentBonus, StatModType.PercentMult, this));
        if (ManaPercentBonus != 0)
            c.Mana.AddModifier(new StatModifier(ManaPercentBonus, StatModType.PercentMult, this));
        if (DefencePercentBonus != 0)
            c.Defence.AddModifier(new StatModifier(DefencePercentBonus, StatModType.PercentMult, this));
        if (StrengthPercentBonus != 0)
            c.Strength.AddModifier(new StatModifier(StrengthPercentBonus, StatModType.PercentMult, this));
        if (DexterityPercentBonus != 0)
            c.Dexterity.AddModifier(new StatModifier(DexterityPercentBonus, StatModType.PercentMult, this));
        if (WisdomPercentBonus != 0)
            c.Wisdom.AddModifier(new StatModifier(WisdomPercentBonus, StatModType.PercentMult, this));
        if (VitalityPercentBonus != 0)
            c.Vitality.AddModifier(new StatModifier(VitalityPercentBonus, StatModType.PercentMult, this));
        if (AgilityPercentBonus != 0)
            c.Agility.AddModifier(new StatModifier(AgilityPercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(Character c)
    {
        c.WeaponDamage.RemoveAllModifiersFromSource(this);
        c.WeaponFireRate.RemoveAllModifiersFromSource(this);
        c.WeaponRange.RemoveAllModifiersFromSource(this);
        c.ProjectileSpeed.RemoveAllModifiersFromSource(this);
        c.ProjectileSprite = null;

        c.Health.RemoveAllModifiersFromSource(this);
        c.Mana.RemoveAllModifiersFromSource(this);
        c.Defence.RemoveAllModifiersFromSource(this);
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Dexterity.RemoveAllModifiersFromSource(this);
        c.Wisdom.RemoveAllModifiersFromSource(this);
        c.Vitality.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
    }

    public virtual void Use(Character c)
    {
        StatModifier statStrengthModifier = new StatModifier(StrengthBuff, StatModType.Flat, this);
        c.Strength.AddModifier(statStrengthModifier);
        c.StartCoroutine(RemoveBuff(c, statStrengthModifier, Duration));
        StatModifier statDefenceModifier = new StatModifier(DefenceBuff, StatModType.Flat, this);
        c.Defence.AddModifier(statDefenceModifier);
        c.StartCoroutine(RemoveBuff(c, statDefenceModifier, Duration));

        c.UpdateStatValues();
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

    public override string GetItemType()
    {
        return EquipmentType.ToString();
    }

    public override string GetDescription()
    {
        sb.Length = 0;
        if (WeaponDamage != 0 || WeaponDamagePercentBonus != 0 || WeaponFireRate != 0)
        {
            AddStat(WeaponDamage, "Weapon Damage");
            AddStat(WeaponDamagePercentBonus, "Weapon Damage", isPercent: true);
            AddStat(WeaponFireRate, "Fire Rate", isPercent: true);
            AddStat(WeaponRange, "Range");
            sb.AppendLine();
        }

        AddStat(HealthBonus, "Health");
        AddStat(ManaBonus, "Mana");
        AddStat(DefenceBonus, "Defence");
        AddStat(StrengthBonus, "Strength");
        AddStat(DexterityBonus, "Dexterity");
        AddStat(WisdomBonus, "Wisdom");
        AddStat(VitalityBonus, "Vitality");
        AddStat(AgilityBonus, "Agility");

        AddStat(HealthPercentBonus, "Health", isPercent: true);
        AddStat(ManaPercentBonus, "Mana", isPercent: true);
        AddStat(DefencePercentBonus, "Defence", isPercent: true);
        AddStat(StrengthPercentBonus, "Strength", isPercent: true);
        AddStat(DexterityPercentBonus, "Dexterity", isPercent: true);
        AddStat(WisdomPercentBonus, "Wisdom", isPercent: true);
        AddStat(VitalityPercentBonus, "Vitality", isPercent: true);
        AddStat(AgilityPercentBonus, "Agility", isPercent: true);

        return sb.ToString();
    }

    private void AddStat(float value, string statName, bool isPercent = false)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();
            if (value > 0)
                sb.Append("+");
            if (isPercent)
            {
                sb.Append(value * 100);
                sb.Append("% ");
            }
            else
            {
                sb.Append(value);
                sb.Append(" ");
            }

            sb.Append(statName);
        }
    }
}