using UnityEngine;

public class LoveCandy : Candy
{
    [SerializeField] float Gain = 5;
    [SerializeField] float Pain = 20;
    public override string GetDescription()
    {
        return $"Gives {Gain} base health permamently deals {Pain} damage";
    }

    public override string GetTitle()
    {
        return $"Love Candy";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/LoveDeathCandy");
    }

    public override void Use(Player player)
    {
        player.BaseStats.Health += Gain;
        player.DealDamage(Pain);
    }
}