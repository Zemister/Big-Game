using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //Range of projectile is decided by speed and lifetime
    public float projectileSpeed;
    public float range;
    private float lifeTime;
    public int damage = 1;

    public float offsetX;
    public float offsetY;

    public Transform damageNumber;

    public bool canPiercePlayers;
    public bool canPierceWalls;

    //will decide what projectile can and can't go through
    public LayerMask whatIsSolid;

    void Start()
    {
        lifeTime = range / 5 / projectileSpeed;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        //May change how enemy bullet movement works later
        transform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (hitInfo.gameObject.tag == "Player")
        {
            GameObject playerPosition = hitInfo.gameObject;
            player.TakeDamage(damage);

            var textPositionX = playerPosition.transform.position.x + offsetX;
            var textPositionY = playerPosition.transform.position.y + offsetY;
            var textPosition = new Vector2(textPositionX, textPositionY);

            var clone = (Transform)Instantiate(damageNumber, textPosition, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingDamageNumbers>().damageNumber = damage - player.playerDefence;
            if (!canPiercePlayers)
            {
                Destroy(gameObject);
            }
        }
        if (hitInfo.tag == "Environment")
        {
            if (!canPierceWalls)
            {
                Destroy(gameObject);
            }
        }
    }
}
