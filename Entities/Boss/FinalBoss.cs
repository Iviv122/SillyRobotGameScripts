using Zenject;
using UnityEngine;
public class FinalBoss : Entity, Boss
{
    [SerializeField] Player player;

    [SerializeField] float timer1 = 3;
    [SerializeField] float timer2 = 7;
    [SerializeField] float timer3 = 5;
    [SerializeField] float timer4 = 4;
    [SerializeField] float timer5 = 4;
    [SerializeField] GameObject Projectile;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] GameObject rocket;

    CountdownTimer _Attack1Timer;
    CountdownTimer _Attack2Timer;
    CountdownTimer _Attack3Timer;
    CountdownTimer _Attack4Timer;
    CountdownTimer _MoveTimer;
    [SerializeField] float ContactDamage = 10;
    [Inject] private DiContainer _container;
    int moveState;
    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }
    void Awake()
    {
        // Instantiate timers
        _Attack1Timer = new CountdownTimer(timer1);
        _Attack2Timer = new CountdownTimer(timer2);
        _Attack3Timer = new CountdownTimer(timer3);
        _Attack4Timer = new CountdownTimer(timer4);
        _MoveTimer = new CountdownTimer(timer5);



        // Setup event callbacks...
        _Attack1Timer.OnTimerStop += () =>
        {
            _Attack1Timer.Start();
            RoundShoot();
        };
        _Attack2Timer.OnTimerStop += () =>
        {
            _Attack2Timer.Start();
            UltraRoundShoot();
        };
        _Attack3Timer.OnTimerStop += () =>
        {
            _Attack3Timer.Start();
            ShootTarget();
            Spawnenemy(rocket);
        };
        _Attack4Timer.OnTimerStop += () =>
        {
            _Attack4Timer.Start();
            UltraRoundShoot();
            DownShoot(new Vector2(-0.5f, 0));
            DownShoot(new Vector2(-0f, 0));
            DownShoot(new Vector2(0.5f, 0));
        };
        _MoveTimer.OnTimerStop += () =>
        {
            RerolMovement();
        };
        _Attack1Timer.Start();
        _Attack2Timer.Start();
        _Attack3Timer.Start();
        _Attack4Timer.Start();
        _MoveTimer.Start();
    }

    void Update()
    {

        _Attack1Timer.Tick(Time.deltaTime);
        _Attack2Timer.Tick(Time.deltaTime);
        _Attack3Timer.Tick(Time.deltaTime);
        _Attack4Timer.Tick(Time.deltaTime);
        _MoveTimer.Tick(Time.deltaTime);

        Move();
    }
    void Move()
    {
        switch (moveState)
        {
            case 0:
                Stack();
                break;
            case 2:
                Stack();
                break;
            case 3:
                Stack();
                break;
            default:
                Stack();
                break;
        }
    }
    void Spawnenemy(GameObject Enemy)
    {
        GameObject spawned = _container.InstantiatePrefab(Enemy, transform.position, Quaternion.identity, null);
    }
    void Stack()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(Random.Range(0, 1.1f), Random.Range(0, 1.1f)));
    }
    void RerolMovement()
    {
        moveState = Random.Range(0, 5);
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

    void UltraRoundShoot()
    {
        for (int i = 0; i < 5; i++)
        {
            foreach (Vector2 dir in directions)
            {
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg+i*5);
                Instantiate(Projectile, transform.position + (Vector3)dir, rotation);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player prey))
        {
            prey.DealDamage(ContactDamage);
            rb.AddForce(Vector2.up * 5);

        }
    }
    void ShootTarget()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        Instantiate(Projectile, transform.position + (Vector3)dir, rotation);
    }

    void DownShoot(Vector2 offset)
    {
        Vector2 dir;
        dir = Vector2.down;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        Instantiate(Projectile, transform.position + (Vector3)dir + (Vector3)offset, rotation);
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
