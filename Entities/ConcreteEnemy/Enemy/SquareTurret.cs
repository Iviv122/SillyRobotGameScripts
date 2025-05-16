using UnityEngine;
using Zenject;

public class SquareTurret : Entity
{
    [SerializeField] float attackSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float angle;
    CountdownTimer timer = new CountdownTimer(1);

    void Start()
    {
        timer.OnTimerStop = () =>
        {
            timer.Start();
            RoundShoot();
        };
        timer.Reset(attackSpeed);
        timer.Start();
    }
    void Awake()
    {

    }
    void Update()
    {

        timer.Tick(Time.deltaTime);
    }

    Vector2[] directions = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
    };
    void RoundShoot()
    {
        foreach (Vector2 dir in directions)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + angle);
            Instantiate(bullet, transform.position, rotation);
        }
        angle += 45;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

}