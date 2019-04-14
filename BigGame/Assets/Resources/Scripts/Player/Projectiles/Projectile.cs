using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //Range of projectile is decided by speed and lifetime
    public float projectileSpeed;
    public float lifeTime;
    public float offsetX;
    public float offsetY;
    public int damage = 1;

    public Transform damageNumber;

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
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (hitInfo.gameObject.tag == "Enemy")
        {
            GameObject enemyPosition = hitInfo.gameObject;
            enemy.TakeDamage(damage);

            var textPositionX = enemyPosition.transform.position.x + offsetX;
            var textPositionY = enemyPosition.transform.position.y + offsetY;
            var textPosition = new Vector2(textPositionX, textPositionY);

            var clone = (Transform) Instantiate(damageNumber, textPosition, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingDamageNumbers>().damageNumber = damage;

            Destroy(gameObject);
        }
        if (hitInfo.tag == "Environment")
        {
            Destroy(gameObject);
        }
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
