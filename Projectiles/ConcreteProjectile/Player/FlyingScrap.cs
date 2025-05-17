using UnityEngine;

public class FlyingScrap : Projectile 
{
    private void Update() {
        rb.linearVelocity = transform.right*Stats.Speed;
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent<IDamageable>(out IDamageable prey)){
            prey.Damage(Stats.Damage);
        }
        Destroy(gameObject);
    }
}
