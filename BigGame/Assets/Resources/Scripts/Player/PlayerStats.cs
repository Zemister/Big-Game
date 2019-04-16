using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;

    public int currentExp;

    private int expToLevel;

    public int health;
    public int attack;
    public int tempo;
    public int defence;
    public int agility;

    private Player playerHealthAndDefence;
    private PlayerController playerSpeedAndTempo;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthAndDefence = FindObjectOfType<Player>();
        playerSpeedAndTempo = FindObjectOfType<PlayerController>();

        //These will be base stats, might do through editor instead, or just add scripts for each class or something
        health = 20;
        defence = 1;
        attack = 1;
        tempo = 1;
        agility = 1;
        playerHealthAndDefence.playerHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        StatsUpdate();
    }

    public void StatsUpdate()
    {
        playerHealthAndDefence.playerMaxHealth = health;
        playerHealthAndDefence.playerDefence = defence;
        //add calculation for speeeeed (arbitrary value how much you want agility stat to effect speed)
        playerSpeedAndTempo.playerSpeed = agility;
        //add calculation for attack speed (arbitrary value how much you want tempo stat to effect APS)
        playerSpeedAndTempo.attacksPerSecond = tempo;
    }

    //will eventually add base stats here, then calculations for how much stat they should gain per level, add in stats added by gear, and add in stats added by skill tree, + any other mods 
    public void CheckStats()
    {
        health = 0;
        attack = 0;
        tempo = 0;
        defence = 0;
        agility = 0;
    }
}
