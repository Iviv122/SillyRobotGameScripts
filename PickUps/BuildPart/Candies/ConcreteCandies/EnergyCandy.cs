using UnityEngine;

public class EnergyCandy : Candy
{
    [SerializeField] float Gain = 3;
    public override string GetDescription()
    {
        return $"Gives you {Gain} energy";
    }

    public override string GetTitle()
    {
        return $"Energy Candy";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/EnergyCandy");
    }

    public override void Use(Player player)
    {
        player.Stats.CurrentEnergy += Gain;
    }
}