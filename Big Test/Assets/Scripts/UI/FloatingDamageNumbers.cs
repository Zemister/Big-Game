using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingDamageNumbers : MonoBehaviour
{
    public float moveSpeed;
    public int damageNumber;
    public Text displayNumber;

    public float timeToDestroy = 0.5f;
    
    void Update()
    {
        displayNumber.text = "-" + damageNumber;
        transform.position = new Vector2(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime));

        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
