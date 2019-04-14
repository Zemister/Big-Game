using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitterHealth : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;

    public GameObject splitterSpawns;
    public float minSize;

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

             if (transform.localScale.y > minSize)
             {
            GameObject splitterSpawn1 = Instantiate(splitterSpawns, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
            GameObject splitterSpawn2 = Instantiate(splitterSpawns, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;

            splitterSpawn1.transform.localScale = new Vector3(transform.localScale.y * 0.8f, transform.localScale.y * 0.8f, transform.localScale.z);
            splitterSpawn1.GetComponent<SplitterHealth>().CurrentHealth = 25;
            splitterSpawn2.transform.localScale = new Vector3(transform.localScale.y * 0.8f, transform.localScale.y * 0.8f, transform.localScale.z);
            splitterSpawn2.GetComponent<SplitterHealth>().CurrentHealth = 25;
            }
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

