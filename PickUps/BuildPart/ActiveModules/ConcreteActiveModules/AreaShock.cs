using UnityEngine;
public class AreaShock : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.SecondAttack;
    Color color = new Color(0.537f, 0.812f, 0.941f,0.3f);
    Explosion expl;
    float radius = 5;
    float damage = 5;

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/AreaShock");
    }

    public override void OnPickUpThis(Player player)
    {
        expl = new(radius,4f,player,color);
    }

    override public void Use(Player player){

        expl.Explode();
        Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position,5);
        foreach (Collider2D i in cols)
        {
            IDamageable a;
            if(i.gameObject.TryGetComponent<IDamageable>(out a)){
                a.Damage(damage);
            }    
        }
    }
}
