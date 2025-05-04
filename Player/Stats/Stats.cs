using System;

public class Stats 
{
    readonly BaseStats baseStats;
    readonly StatsMediator mediator;
    
    public StatsMediator Mediator => mediator;
    public event Action ValuesChanged;
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

    public void OnValuesChanged(){
        ValuesChanged?.Invoke();
    }

    public Stats(StatsMediator mediator, BaseStats baseStats){
        this.mediator = mediator;
        this.baseStats = baseStats;

        baseStats.Energy.ValueChanged += OnValuesChanged;
        baseStats.Health.ValueChanged += OnValuesChanged;
        baseStats.Speed.ValueChanged += OnValuesChanged;

        mediator.listModifiers.OnAdd += OnValuesChanged; 
        mediator.listModifiers.OnRemove += OnValuesChanged;
    }
}
