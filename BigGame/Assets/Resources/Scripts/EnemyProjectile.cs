using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //Range of projectile is decided by speed and lifetime
    public float projectileSpeed;
    public float lifeTime;

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
        if (hitInfo.tag == "Player")
        {
            Debug.Log("Should damage: " + hitInfo.name);
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }
}
