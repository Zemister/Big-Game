using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestProjectile : MonoBehaviour
{
    private int weaponDamage;
    private float range;
    private float projectileSpeed;
    private Sprite projectileSprite;

    private float lifeTime;
    private bool canPierceEnemies;
    private bool canPierceWalls;
    private int playerStrength;

    private Transform weaponSlot;
    private Transform player;

    //will decide what projectile can and can't go through (keep looking into maybe)
    //public LayerMask whatIsSolid;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        weaponSlot = player.GetChild(1);
        weaponDamage = weaponSlot.GetComponent<WeaponSlot>().weaponDamage;
        range = weaponSlot.GetComponent<WeaponSlot>().weaponRange;
        projectileSpeed = weaponSlot.GetComponent<WeaponSlot>().projectileSpeed;

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

            if (!canPierceEnemies)
            {
                Destroy(gameObject);
            }
        }
        if (hitInfo.gameObject.tag == "Environment")
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

    private void FetchStats()
    {
        //Fetch Player Stats so they stay up to date
        Player player = FindObjectOfType<Player>();

        playerStrength = player.strength;
    }
}
