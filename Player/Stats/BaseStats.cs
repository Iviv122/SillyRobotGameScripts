public class BaseStats 
{
    public float Health = 20;
    public float Speed = 4;
    public float Energy = 5;


    public BaseStats(float Health,float Speed,float Energy){
        this.Health = Health;
        this.Speed = Speed;
        this.Energy = Energy;
    }

    public static BaseStats operator +(BaseStats c1, BaseStats x){
        return new BaseStats(
        c1.Health + x.Health,
        c1.Speed + x.Speed,
        c1.Energy + x.Energy
        );
    }
    public static BaseStats operator -(BaseStats c1, BaseStats x){
        return new BaseStats(
        c1.Health - x.Health,
        c1.Speed - x.Speed,
        c1.Energy - x.Energy
        );
    }
}
