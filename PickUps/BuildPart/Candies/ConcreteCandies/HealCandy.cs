using UnityEngine;

public class HealCandy : Candy
{
    [SerializeField] float Gain = 15;
    public override string GetDescription()
    {
        return $"Heals you for {Gain} Health";
    }

    public override string GetTitle()
    {
        return $"Heal Candy";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/HealCandy");
    }

    public override void Use(Player player)
    {
        player.Stats.Heal(Gain);
    }
}
