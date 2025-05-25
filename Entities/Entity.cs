using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] protected float health;
    [SerializeField] protected LayerMask Ground;
    virtual public float Health
    {
        get { return health; }
        set
        {
            if (value < 0)
            {
                Die();
                return;
            }
            health = value;
        }
    }
    virtual public void Damage(float damage)
    {
        Health -= damage;
    }
    /// <summary>
    /// Comes out of transform.position and checks for groundLayer
    /// </summary>
    /// <param name="Height"></param>
    /// <returns></returns>
    protected bool OnGround(float Height)
    {
        return Physics2D.Raycast(transform.position, Vector2.down, Height, Ground);
    }
    protected void KnockBackAttack(float Damage, Rigidbody2D rb, float force, Player player)
    {
        Vector2 direction = (rb.transform.position - transform.position).normalized;

        rb.AddForce(direction * force);
        player.DealDamage(Damage);

    }
    protected bool TransformInRadius(Transform target, float radius)
    {
        return Vector3.Distance(target.position, transform.position) < radius;
    }
    protected void GiveExp(LevelUpManager levelUpManager, float amount)
    {
        levelUpManager.CurrentExpirience += amount;
    }
    virtual public void Die()
    {

    }
}
