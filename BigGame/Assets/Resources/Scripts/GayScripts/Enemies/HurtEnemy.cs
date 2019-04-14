using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject bloodSplatter;
    public Transform hitPoint;
    public GameObject damageNumber;

    private PlayerStats thePS;

    void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePS.currentAttack;

            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(bloodSplatter, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "BossNecro")
        {
            currentDamage = damageToGive + thePS.currentAttack;

            other.gameObject.GetComponent<BossHealthNecro>().HurtEnemy(currentDamage);
            Instantiate(bloodSplatter, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Slime")
        {
            currentDamage = damageToGive + thePS.currentAttack;

            other.gameObject.GetComponent<SplitterHealth>().HurtEnemy(currentDamage);
            Instantiate(bloodSplatter, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
            Destroy(gameObject);
        }
    }
}
