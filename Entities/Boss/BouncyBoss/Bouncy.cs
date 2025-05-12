using System.Reflection;
using UnityEngine;
using Zenject;

public class Bouncy : Entity, Boss
{
    CountdownTimer _Attack1Timer;
    [SerializeField] float Attack1Period = 3;
    CountdownTimer _Attack2Timer;
    [SerializeField] float Attack2Period = 1;

    [SerializeField] GameObject Projectile;
    [SerializeField] Rigidbody rb;

    public void Construct(CountdownTimer Attack1timer, CountdownTimer Attack2timer)
    {
        _Attack1Timer = Attack1timer;
        _Attack2Timer = Attack2timer;

        _Attack1Timer.OnTimerStop += () =>
        {
            Debug.Log("SHooting");
            _Attack1Timer.Reset();
            RoundShoot();
            _Attack1Timer.Start();
        };
        _Attack2Timer.OnTimerStop += () =>
        {
            Debug.Log("SHooting");
            _Attack2Timer.Reset();
            RandomShoot();
            _Attack2Timer.Start();
        };
    }

    private void Awake()
    {
        Construct(new CountdownTimer(Attack1Period), new CountdownTimer(Attack2Period));
        _Attack1Timer.Start();
        _Attack2Timer.Start();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
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
        _Attack1Timer.Tick(Time.deltaTime);
        _Attack2Timer.Tick(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player prey))
        {
            prey.BaseStats.CurrentHealth -= 10;
            rb.AddForce(Vector2.up*5);

        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
