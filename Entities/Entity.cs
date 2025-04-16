using UnityEngine;

public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] protected float health;
    virtual public float Health{
        get{ return health;}
        set{
            if(value < 0){
                Die();
                return;
            }
            health = value;
        }
    }
    virtual public void Damage(float damage){
        Health -= damage;
    }
    virtual public void Die(){
      
    }
}
