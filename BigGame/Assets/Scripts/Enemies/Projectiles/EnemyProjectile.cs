using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //Range of projectile is decided by speed and lifetime
    public float projectileSpeed;
    public float range;
    private float lifeTime;
    public int enemyDamage;
    public bool canPiercePlayers;
    public bool canPierceWalls;

    //will decide what projectile can and can't go through
    public LayerMask whatIsSolid;

    void Start()
    {
        lifeTime = range / 5 / projectileSpeed;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        MoveProjectile();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerResourceManager player = hitInfo.GetComponent<PlayerResourceManager>();
        if (hitInfo.gameObject.tag == "Player")
        {
            player.TakeDamage(enemyDamage);

            if (!canPiercePlayers)
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
    /*
    private void FetchStats()
    {
        //Fetch Player Stats so they stay up to date
        Player player = FindObjectOfType<Player>();

        playerDefence = player.defence;
    }
    */
}
