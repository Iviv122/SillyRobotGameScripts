using UnityEngine;
public class Battery : Item
{
    float Capacity = 2;
    StatModifier modifier; 
    public override string GetTitle()
    {
        return "Large Battery";
    }
    public override string GetDescription()
    {
        return $"Gives {Capacity} energy capacity";
    }
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/Battery");
    }
    public override Rarity RarityType()
    {
        return Rarity.common;
    }
    public override void OnPickUpThis(Player player)
    {
        modifier = new StatModifier(StatType.Energy,new AddOperation(Capacity),0);
        player.Stats.Mediator.AddModifier(modifier);
    }
    public override void OnDeleteThis(Player player)
    {
        modifier.MarkedForRemoval = true;
    }
}