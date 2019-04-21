using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ItemToolTip : MonoBehaviour
{
    [SerializeField] Text ItemNameText;
    [SerializeField] Text ItemSlotText;
    [SerializeField] Text ItemStatsText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(EquippableItem item)
    {
        ItemNameText.text = item.itemName;
        ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0;
        if(item.WeaponDamage != 0 || item.WeaponDamagePercentBonus != 0 || item.WeaponFireRate != 0)
        {
            AddStat(item.WeaponDamage, "Weapon Damage");
            AddStat(item.WeaponDamagePercentBonus, "Weapon Damage", isPercent: true);
            AddStat(item.WeaponFireRate, "Fire Rate", isPercent: true);
            AddStat(item.WeaponRange, "Range");
            sb.AppendLine();
        }

        AddStat(item.HealthBonus, "Health");
        AddStat(item.ManaBonus, "Mana");
        AddStat(item.DefenceBonus, "Defence");
        AddStat(item.StrengthBonus, "Strength");
        AddStat(item.DexterityBonus , "Dexterity");
        AddStat(item.WisdomBonus, "Wisdom");
        AddStat(item.VitalityBonus, "Vitality");
        AddStat(item.AgilityBonus, "Agility");

        AddStat(item.HealthPercentBonus, "Health", isPercent: true);
        AddStat(item.ManaPercentBonus, "Mana", isPercent: true);
        AddStat(item.DefencePercentBonus, "Defence", isPercent: true);
        AddStat(item.StrengthPercentBonus, "Strength", isPercent: true);
        AddStat(item.DexterityPercentBonus, "Dexterity", isPercent: true);
        AddStat(item.WisdomPercentBonus, "Wisdom", isPercent: true);
        AddStat(item.VitalityPercentBonus, "Vitality", isPercent: true);
        AddStat(item.AgilityPercentBonus, "Agility", isPercent: true);

        ItemStatsText.text = sb.ToString();

        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
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
            } else
            {
                sb.Append(value);
                sb.Append(" ");
            }

            sb.Append(statName);
        }
    }
}
