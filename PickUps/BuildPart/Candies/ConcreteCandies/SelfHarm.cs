using UnityEngine;

public class SelfHarm : Candy
{
    [SerializeField] float Damage = 10;
    public override string GetDescription()
    {
        return $"Deals you {Damage} damage";
    }

    public override string GetTitle()
    {
        return $"SelfHarm Candy";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/PoisonCandy");
    }

    public override void Use(Player player)
    {
        player.DealDamage(Damage);
    }
}
