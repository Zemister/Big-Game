using CharacterStats;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;

public enum CharacterClass
{
    class1 = 1,
    class2 = 2,
    class3 = 3,
    class4 = 4,
    class5 = 5,
    class6 = 6,
    noclass = 0
}

public class Character : MonoBehaviour //Should handle everything a character is
{
    public CharacterClass CharacterClass;

    public CharacterStat Health;
    public CharacterStat Mana;
    public CharacterStat Defence;
    public CharacterStat Strength;
    public CharacterStat Dexterity;
    public CharacterStat Agility;
    public CharacterStat Wisdom;
    public CharacterStat Vitality;
    public int PlayerLevel;
    public int PlayerExp;
    public int ExpToLevel;
    public int CharacterSlot;
    public float CurrentHealth;

    private int maxLevel = 3;
    private int createSlot;
    private static bool playerExists;

    public InventoryPanel Inventory;
    public EquipmentPanel Equipment;

    [SerializeField] PlayerSaveManager playerSaveManager;

    private void Start()
    {
        PlayerLevel = 1;
        PlayerExp = 0;
        ExpToLevel = 1;
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        LevelUp();
        if (CurrentHealth > Health.Value)
            CurrentHealth = Health.Value;

        //Testing
        if (Input.GetKeyDown(KeyCode.S))
            SaveCharacter(CharacterSlot);
        if (Input.GetKeyDown(KeyCode.H))
            Heal(10);
        if (Input.GetKeyDown(KeyCode.D))
            Damage(10);
        Die();
    }

    public void LevelUp()
    {
        if (PlayerExp >= ExpToLevel)
        {
            PlayerExp -= ExpToLevel;
            if (PlayerLevel >= maxLevel)
            {
                PlayerLevel = maxLevel;
            }
            else
            {
                PlayerLevel += 1;
                LoadPlayerLevel();
            }
        }
    }

    private void LoadPlayerLevel()
    {
        string filePath = Application.streamingAssetsPath + "/class1.json";
        List<ClassLevelData> levelData = new List<ClassLevelData>();

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            ClassLevelData[] classLevelData = JsonConvert.DeserializeObject<ClassLevelData[]>(jsonString);

            Health.BaseValue = classLevelData[PlayerLevel - 1].Health;
            Mana.BaseValue = classLevelData[PlayerLevel - 1].Mana;
            Strength.BaseValue = classLevelData[PlayerLevel - 1].Strength;
            Defence.BaseValue = classLevelData[PlayerLevel - 1].Defence;
            Dexterity.BaseValue = classLevelData[PlayerLevel - 1].Dexterity;
            Agility.BaseValue = classLevelData[PlayerLevel - 1].Agility;
            Wisdom.BaseValue = classLevelData[PlayerLevel - 1].Wisdom;
            Vitality.BaseValue = classLevelData[PlayerLevel - 1].Vitality;
            ExpToLevel = classLevelData[PlayerLevel - 1].ExpToLevel;
            CurrentHealth = Health.Value;
        }
    }

    public void Equip(EquippableItem item)
    {
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void Heal(int heal)
    {
        CurrentHealth += heal;
    }

    private void Die()
    {
        if (CurrentHealth < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void LoadCharacter(int slot)
    {
        CharacterSlot = slot;
        if (playerSaveManager != null)
        {
            playerSaveManager.LoadCharacter(this, CharacterSlot);
        }
        LoadPlayerLevel();
    }

    public void SaveCharacter(int slot)
    {
        CharacterSlot = slot;
        if (playerSaveManager != null)
        {
            playerSaveManager.SaveCharacter(this, CharacterSlot);
        }
    }

    public void SelectSlot(int slot)
    {
        CharacterSlot = slot;
    }

    public void SelectClass(int charClass)
    {
        CharacterClass = (CharacterClass)charClass;
        if (playerSaveManager != null)
        {
            playerSaveManager.SaveCharacter(this, CharacterSlot);
        }
    }
}