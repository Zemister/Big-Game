using UnityEngine;
using CharacterStats;

public class StatPanel : MonoBehaviour
{
    [SerializeField] StatsDisplay[] statsDisplay;
    [SerializeField] string[] statNames;

    private CharacterStat[] stats;

    private void OnValidate()
    {
        statsDisplay = GetComponentsInChildren<StatsDisplay>();
        UpdateStatNames();
    }

    public void SetStats(params CharacterStat[] charStats)
    {
        stats = charStats;

        if (stats.Length > statsDisplay.Length)
        {
            return;
        }

        for (int i = 0; i < statsDisplay.Length; i++)
        {
            statsDisplay[i].gameObject.SetActive(i < stats.Length);

            if (i < stats.Length)
            {
                statsDisplay[i].Stat = stats[i];
            }
        }
    }

    public void UpdateStatValues()
    {
        for (int i = 0; i < stats.Length; i++)
        {
            statsDisplay[i].UpdateStatValue();
        }
    }

    public void UpdateStatNames()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            statsDisplay[i].Name = statNames[i];
        }
    }
}
