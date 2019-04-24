using System;
using System.Text;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using CharacterStats;

public class TalentSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public Image image;

    public TalentSlot[] parentSlots;
    public TalentSlot[] childSlots;

    public event Action<TalentSlot> OnPointerEnterEvent;
    public event Action<TalentSlot> OnPointerExitEvent;
    public event Action<TalentSlot> OnLeftClickEvent;
    public event Action<TalentSlot> OnRightClickEvent;

    protected bool isPointerOver;

    public bool isStartingTalent;
    protected bool isSelected;
    public static bool talentEnabled;

    public string talentName;

    public Sprite icon;

    protected Color disabledColor = new Color(1, 1, 1, .2f);
    protected Color normalColor = new Color(1, 1, 1, .6f);
    protected Color selectedColor = Color.white;

    protected static readonly StringBuilder sb = new StringBuilder();

    public Talent _talent;
    public Talent Talent
    {
        get { return _talent; }
        set
        {
            _talent = value;

            image.sprite = _talent.icon;

            //if item cant be selected disabled color
            //if item can be selected normal color,
            //if item selected selected color

            if (isPointerOver)
            {
                OnPointerExit(null);
                OnPointerEnter(null);
            }
        }
    }

    private int _skillPoints;
    public int skillPoints
    {
        get { return _skillPoints; }
        set
        {
            //_skillPoints = Character level;
        }
    }

    void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();

        Talent = _talent;
    }

    public bool CanSelectTalent(TalentSlot talentSlot)
    {
        if(talentSlot.isStartingTalent)
        {
            return true;
        }

        for (int i = 0; parentSlots.Length > i; i++)
        {
            if (parentSlots[i].isSelected)
            {
                talentEnabled = true;
            } else
            {
                talentEnabled = false;
            }
        }

        return talentEnabled;
    }

    public bool CanRemoveTalent(TalentSlot talentSlot)
    {
        for (int i = 0; childSlots.Length > i; i++)
        {
            if (childSlots[i].isSelected)
                return false;
        }
        if(talentSlot.isSelected)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void AddTalent(Character c)
    {
        image.color = selectedColor;
        isSelected = true;
        if (Talent.health != 0)
            c.Health.AddModifier(new StatModifier(Talent.health, StatModType.Flat, this));
        if (Talent.mana != 0)
            c.Mana.AddModifier(new StatModifier(Talent.mana, StatModType.Flat, this));
        if (Talent.strength != 0)
            c.Strength.AddModifier(new StatModifier(Talent.strength, StatModType.Flat, this));
        if (Talent.defence != 0)
            c.Defence.AddModifier(new StatModifier(Talent.defence, StatModType.Flat, this));
        if (Talent.dexterity != 0)
            c.Dexterity.AddModifier(new StatModifier(Talent.dexterity, StatModType.Flat, this));
        if (Talent.wisdom != 0)
            c.Wisdom.AddModifier(new StatModifier(Talent.wisdom, StatModType.Flat, this));
        if (Talent.vitality != 0)
            c.Vitality.AddModifier(new StatModifier(Talent.vitality, StatModType.Flat, this));
        if (Talent.agility != 0)
            c.Agility.AddModifier(new StatModifier(Talent.agility, StatModType.Flat, this));

        if (Talent.healthPercent != 0)
            c.Health.AddModifier(new StatModifier(Talent.healthPercent, StatModType.PercentMult, this));
        if (Talent.manaPercent != 0)
            c.Mana.AddModifier(new StatModifier(Talent.manaPercent, StatModType.PercentMult, this));
        if (Talent.strengthPercent != 0)
            c.Strength.AddModifier(new StatModifier(Talent.strengthPercent, StatModType.PercentMult, this));
        if (Talent.defencePercent != 0)
            c.Defence.AddModifier(new StatModifier(Talent.defencePercent, StatModType.PercentMult, this));
        if (Talent.dexterityPercent != 0)
            c.Dexterity.AddModifier(new StatModifier(Talent.dexterityPercent, StatModType.PercentMult, this));
        if (Talent.wisdomPercent != 0)
            c.Wisdom.AddModifier(new StatModifier(Talent.wisdomPercent, StatModType.PercentMult, this));
        if (Talent.vitalityPercent != 0)
            c.Vitality.AddModifier(new StatModifier(Talent.vitalityPercent, StatModType.PercentMult, this));
        if (Talent.agilityPercent != 0)
            c.Agility.AddModifier(new StatModifier(Talent.agilityPercent, StatModType.PercentMult, this));
    }

    public void RemoveTalent(Character c)
    {
        image.color = normalColor;
        isSelected = false;

        c.Health.RemoveAllModifiersFromSource(this);
        c.Mana.RemoveAllModifiersFromSource(this);
        c.Defence.RemoveAllModifiersFromSource(this);
        c.Strength.RemoveAllModifiersFromSource(this);
        c.Dexterity.RemoveAllModifiersFromSource(this);
        c.Wisdom.RemoveAllModifiersFromSource(this);
        c.Vitality.RemoveAllModifiersFromSource(this);
        c.Agility.RemoveAllModifiersFromSource(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClickEvent != null)
                OnRightClickEvent(this);
        } else if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnLeftClickEvent != null)
                OnLeftClickEvent(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;

        if (OnPointerEnterEvent != null)
            OnPointerEnterEvent(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;

        if (OnPointerExitEvent != null)
            OnPointerExitEvent(this);
    }
}
