using UnityEngine;
using Zenject;

public class HomingRocket : Entity
{

    [SerializeField] Player player;
    [SerializeField] ProjectileScriptableObject Stats;
    private Rigidbody2D rb;
    Explosion expl;
    [Inject]
    void Construct(Player player)
    {
        this.player = player;
        rb = GetComponent<Rigidbody2D>();
        expl = new(Stats.Radius, 5f, this, Stats.ExplosionColor);
    }

    void Update()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;

        rb.linearVelocity = dir * Stats.Speed;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }
    private bool hasExploded = false;
    protected void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;
        Collider2D[] preys = Physics2D.OverlapCircleAll(transform.position, Stats.Radius);

        foreach (var item in preys)
        {
            if (item.gameObject.TryGetComponent<IDamageable>(out IDamageable prey))
            {
                prey.Damage(Stats.Damage);
            }
            if (item.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.DealDamage(Stats.Damage);
            }
        }

        expl.ExplodeAndDestroy();
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Explode();
    }
    public override void Die()
    {
        Explode();
    }


}
