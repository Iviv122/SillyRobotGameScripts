using UnityEngine;
using Zenject;

public class WalkieGrenade : Entity
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
        float deltaX = player.transform.position.x - transform.position.x;
        if (Mathf.Abs(deltaX) < 0.1f) // small threshold
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY); // stop movement
            return;
        }
        float direction = Mathf.Sign(player.transform.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(direction * Stats.Speed, rb.linearVelocityY);
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
        if (other.gameObject.tag == "Player")
        {

            Explode();
        }
    }
    public override void Die()
    {
        Explode();
    }
}