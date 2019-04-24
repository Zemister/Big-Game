﻿using System.Text;
using UnityEngine;
using UnityEngine.UI;
using CharacterStats;

public class StatToolTip : MonoBehaviour
{
    [SerializeField] Text StatNameText;
    [SerializeField] Text StatModifiersLabelText;
    [SerializeField] Text StatModifiersText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(CharacterStat stat, string statName)
    {
        StatNameText.text = GetStatTopText(stat, statName);

        StatModifiersText.text = GetStatModifiersText(stat);
        
        gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private string GetStatTopText(CharacterStat stat, string statName)
    {
        sb.Length = 0;
        sb.Append(statName);
        sb.Append(" ");
        sb.Append(stat.Value);

        if (stat.Value != stat.BaseValue)
        {
            sb.Append(" (");
            sb.Append(stat.BaseValue);
            if (stat.Value > stat.BaseValue)
                sb.Append("+");
            sb.Append(System.Math.Round(stat.Value - stat.BaseValue, 4));
            sb.Append(")");
        }
        return sb.ToString();
    }

    private string GetStatModifiersText(CharacterStat stat)
    {
        sb.Length = 0;

        //right now talents display seperately need to make them display together, look at getDescription in items
        foreach (StatModifier mod in stat.StatModifiers)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (mod.Value > 0)
                sb.Append("+");

            if (mod.Type == StatModType.Flat)
            {
                sb.Append(mod.Value);
            } else
            {
                sb.Append(mod.Value * 100);
                sb.Append("%");
            }

            Item item = mod.Source as Item;

            if (item != null)
            {
                sb.Append(" ");
                sb.Append(item.itemName);
            }

            TalentSlot talent = mod.Source as TalentSlot;

            if (talent != null)
            {
                sb.Append(" ");
                sb.Append(talent.Talent.talentName);
                sb.Append(" Talent ");
            }
        }
        return sb.ToString();
    }
}
