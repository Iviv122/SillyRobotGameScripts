using UnityEngine;
public class StrangeMask: Item
{
    float Capacity = 9;
    float EnergyRegen = 1;
    float AdditionDamage = 5;
    StatModifier modifier1;
    StatModifier modifier2;
    public override string GetTitle()
    {
        return "Strange Mask";
    }
    public override string GetDescription()
    {
        return $"When get damage, receive {AdditionDamage} additional damage which doesn't activate other effetcs, energy capacity increased by {Capacity} and energy regen by {EnergyRegen}";
    }
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/StrangeMask");
    }
    public override Rarity RarityType()
    {
        return Rarity.common;
    }
    public override void OnPickUpThis(Player player)
    {
        modifier1 = new StatModifier(StatType.Energy, new AddOperation(Capacity), 0);
        modifier2 = new StatModifier(StatType.EnergyRegen, new AddOperation(EnergyRegen), 0);
        player.Stats.Mediator.AddModifier(modifier1);
        player.Stats.Mediator.AddModifier(modifier2);
    }
    public override void OnDamageTaken(Player player)
    {
        player.DealDamageNoProc(AdditionDamage); 
    }
    public override void OnDeleteThis(Player player)
    {
        modifier1.MarkedForRemoval = true;
        modifier2.MarkedForRemoval = true;
    }
}