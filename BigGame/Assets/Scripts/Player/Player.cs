using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;

    private int expToLevel;

    //Base values
    private int baseHealth, baseStrength, baseDexterity, baseDefence, baseAgility;

    //Additive values, skill points, gear, etc. (might change into statHealth and gearHealth or something later on will have to test and see)
    public int addHealth, addStrength, addDexterity, addDefence, addAgility;

    //CurentValues
    public int health, strength, dexterity, defence, agility;

    void Start()
    {
        //Call on the json or whichever file handles base values to assign these or xp or some shit who cares
        baseHealth = 20;
        baseStrength = 1;
        baseDexterity = 1;
        baseDefence = 1;
        baseAgility = 1;
        CurrentStats();
    }

    void Update()
    {
        CurrentStats();
    }

    public void CurrentStats()
    {
        health = baseHealth + addHealth;
        strength = baseStrength + addStrength;
        dexterity = baseDexterity + addDexterity;
        defence = baseDefence + addDefence;
        agility = baseAgility + addAgility;
    }

    public void LevelUp()
    {

    }

    public void SaveBaseStats()
    {

    }

    public void LoadBaseStats()
    {

    }
}
