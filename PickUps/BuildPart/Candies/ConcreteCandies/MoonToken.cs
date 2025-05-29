using UnityEngine;

public class MoonToken : Candy
{
    [SerializeField] float Gain = 5;
    public override string GetDescription()
    {
        return $"Single moon token";
    }

    public override string GetTitle()
    {
        return $"Moon Token";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/MoonToken");
    }

    public override void Use(Player player)
    {
        player.MoonTokenCollector.AddTokens(1);
    }
}