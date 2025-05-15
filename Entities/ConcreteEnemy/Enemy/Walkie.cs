using UnityEngine;
using Zenject;

public class Walkie : Entity
{
    [SerializeField] Player player;
    [SerializeField] float Speed = 0.1f;
    [SerializeField] float attackPeriod = 1;
    [SerializeField] GameObject bullet;
    private Rigidbody2D rb;
    private CountdownTimer timer;

    [Inject]
    void Construct(Player player)
    {
        this.player = player;
        rb = GetComponent<Rigidbody2D>();

        timer = new CountdownTimer(attackPeriod);
        timer.OnTimerStop = () =>
        {
            timer.Start();
            Shoot();
        };
        timer.Start();
    }

    void Update()
    {
        timer.Tick(Time.deltaTime);
        float deltaX = player.transform.position.x - transform.position.x;
        if (Mathf.Abs(deltaX) < 0.1f) // small threshold
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY); // stop movement
            return;
        }
        float direction = Mathf.Sign(player.transform.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(direction * Speed, rb.linearVelocityY);
    }
    void Shoot()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        Instantiate(bullet, transform.position + (Vector3)dir, rotation);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
}
