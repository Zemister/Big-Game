using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth = 1;
    public int playerMaxHealth = 1;

    public int playerDefence = 1;

    void Start()
    {
        playerHealth = playerMaxHealth;
    }

    public void TakeDamage(int damage)
    {
        //need to make diminishing return so players can't stack defense
        playerHealth -= (damage - playerDefence);

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
