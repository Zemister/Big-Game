using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject itemDrop;
    public Item[] items;

    public float health = 1;

    public float offsetX;
    public float offsetY;

    public void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        itemDrop.GetComponent<DropItem>().CreateDropItem(items[0], 1, this.transform.position);
    }

}
