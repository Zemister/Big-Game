using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    //Weapon stats
    public GameObject weapon;
    public string weaponName;
    public int weaponDamage;
    public float weaponFireRate;
    public float weaponRange;
    public float projectileSpeed;
    public bool empty;
    public Transform projectilePrefab;

    public Sprite projectileSprite;
    public Sprite weaponIcon;

    void Start()
    {
        //
    }

    public void UpdateSlot()
    {
        //update the players equipped items here
    }
}
