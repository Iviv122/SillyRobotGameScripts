using System;

public class BaseStats
{
    private float currentHealth;
    private float currentEnergy;
    public EventfullValue<float> Health = 20;
    public EventfullValue<float> Speed = 4;
    public EventfullValue<float> Energy = 5;

    public event Action ValuesChanged;
    public event Action Die;

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

        }
    }
    public float CurrentEnergy 
    {
        get { return currentEnergy; }
        set
        {
            if (value <= 0)
            {
                Die?.Invoke();
            }
            else if (value > Energy)
            {
                currentEnergy = Energy;
            }
            else
            {
                currentEnergy = value;
            }

        }
    }

    public BaseStats(float Health, float Speed, float Energy)
    {
        this.Health = Health;
        this.Speed = Speed;
        this.Energy = Energy;

        CurrentHealth = Health;
        CurrentEnergy = Energy;
    }
    public void Add(BaseStats x)
    {
        this.Health += x.Health;
        this.Energy += x.Energy;
        this.Speed += x.Speed;

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
