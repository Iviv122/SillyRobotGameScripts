using System;
using UnityEngine;
using Zenject;

public class Goomba : Entity
{

    [SerializeField] float Exp = 10;
    [SerializeField] float ActivateRadius = 15;
    [SerializeField] Player player;
    [SerializeField] float Speed = 0.1f;
    [SerializeField] float attackPeriod = 1;
    [SerializeField] GameObject bullet;
    [SerializeField] Vector2 dir;

    private Rigidbody2D rb;
    private CountdownTimer timer;

    public event Action OnDamage;
    bool activated = false;
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
        OnDamage += Activate;
        DeActivate();
        dir = Vector2.right;
    }
    public override void Damage(float damage)
    {
        base.Damage(damage);
        OnDamage?.Invoke();
    }

    void Activate()
    {
        if (!activated)
        {
            timer.Reset(attackPeriod);
            timer.Start();
            activated = true;
        }

    }
    void DeActivate()
    {
        timer.Stop();
        activated = false;
    }
    void Update()
    {
        if (TransformInRadius(player.transform, ActivateRadius))
        {
            Activate();
        }
        if (activated)
        {
            timer.Tick(Time.deltaTime);

        }
        if (IsThereWall())
        {
            dir.x = -dir.x;
        }
        rb.linearVelocity = new Vector2(dir.x * Speed, rb.linearVelocityY);
    }
    bool IsThereWall()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + dir / 2, dir.normalized, 0.1f);
        return hit.collider != null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine((Vector2)transform.position + dir / 2, (Vector2)transform.position + dir);
    }
    void Shoot()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        Instantiate(bullet, transform.position + (Vector3)dir, rotation);
    }
    public override void Die()
    {
        GiveExp(player.LevelUpManager, Exp);
        Destroy(gameObject);
    }
}
