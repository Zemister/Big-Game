﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //Range of projectile is decided by speed and lifetime
    public float projectileSpeed;
    public float lifeTime;

    //will decide what projectile can and can't go through
    public LayerMask whatIsSolid;

	void Start () {
        Destroy(gameObject, lifeTime);
    }

	void Update () {
        //Movespeed of projectile
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }

    //Make Enemies a trigger and Projectiles a Rigidbody2D
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }

    //If decide to switch from boxcolliders to raycast use this code in the Update() function
    /*
    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
    if (hitInfo.collider != null)
    {
        if (hitInfo.collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Must Take Damage!");
        }
        Destroy(gameObject);
    }
    */
}
