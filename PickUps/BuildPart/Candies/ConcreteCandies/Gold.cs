using UnityEngine;

public class Gold : Candy
{
    [SerializeField] float Gain = 5;
    public override string GetDescription()
    {
        return $"Gives you {Gain} gold";
    }

    public override string GetTitle()
    {
        return $"Gold";
    }

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Candies/Gold");
    }

    public override void Use(Player player)
    {
        player.Stats.CurrentMoney += Gain;
    }
}