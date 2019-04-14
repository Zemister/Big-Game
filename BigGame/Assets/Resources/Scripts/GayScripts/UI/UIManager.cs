using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;

    public Slider manaBar;
    public Text MPText;
    public PlayerMana playerMana;

    private PlayerStats thePS;
    public Slider expBar;
    public Text expText;
    public Text totalExpText;

    public Text levelText;

    private static bool UIExists;

	void Start () {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
    }
	
	void Update () {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "Health " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        MPText.text = "Mana " + playerMana.playerCurrentMana + "/" + playerMana.playerMaxMana;
        levelText.text = "Level " + thePS.currentLevel;
        expText.text = "Exp " + thePS.currentExp + "/" + thePS.toLevelUp[thePS.currentLevel];
        totalExpText.text = "Total " + thePS.totalExp;
    }
}
