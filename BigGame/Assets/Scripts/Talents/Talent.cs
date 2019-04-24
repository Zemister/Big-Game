using UnityEngine;

[CreateAssetMenu(menuName = "Talent")]
public class Talent : ScriptableObject
{ //add stats as needed
    public string talentName;

    public Sprite icon;

    public int health;
    public int mana;
    public int strength;
    public int defence;
    public int dexterity;
    public int wisdom;
    public int vitality;
    public int agility;

    public float healthPercent;
    public float manaPercent;
    public float strengthPercent;
    public float defencePercent;
    public float dexterityPercent;
    public float wisdomPercent;
    public float vitalityPercent;
    public float agilityPercent;
}
