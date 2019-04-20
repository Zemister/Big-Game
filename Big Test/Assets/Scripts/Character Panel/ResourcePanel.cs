using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterStats;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] ResourceDisplay[] resourceDisplay;

    private CharacterStat[] stats;

    private void OnValidate()
    {
        resourceDisplay = GetComponentsInChildren<ResourceDisplay>();
        UpdateStatValues();
    }

    public void SetStats(params CharacterStat[] charStats)
    {
        stats = charStats;

        if (stats.Length > resourceDisplay.Length)
        {
            return;
        }

        for (int i = 0; i < resourceDisplay.Length; i++)
        {
            resourceDisplay[i].gameObject.SetActive(i < stats.Length);
        }
    }

    public void UpdateStatValues()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            resourceDisplay[i].healthSlider.maxValue = stats[i].Value;
        }
    }
}
