using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public int weaponDamage;
    public float weaponFireRate; //0 = 0% 1 = 100%
    public float weaponRange;
    public float projectileSpeed;
    public bool equipped;
    public Transform projectilePrefab;

    public Sprite projectileSprite;
    public Sprite weaponIcon;
}
