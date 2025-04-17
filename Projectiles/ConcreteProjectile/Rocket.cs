using UnityEngine;

public class Rocket : Projectile 
{
    public float damage = 1.5f;
    public float speed = 25;
    public float radius = 1.5f;

    Explosion expl;
    private void Awake(){
        expl = new(radius,5f,this);
    }
    private void Update() {
        rb.linearVelocity = transform.right*speed;
    } 

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent<IDamageable>(out IDamageable prey)){
            prey.Damage(damage);
        }
        expl.ExplodeAndDestroy();
        Destroy(gameObject);
    }
}
