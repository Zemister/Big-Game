using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    //json stuff
    private string path;
    private string jsonString;

    void Start()
    {
        baseHealth = 20;
        baseStrength = 1;
        baseDexterity = 1;
        baseDefence = 1;
        baseAgility = 1;
        LoadPlayerData();
        CurrentStats();
    }

    void Update()
    {
        CurrentStats();
    }

    void LoadPlayerData()
    {
        path = Application.streamingAssetsPath + "/playerData.json";
        jsonString = File.ReadAllText(path);
        PlayerData player = JsonUtility.FromJson<PlayerData>(jsonString);
        string newPlayer = JsonUtility.ToJson(player);
        Debug.Log(newPlayer);

        baseHealth = 20;
        baseStrength = 1;
        baseDexterity = 1;
        baseDefence = 1;
        baseAgility = 1;
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

 [System.Serializable]
public class PlayerData
{
    public string Name;
    public int Level;
    public int Strength;
    public int Health;
}
