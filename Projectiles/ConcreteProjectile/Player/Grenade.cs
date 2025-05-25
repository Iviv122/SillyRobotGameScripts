using UnityEngine;

public class grenade : Projectile 
{
    Explosion expl;
    private void Awake(){
        expl = new(Stats.Radius,5f,this,Stats.ExplosionColor);
    }
    void Start()
    {
        GoStraight();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Explode(expl);
    }
}