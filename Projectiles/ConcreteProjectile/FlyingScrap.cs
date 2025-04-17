using UnityEngine;

public class FlyingScrap : Projectile 
{
    public float damage = 3;
    public float speed = 15;
    
    private void Update() {
        rb.linearVelocity = transform.right*speed;
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent<IDamageable>(out IDamageable prey)){
            prey.Damage(damage);
        }
        Destroy(gameObject);
    }
}
