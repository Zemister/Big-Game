﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeShot : MonoBehaviour {

    public Transform shotPoint;
    private float xAim, yAim;

    public Transform projectilePrefab;

    //Attack speed variables
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    void Start()
    {

    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation);
            Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, 15));
            Instantiate(projectilePrefab, shotPoint.position, shotPoint.rotation * Quaternion.Euler(0, 0, -15));
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
