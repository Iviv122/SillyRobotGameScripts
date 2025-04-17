using UnityEngine;
public class AreaShock : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.SecondAttack;
    override public void Use(Player player){
        Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position,5);
        foreach (Collider2D i in cols)
        {
            IDamageable a;
            if(i.gameObject.TryGetComponent<IDamageable>(out a)){
                a.Damage(5f);
            }    
        }
    }
}
