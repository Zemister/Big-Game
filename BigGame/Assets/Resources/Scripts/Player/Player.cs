using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerHealth;
    public int playerMaxHealth;

    public int playerDefence;

    void Start()
    {
        //playerHealth = playerMaxHealth;
    }

    public void TakeDamage(int damage)
    {
        //need to make diminishing return so players can't stack defense
        playerHealth -= (damage);

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
