using UnityEngine;
using CharacterStats;

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
}

public enum ClassItem
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

[CreateAssetMenu]
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
    public int WeaponDamagePercentBonus;
    public float WeaponFireRate;
    public float WeaponRange;
    public float ProjectileSpeed;
    [Space]
    public EquipmentType EquipmentType;
    public ClassItem ClassItem;

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

        c.Health.RemoveAllModifiersFromSource(this);
        c.Mana.RemoveAllModifiersFromSource(this);
        c.Defence.RemoveAllModifiersFromSource(this);
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Dexterity.RemoveAllModifiersFromSource(this);
        c.Wisdom.RemoveAllModifiersFromSource(this);
        c.Vitality.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
    }
}
