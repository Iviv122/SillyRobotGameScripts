public class FoorBattery : Item 
{
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
