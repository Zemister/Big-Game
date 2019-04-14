using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public AudioSource playerHurt, playerDeath, playerMeleeAttack;

    private static bool SFXmanExists;

    // Use this for initialization
    void Start()
    {
        if (!SFXmanExists)
        {
            SFXmanExists = true;
            //DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
