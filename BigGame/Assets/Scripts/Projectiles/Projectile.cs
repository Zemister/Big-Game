using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    public float Range;
    public float ProjectileSpeed;
    private float LifeTime;
    public Sprite ProjectileSprite;

    public bool PierceObject;
    public bool PierceEnvironment;

    public virtual void Initialize(float damage, float range, float speed, Sprite sprite, bool pierceObject, bool pierceEnvironment)
    {
        Damage = damage;
        Range = range;
        ProjectileSpeed = speed;
        LifeTime = range / 5 / speed;
        ProjectileSprite = sprite;
        PierceObject = pierceObject;
        PierceEnvironment = pierceEnvironment;
        this.GetComponent<SpriteRenderer>().sprite = sprite;

        Destroy(this.gameObject, LifeTime);
    }

    public void MoveProjectile(Vector3 direction)
    {
        transform.Translate(direction * ProjectileSpeed * Time.deltaTime);
    }
}