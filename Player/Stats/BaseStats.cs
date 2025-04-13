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

    public void Add(BaseStats x){
        this.Health += x.Health;
        this.Energy += x.Energy;
        this.Speed += x.Speed;
    }
    public void Subtract(BaseStats x){
        this.Health -= x.Health;
        this.Speed -= x.Speed;
        this.Energy -= x.Energy;
    }
        
}
