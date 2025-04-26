using UnityEngine;

public class FoorBattery : Item 
{
    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/Items/InduktiveWool");
    }
    public override Rarity RarityType(){
        return Rarity.common;
    } 
    static int counter = 3;
    public override void OnJump(Player player)
    {
       counter--;
       if(counter == 0){
            counter = 3;
            player.Stats.Mediator.AddModifier(new StatModifier(StatType.Speed,new AddOperation(2.5f),3));
       }
    }
}
