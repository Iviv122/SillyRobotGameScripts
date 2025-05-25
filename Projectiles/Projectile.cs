using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
abstract public class Projectile : MonoBehaviour
{
    public event Action OnHit;
    public event Action OnDestroy;
    [SerializeField] public ProjectileScriptableObject Stats;
    [SerializeField] public Rigidbody2D rb;

    protected void GoStraight()
    {
        rb.linearVelocity = transform.right * Stats.Speed;
    }
    protected static Vector2[] directions = new Vector2[]
           {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
        (Vector2.up + Vector2.right).normalized,
        (Vector2.up + Vector2.left).normalized,
        (Vector2.down + Vector2.right).normalized,
        (Vector2.down + Vector2.left).normalized
           };
    protected void RoundShoot(GameObject projectile)
    {
        foreach (Vector2 dir in directions)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            Game.Instantiate(projectile, (Vector2)transform.position + dir, rotation, null);
        }
    }

    protected void Explode(Explosion expl)
    {
        Collider2D[] preys = Physics2D.OverlapCircleAll(transform.position, Stats.Radius);

        foreach (var item in preys)
        {
            if (item.gameObject.TryGetComponent<IDamageable>(out IDamageable prey))
            {
                prey.Damage(Stats.Damage);
            }
        }

        expl.ExplodeAndDestroy();
        Destroy(gameObject);
    }

}
