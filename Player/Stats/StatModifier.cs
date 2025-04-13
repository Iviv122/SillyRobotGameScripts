using System;

public class StatModifier: IDisposable 
{
    public StatType StatType {get;}
    public IOperationalStrategy Operation {get;}
    public event Action<StatModifier> OnDispose = delegate {};
    readonly CountdownTimer timer;
    public bool MarkedForRemoval; 

    public StatModifier(StatType statType,IOperationalStrategy operation, float duration){
        StatType = statType;
        Operation = operation;
        if(duration <= 0) return;

        timer = new CountdownTimer(duration);
        timer.OnTimerStop += () => MarkedForRemoval = true;
        timer.Start();
    }
    public void Update(float deltatime) => timer?.Tick(deltatime);
    public void Handle(Querry querry){
        querry.Value = Operation.Calculate(querry.Value); 
    }
    public void Dispose(){
        OnDispose.Invoke(this);
    }
}
