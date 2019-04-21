using UnityEngine;

public class EnemyProjectile : Projectile
{
    private float damage;
    private float range;
    private float speed;
    private Sprite sprite;

    private bool pierceObject;
    private bool pierceEnvironment;

    private void Start()
    {
        Initialize(damage, range, speed, sprite, pierceObject, pierceEnvironment);
    }
    private void Update()
    {
        MoveProjectile(Vector3.up);
    }

}
