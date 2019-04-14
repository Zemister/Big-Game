using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour {

    public int playerMaxMana;
    public int playerCurrentMana;

    void Start ()
    {
        playerCurrentMana = playerMaxMana;
    }

    public void SetMaxMana()
    {
        playerCurrentMana = playerMaxMana;
    }
}
