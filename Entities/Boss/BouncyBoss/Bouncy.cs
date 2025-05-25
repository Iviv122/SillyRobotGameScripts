using UnityEngine;
using Zenject;

public class Bouncy : Entity, Boss
{
    [SerializeField] Player player;
    [SerializeField] float DetectionRadius;
    [SerializeField] float ExpGive = 20;
    CountdownTimer _Attack1Timer;
    [SerializeField] float Attack1Period = 3;
    CountdownTimer _Attack2Timer;
    [SerializeField] float Attack2Period = 1;
    [SerializeField] float ContactDamage = 10;
    [SerializeField] GameObject Projectile;
    [SerializeField] Rigidbody2D rb;

    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }

    void Activate()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        _Attack1Timer.Start();
        _Attack2Timer.Start();
    }
    void DeActivate()
    {
        rb.bodyType = RigidbodyType2D.Static;
        _Attack1Timer.Stop();
        _Attack2Timer.Stop();
    }
    public void Start()
    {
        _Attack1Timer = new CountdownTimer(Attack1Period);
        _Attack2Timer = new CountdownTimer(Attack2Period);

        _Attack1Timer.OnTimerStop += () =>
        {
            _Attack1Timer.Reset();
            RoundShoot();
            _Attack1Timer.Start();
        };
        _Attack2Timer.OnTimerStop += () =>
        {
            _Attack2Timer.Reset();
            RandomShoot();
            _Attack2Timer.Start();
        };

        rb = gameObject.GetComponent<Rigidbody2D>();

        DeActivate();
    }
    Vector2[] directions = new Vector2[]
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
    void RoundShoot()
    {
        foreach (Vector2 dir in directions)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            Instantiate(Projectile, transform.position + (Vector3)dir, rotation);
        }
    }


    void RandomShoot()
    {
        Vector2 dir;
        dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        Instantiate(Projectile, transform.position + (Vector3)dir, rotation);
    }

    void Update()
    {
        if (TransformInRadius(player.transform,DetectionRadius)) {
            Activate();
        }
   
        _Attack1Timer.Tick(Time.deltaTime);
        _Attack2Timer.Tick(Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player prey))
        {
            prey.DealDamage(ContactDamage);
            rb.AddForce(Vector2.up * 5);

        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }
}
