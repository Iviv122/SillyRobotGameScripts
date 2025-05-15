using System;

public class BaseStats
{
    private float currentHealth;
    private float currentEnergy;
    private float currentMoney = 0;
    public EventfullValue<float> Health = 20;
    public EventfullValue<float> Speed = 4;
    public EventfullValue<float> Energy = 5;
    // In second*
    public EventfullValue<float> HealthRegen = 0;
    public EventfullValue<float> EnergyRegen = 1;

    public event Action ValuesChanged;
    public event Action Die;

    public float CurrentMoney 
    {
        get { return CurrentMoney; }
        set
        {
            if (value <= 0)
            {
                currentMoney = 0;
            }
            else
            {
                currentMoney = value;
            }
            ValuesChanged?.Invoke();
        }
    }
    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value <= 0)
            {
                Die?.Invoke();
            }
            else if (value > Health)
            {
                currentHealth = Health;
            }
            else
            {
                currentHealth = value;
            }
            ValuesChanged?.Invoke();
        }
    }
    public float CurrentEnergy
    {
        get { return currentEnergy; }
        set
        {
            if (value <= 0)
            {
                currentEnergy = 0;
            }
            else if (value > Energy)
            {
                currentEnergy = Energy;
            }
            else
            {
                currentEnergy = value;
            }
            ValuesChanged?.Invoke();
        }
    }

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

        CurrentHealth = Health;
        CurrentEnergy = Energy;
    }
    public void Add(BaseStats x)
    {
        this.Health += x.Health;
        this.Energy += x.Energy;
        this.Speed += x.Speed;
        this.HealthRegen += x.HealthRegen;
        this.EnergyRegen += x.EnergyRegen;

        if (CurrentHealth > Health)
        {
            CurrentHealth = Health;
        }
        if (CurrentEnergy > Energy)
        {
            CurrentEnergy = Energy;
        }
        ValuesChanged?.Invoke();
    }
    public void Subtract(BaseStats x)
    {
        this.Health -= x.Health;
        this.Speed -= x.Speed;
        this.Energy -= x.Energy;
        this.HealthRegen -= x.HealthRegen;
        this.EnergyRegen -= x.EnergyRegen;

        if (CurrentHealth > Health)
        {
            CurrentHealth = Health;
        }
        if (CurrentEnergy > Energy)
        {
            CurrentEnergy = Energy;
        }
        ValuesChanged?.Invoke();
    }

}
