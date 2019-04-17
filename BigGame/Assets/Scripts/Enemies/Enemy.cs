using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public float offsetX;
    public float offsetY;
    public Transform damageNumber;

    public void TakeDamage (int damage)
    {
        health -= damage;
        CreateDamageNumber(this.gameObject, damage);

        if (health <= 0)
        {
            //transform.GetComponent<EnemySplit>().SplitEnemy();
            Die();
        }
    }

    private void CreateDamageNumber(GameObject enemyPosition, int damage)
    {
        var textPositionX = enemyPosition.transform.position.x + offsetX;
        var textPositionY = enemyPosition.transform.position.y + offsetY;
        var textPosition = new Vector2(textPositionX, textPositionY);

        var clone = (Transform)Instantiate(damageNumber, textPosition, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingDamageNumbers>().damageNumber = damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
