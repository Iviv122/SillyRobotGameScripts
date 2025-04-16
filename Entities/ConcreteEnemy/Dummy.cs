public class Dummy : Entity
{
    public override void Damage(float damage){
        Game.Log($"Damage dealt to dummy is {damage}");
    }
}
