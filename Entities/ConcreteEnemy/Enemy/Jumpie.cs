using UnityEngine;
using Zenject;

public class Jumpie : Entity
{
    [SerializeField] Player player;
    [SerializeField] float Speed = 0.2f;
    [SerializeField] float JumpForce = 3f;
    [SerializeField] float Height = 0.3f;
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
        float deltaY = player.transform.position.y - transform.position.y;
        float deltaX = player.transform.position.x - transform.position.x;

        if (Mathf.Abs(deltaY) > 0.3f) // small threshold
        {
            Jump();
        }

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
    void Jump()
    {
        if (OnGround(Height))
        {
            rb.linearVelocity = Vector2.up * JumpForce;
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.down * Height;
        Gizmos.DrawLine(start, end);

        // Optional: Draw a small sphere at the end point for clarity
        Gizmos.DrawWireSphere(end, 0.05f);
    }

}
