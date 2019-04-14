using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //Range of projectile is decided by speed and lifetime
    public float projectileSpeed;
    public float lifeTime;
    public int damage = 1;

    //will decide what projectile can and can't go through
    public LayerMask whatIsSolid;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        //May change how enemy bullet movement works later
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (hitInfo.tag == "Player")
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }
}
