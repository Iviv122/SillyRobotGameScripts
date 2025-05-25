using System;
using UnityEngine;
using Zenject;

public class Turret : Entity
{
    [SerializeField] float Exp = 10;
    [SerializeField] Player player;
    [SerializeField] float attackSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float ReactRadius;
    CountdownTimer timer;
    public event Action OnDamage;
    bool activated = false;
    [Inject]
    void Construct(Player player)
    {
        this.player = player;
        OnDamage += Activate;
    }
    void Activate()
    {
        if (!activated)
        {

            timer.Reset(attackSpeed);
            timer.Start();
            activated = true;
        }
    }
    void DeActivate()
    {
        timer.Stop();
    }
    void Awake()
    {
        timer = new(1);
        timer.OnTimerStop = () =>
        {
            timer.Reset();
            timer.Start();
            Shoot();
        };
        DeActivate();
    }
    void Start()
    {
        DeActivate();
    }
    void Update()
    {
        if (TransformInRadius(player.transform, ReactRadius))
        {
            Activate();
        }
        if (activated)
        {
            timer.Tick(Time.deltaTime);
        }
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
