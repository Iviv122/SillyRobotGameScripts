using System.Security.Cryptography;
using UnityEngine;

public class DamageAura : Item 
{
    public override Rarity RarityType(){
        return Rarity.common;
    }
    Explosion expl;
    float radius = 1.5f;
    float timer = 0.75f;
    float CurrentTime = 0.0f;
    float damage = 0.2f;
    public override void OnPickUpThis(Player player)
    {
        expl = new(radius,player);
    } 
    public override void OnUpdate(Player player,float DeltaTime)
    {
        if(CurrentTime <= 0){
            CurrentTime = timer;
            expl.Explode();
            Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position,radius);
            foreach (Collider2D i in cols)
            {
                if(i.gameObject.TryGetComponent(out IDamageable a)){
                    a.Damage(damage);
                }    
            }
        }else{
            CurrentTime-=DeltaTime;
        }
    }
}
