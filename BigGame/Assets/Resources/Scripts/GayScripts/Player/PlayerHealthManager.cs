using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;

    private SFXManager sfxmanager;

	void Start () {
        playerCurrentHealth = playerMaxHealth;
        sfxmanager = FindObjectOfType<SFXManager>();

    }
	
	void Update () {
		if (playerCurrentHealth <= 0)
        {
            sfxmanager.playerDeath.Play();
            gameObject.SetActive(false);
        }
	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;

        sfxmanager.playerHurt.Play();
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
