using UnityEngine;

public class grenade : Projectile 
{
    Explosion expl;
    private void Awake(){
        expl = new(Stats.Radius,5f,this,Stats.ExplosionColor);
    }
    void Start()
    {
        rb.linearVelocity = transform.right*Stats.Speed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable prey))
        {
            prey.Damage(Stats.Damage);
        }
        expl.ExplodeAndDestroy();
        Destroy(gameObject);
    }
}