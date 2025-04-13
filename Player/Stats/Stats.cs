public class Stats 
{
    readonly BaseStats baseStats;
    readonly StatsMediator mediator;
    
    public StatsMediator Mediator => mediator;
    public float Health{
        get{
            Querry q = new Querry(StatType.Health,baseStats.Health);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }
    public float Speed{
        get{
            Querry q = new Querry(StatType.Speed,baseStats.Speed);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }
    public float Energy{
        get{
            Querry q = new Querry(StatType.Energy,baseStats.Energy);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }

    public Stats(StatsMediator mediator, BaseStats baseStats){
        this.mediator = mediator;
        this.baseStats = baseStats;
    }
}
