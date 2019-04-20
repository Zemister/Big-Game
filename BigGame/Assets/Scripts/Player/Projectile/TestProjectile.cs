using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestProjectile : MonoBehaviour
{
    private int weaponDamage;
    private float range;
    private float projectileSpeed = 1;
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
        lifeTime = 1;
        Destroy(this.gameObject, lifeTime);
    }

    void Update()
    {
        MoveProjectile();
        FetchStats();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }

    private void FetchStats()
    {
    }
}
