using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthNecro : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;

    public GameObject bossSpawns;

    void Start()
    {
        CurrentHealth = MaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
        theQM = FindObjectOfType<QuestManager>();

    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;

            Instantiate(bossSpawns, new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(bossSpawns, new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z), transform.rotation);
            Instantiate(bossSpawns, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), transform.rotation);
            Instantiate(bossSpawns, new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z), transform.rotation);

            Destroy(gameObject);

            thePlayerStats.AddExperience(expToGive);
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
