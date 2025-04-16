using UnityEngine;

public class DamageAura : Item 
{
    public override void OnUpdate(Player player,float DeltaTime)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position,3);
        foreach (Collider2D i in cols)
        {
            IDamageable a;
            if(i.gameObject.TryGetComponent<IDamageable>(out a)){
                a.Damage(0.2f);
            }    
        }
    }
}
