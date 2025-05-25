using System;

public class BaseStats
{
       public EventfullValue<float> Health = 20;
    public EventfullValue<float> Speed = 4;
    public EventfullValue<float> Energy = 5;
    // In second*
    public EventfullValue<float> HealthRegen = 0;
    public EventfullValue<float> EnergyRegen = 1;

    public event Action ValuesChanged;
    

    public BaseStats(float Health, float Speed, float Energy, float HealthRegen, float EnergyRegen)
    {
        this.Health = Health;
        this.Speed = Speed;
        this.Energy = Energy;
        this.HealthRegen = HealthRegen;
        this.EnergyRegen = EnergyRegen;

        this.Health.ValueChanged += ValuesChanged;
        this.Speed.ValueChanged += ValuesChanged;
        this.Energy.ValueChanged += ValuesChanged;
        this.HealthRegen.ValueChanged += ValuesChanged;
        this.EnergyRegen.ValueChanged += ValuesChanged;

    }
    public void Add(BaseStats x)
    {
        this.Health += x.Health;
        this.Energy += x.Energy;
        this.Speed += x.Speed;
        this.HealthRegen += x.HealthRegen;
        this.EnergyRegen += x.EnergyRegen;

        ValuesChanged?.Invoke();
    }
    public void Subtract(BaseStats x)
    {
        this.Health -= x.Health;
        this.Speed -= x.Speed;
        this.Energy -= x.Energy;
        this.HealthRegen -= x.HealthRegen;
        this.EnergyRegen -= x.EnergyRegen;

        ValuesChanged?.Invoke();
    }

}
