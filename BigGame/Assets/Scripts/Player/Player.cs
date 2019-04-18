using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;

    private int expToLevel;

    public string playerName;

    //Base values
    private int baseHealth, baseStrength, baseDexterity, baseDefence, baseAgility;

    //Additive values, skill points, gear, etc. (might change into statHealth and gearHealth or something later on will have to test and see)
    public int addHealth, addStrength, addDexterity, addDefence, addAgility;

    //CurentValues
    public int health, strength, dexterity, defence, agility;

    //json stuff
    private string path;
    private string jsonString;
    PlayerData playerCharacter;

    void Start()
    {
        path = Application.streamingAssetsPath + "/playerData.json";
        jsonString = File.ReadAllText(path);
        playerCharacter = JsonUtility.FromJson<PlayerData>(jsonString);

        LoadPlayerData();
        CurrentStats();
    }

    void Update()
    {
        CurrentStats();
        if (Input.GetKeyDown(KeyCode.O))
        {
            SavePlayerData();
        }
    }

    void LoadPlayerData()
    {
        playerName = playerCharacter.Name;
        currentLevel = playerCharacter.Level;
        currentExp = playerCharacter.CurrentExp;
        baseHealth = playerCharacter.Health;
        baseStrength = playerCharacter.Strength;
        baseDexterity = playerCharacter.Dexterity;
        baseDefence = playerCharacter.Defence;
        baseAgility = playerCharacter.Agility;
    }

    void SavePlayerData()
    {
        playerCharacter.Level = currentLevel;
        playerCharacter.CurrentExp = currentExp;
        playerCharacter.Health = health;
        playerCharacter.Strength = strength;
        playerCharacter.Dexterity = dexterity;
        playerCharacter.Defence = defence;
        playerCharacter.Agility = agility;

        string toJson = JsonUtility.ToJson(playerCharacter);

        File.WriteAllText(path, toJson);

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
}

 [System.Serializable]
public class PlayerData
{
    public string Name;
    public int Level;
    public int CurrentExp;
    public int Health;
    public int Strength;
    public int Dexterity;
    public int Defence;
    public int Agility;
}
