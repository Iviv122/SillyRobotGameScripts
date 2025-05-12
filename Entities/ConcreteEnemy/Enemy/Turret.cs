using UnityEngine;
using Zenject;

public class Turret : Entity
{
    [SerializeField] Player player;
    [SerializeField] float attackSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float timeLeft;
    CountdownTimer timer = new CountdownTimer(1);

    [Inject]
    void Construct(Player player)
    {
        this.player = player;
    }
    void Start()
    {
        timer.Start();
    }
    void Awake()
    {
        
    }
    void Update()
    {

        timer.Tick(Time.deltaTime);
        timeLeft = timer.Progress;
        if (timer.IsFinished)
        {
            timer.Reset(attackSpeed);
            timer.Start();
            Shoot();
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
        Destroy(gameObject); 
    }

}
