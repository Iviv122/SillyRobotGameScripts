using UnityEngine;

public class Rocket : Projectile 
{
    Explosion expl;
    private void Awake(){
        expl = new(Stats.Radius,5f,this,Stats.ExplosionColor);
    }
    private void Update()
    {
        GoStraight();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Explode(expl);
    }
}
