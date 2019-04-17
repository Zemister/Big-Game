using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;

    //private PlayerStats thePlayerStats;

    public int expToGive;
    public int spawnAddsHealth;

    public GameObject bossSpawns;

    void Start()
    {
        CurrentHealth = MaxHealth;

        //thePlayerStats = FindObjectOfType<PlayerStats>();

    }

    void Update()
    {
        if (CurrentHealth <= spawnAddsHealth)
        {
            Instantiate(bossSpawns, new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(bossSpawns, new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(bossSpawns, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
            Instantiate(bossSpawns, new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z), transform.rotation);

            Destroy(gameObject);

            //thePlayerStats.AddExperience(expToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
