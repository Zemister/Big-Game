using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CharacterStats;

public class StatsDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CharacterStat _stat;
    public CharacterStat Stat {
        get { return _stat; }
        set {
            _stat = value;
            UpdateStatValue();
        }
    }

    private string _name;
    public string Name {
        get { return _name; }
        set {
            _name = value;
            NameText.text = _name;
        }
    }

    [SerializeField] Text NameText;
    [SerializeField] Text TotalValueText;
    [SerializeField] StatToolTip tooltip;

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        NameText = texts[0];
        TotalValueText = texts[1];

        if (tooltip == null)
            tooltip = FindObjectOfType<StatToolTip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.ShowTooltip(Stat, Name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

    public void UpdateStatValue()
    {
        TotalValueText.text = _stat.Value.ToString();
    }
}
