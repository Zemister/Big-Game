using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private GameObject weaponSlot;

    public GameObject player;

    private Sprite projectileSprite;
    private Sprite weaponIcon;

    void Start()
    {
        weaponSlot = player.transform.GetChild(1).gameObject;
        if (weaponSlot.GetComponent<WeaponSlot>().weapon == null)
        {
            weaponSlot.GetComponent<WeaponSlot>().empty = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col) //probably change to get from inventory button press
    {
        if (col.tag == "Weapon")
        {
            GameObject weaponEquipped = col.gameObject;
            Weapon weapon = weaponEquipped.GetComponent<Weapon>();
            EquipWeapon(weaponEquipped, weapon.weaponName, weapon.weaponDamage, weapon.weaponFireRate, weapon.weaponRange, weapon.projectileSpeed, weapon.projectileSprite, weapon.weaponIcon, weapon.projectilePrefab);
        }
    }
    
    //dont know if first argument should be gameobject, transform, weapon or what
    void EquipWeapon(GameObject weapon, string name, int damage, float fireRate, float range, float speed, Sprite projectile, Sprite icon, Transform projectilePrefab)
    {
        if (weaponSlot.GetComponent<WeaponSlot>().empty)
        {
            weapon.GetComponent<Weapon>().equipped = true;
            //make a weapon slot then in the weapon slots function add the values, attach the gameobject, all that
            weaponSlot.GetComponent<WeaponSlot>().weaponName = name;
            weaponSlot.GetComponent<WeaponSlot>().weaponDamage = damage;
            weaponSlot.GetComponent<WeaponSlot>().weaponFireRate = fireRate;
            weaponSlot.GetComponent<WeaponSlot>().weaponRange = range;
            weaponSlot.GetComponent<WeaponSlot>().projectileSpeed = speed;
            weaponSlot.GetComponent<WeaponSlot>().projectilePrefab = projectilePrefab;

            weapon.transform.parent = weaponSlot.transform;
            weapon.SetActive(false);

            weaponSlot.GetComponent<WeaponSlot>().UpdateSlot();
            weaponSlot.GetComponent<WeaponSlot>().empty = false;
        }
    }
}
