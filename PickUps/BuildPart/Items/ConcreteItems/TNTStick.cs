using UnityEngine;

public class TNTStick : Item
{
    float Radius = 4;
    float Damage = 5;
    public override string GetTitle()
    {
        return "TNT Stick";
    }
    public override string GetDescription()
    {
        return $"Every time you take damage you explodes in {Radius} radius with {Damage} damage";
    }
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/TNTStick");
    }
    public override Rarity RarityType()
    {
        return Rarity.common;
    }
    Explosion expl;
    public override void OnPickUpThis(Player player)
    {
        expl = new(Radius, 3.5f, player);
    }
    public override void OnDamageTaken(Player player)
    {
        expl.Explode();
        Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position, Radius);
        foreach (Collider2D i in cols)
        {
            if (i.gameObject.TryGetComponent(out IDamageable a))
            {
                a.Damage(Damage);
            }
        }
    }
}
