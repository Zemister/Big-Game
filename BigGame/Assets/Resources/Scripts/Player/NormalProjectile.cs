using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public float range;
    private float lifeTime;
    public bool canPierceEnemies;
    public bool canPierceWalls;
    public int weaponDamage;
    private int playerStrength;

    public float offsetX;
    public float offsetY;

    public Transform damageNumber;

    //will decide what projectile can and can't go through (keep looking into maybe)
    //public LayerMask whatIsSolid;

    void Start()
    {
        lifeTime = range / 5 / projectileSpeed;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        MoveProjectile();
        FetchStats();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //This is enemy health
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (hitInfo.gameObject.tag == "Enemy")
        {
            //add calculation for weaponDamage (weapon weaponDamage * (attack/something) mess with this till you like it
            int damage = weaponDamage + playerStrength;
            enemy.TakeDamage(damage);

            GameObject enemyPosition = hitInfo.gameObject;
            CreateDamageNumber(enemyPosition, damage);
            if (!canPierceEnemies)
            {
                Destroy(gameObject);
            }
        }
        if (hitInfo.tag == "Environment")
        {
            if (!canPierceWalls)
            {
                Destroy(gameObject);
            }
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }

    private void CreateDamageNumber(GameObject enemyPosition, int damage)
    {
        var textPositionX = enemyPosition.transform.position.x + offsetX;
        var textPositionY = enemyPosition.transform.position.y + offsetY;
        var textPosition = new Vector2(textPositionX, textPositionY);

        var clone = (Transform)Instantiate(damageNumber, textPosition, Quaternion.Euler(Vector3.zero));
        clone.GetComponent<FloatingDamageNumbers>().damageNumber = damage;
    }

    private void FetchStats()
    {
        //Fetch Player Stats so they stay up to date
        Player player = FindObjectOfType<Player>();

        playerStrength = player.strength;
    }
}
