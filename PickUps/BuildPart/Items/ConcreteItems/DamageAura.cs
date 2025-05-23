using UnityEngine;

public class ElectricAura : Item 
{
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/MiniTesla");
    }
    public override Rarity RarityType(){
        return Rarity.common;
    }

    public override string GetTitle()
    {
        return "Electric Aura";    
    }
    public override string GetDescription()
    {
        return $"Deals {damage} damage in {radius} every {timer} seconds around player";
    }

    Explosion expl;
    float radius = 1.5f;
    float timer = 0.75f;
    float CurrentTime = 0.0f;
    float damage = 0.2f;
    public override void OnPickUpThis(Player player)
    {
        expl = new(radius,3.5f,player);
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
