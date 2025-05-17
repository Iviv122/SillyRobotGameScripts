using UnityEngine;

public class FoorBattery : Item
{
    public override string GetTitle()
    {
        return "Foor Battery";
    }
    public override string GetDescription()
    {
        return $"Every {ManyJump} jump gives {speedBuff} speed boost for {Duration} seconds";
    }
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/InduktiveWool");
    }
    public override Rarity RarityType()
    {
        return Rarity.common;
    }
    int ManyJump = 3;
    int counter = 3;
    float speedBuff = 3;
    float Duration = 2.5f;
    public override void OnJump(Player player)
    {
        counter--;
        if (counter == 0)
        {
            counter = ManyJump;
            player.Stats.Mediator.AddModifier(new StatModifier(StatType.Speed, new AddOperation(Duration), speedBuff));
        }
    }
}
