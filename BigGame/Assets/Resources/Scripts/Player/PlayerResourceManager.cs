using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResourceManager : MonoBehaviour
{
    public int currentHealth = 20;
    public int maxHealth;

    private int playerDefence;

    public float offsetX;
    public float offsetY;
    public Transform damageNumber;

    void Start()
    {
        
    }

    void Update()
    {
        FetchStats();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= (damage < playerDefence ? 0 : damage - playerDefence);
        CreateDamageNumber(this.gameObject, (damage < playerDefence ? 0 : damage - playerDefence));

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    private void FetchStats()
    {
        //Fetch Player Stats so they stay up to date
        Player player = FindObjectOfType<Player>();

        maxHealth = player.health;
        playerDefence = player.defence;
    }

    private void CreateDamageNumber(GameObject playerPosition, int damage)
    {
        var textPositionX = playerPosition.transform.position.x + offsetX;
        var textPositionY = playerPosition.transform.position.y + offsetY;
        var textPosition = new Vector2(textPositionX, textPositionY);

        var clone = (Transform)Instantiate(damageNumber, textPosition, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingDamageNumbers>().damageNumber = damage;
    }

    void HealToMax()
    {
        currentHealth = maxHealth;
    }
}
