using UnityEngine;

public class ClasterGrenade : Projectile
{
    [SerializeField]GameObject grenades;
    Explosion expl;
    private void Awake()
    {
        expl = new(Stats.Radius, 5f, this, Stats.ExplosionColor);
    }
    void Start()
    {
        GoStraight();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        RoundShoot(grenades);
        Explode(expl);
    }
}
