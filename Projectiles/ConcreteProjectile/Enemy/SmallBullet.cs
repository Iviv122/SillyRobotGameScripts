using UnityEngine;

public class SmallBullet : Projectile 
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    void Update()
    {
        rb.linearVelocity = transform.right*speed;
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.TryGetComponent<Player>(out Player prey)){
            prey.BaseStats.CurrentHealth -= damage;
        }
        Destroy(gameObject);
    }
}
