using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int totalExp;
    public int currentExp;

    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] MPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;

    public int currentHP;
    public int currentMP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager thePlayerHP;
    private PlayerMana thePlayerMP;

    void Start () {
        currentHP = HPLevels[1];
        currentMP = MPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];

        thePlayerHP = FindObjectOfType<PlayerHealthManager>();
        thePlayerMP = FindObjectOfType<PlayerMana>();
	}
	
	void Update () {
		if(currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
            currentExp = 0;
        }
	}

    public void AddExperience(int exptoAdd)
    {
        currentExp += exptoAdd;
        totalExp += exptoAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];
        currentMP = MPLevels[currentLevel];

        thePlayerHP.playerMaxHealth = currentHP;
        thePlayerHP.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];
        thePlayerMP.playerMaxMana = currentMP;
        thePlayerMP.playerCurrentMana += currentMP - MPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }
}
