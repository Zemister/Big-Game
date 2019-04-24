using UnityEngine;
using CharacterStats;

public class PlayerProjectile : Projectile
{
    private float damage;
    private float range;
    private float speed;
    private Sprite sprite;
    private bool pierceEnemies;
    private bool pierceEnvironment;

    private void Start()
    {
        FetchStats(FindObjectOfType<Character>());
        Initialize(damage, range, speed, sprite, pierceEnemies, pierceEnvironment);
    }

    private void Update()
    {
        MoveProjectile(Vector3.up);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //This is enemy health
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (hitInfo.gameObject.tag == "Enemy")
        {
            //add calculation for weaponDamage (weapon weaponDamage * (attack/something) mess with this till you like it
            enemy.TakeDamage(damage);

            if (!pierceEnemies)
            {
                Destroy(gameObject);
            }
        }
    }

    public void FetchStats(Character stat)
    {
        damage = stat.WeaponDamage.Value;
        range = stat.WeaponRange.Value;
        speed = stat.ProjectileSpeed.Value;
        sprite = stat.ProjectileSprite;
        pierceEnemies = false; //need to add a pierce enemy and environment bool to equippable item
        pierceEnvironment = false;
    }
}
