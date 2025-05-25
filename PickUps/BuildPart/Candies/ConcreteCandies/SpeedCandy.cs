using UnityEngine;

public class SpeedCandy : Candy
{
    [SerializeField] float Gain = 3;
    [SerializeField] float Duration = 3;
    public override string GetDescription()
    {
        return $"Gives you {Gain} speed for {Duration} seconds";
    }

    public override string GetTitle()
    {
        return $"Speed Candy";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/SpeedCandy");
    }

    public override void Use(Player player)
    {
        player.Stats.Mediator.AddModifier(new StatModifier(StatType.Speed, new AddOperation((float)Gain),Duration));
    }
}