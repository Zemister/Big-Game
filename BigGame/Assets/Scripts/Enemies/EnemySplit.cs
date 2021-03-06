﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySplit : MonoBehaviour
{

    public GameObject splitterSpawns;
    public float minSize;

    public void SplitEnemy()
    {
        Debug.Log(transform.localScale.x);
        if (transform.localScale.x > minSize)
        {
            GameObject splitterSpawn1 = Instantiate(splitterSpawns, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;
            GameObject splitterSpawn2 = Instantiate(splitterSpawns, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation) as GameObject;

            splitterSpawn1.transform.localScale = new Vector3(transform.localScale.y * 0.8f, transform.localScale.y * 0.8f, transform.localScale.z);
            splitterSpawn2.transform.localScale = new Vector3(transform.localScale.y * 0.8f, transform.localScale.y * 0.8f, transform.localScale.z);
        }
    }
}

