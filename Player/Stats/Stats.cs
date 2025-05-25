using System;

public class Stats
{
    readonly BaseStats baseStats;
    readonly StatsMediator mediator;
    private float currentHealth;
    private float currentEnergy;
    private float currentMoney = 0;
    public event Action Die;
    public StatsMediator Mediator => mediator;
    public event Action ValuesChanged;
    public event Action OnDamageTaken;
    public event Action OnHeal;
    public float CurrentMoney
    {
        get { return currentMoney; }
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
            OnValuesChanged();
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
            OnValuesChanged();
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
            OnValuesChanged();
        }
    }

    public float Health
    {
        get
        {
            Querry q = new Querry(StatType.Health, baseStats.Health);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }
    public float Speed
    {
        get
        {
            Querry q = new Querry(StatType.Speed, baseStats.Speed);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }
    public float Energy
    {
        get
        {
            Querry q = new Querry(StatType.Energy, baseStats.Energy);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }
    public float EnergyRegen
    {
        get
        {
            Querry q = new Querry(StatType.EnergyRegen, baseStats.EnergyRegen);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }
    public float HealthRegen
    {
        get
        {
            Querry q = new Querry(StatType.HealthRegen, baseStats.HealthRegen);
            mediator.PerformQuerry(q);
            return q.Value;
        }
    }
    public void OnValuesChanged()
    {
        ValuesChanged?.Invoke();
    }
    public void DealDamage(float damage)
    {
        CurrentHealth -= damage;
        OnDamageTaken?.Invoke();
    }
    public void DealDamageNoProc(float damage)
    {
        CurrentHealth -= damage;
    }
    public void Heal(float heal)
    {
        CurrentHealth += heal;
        OnHeal?.Invoke();
    }
    public void HealNoProc(float heal)
    {
        CurrentHealth -= heal;
    }
    public Stats(StatsMediator mediator, BaseStats baseStats)
    {
        this.mediator = mediator;
        this.baseStats = baseStats;

        baseStats.ValuesChanged += OnValuesChanged;

        mediator.listModifiers.OnAdd += OnValuesChanged;
        mediator.listModifiers.OnRemove += OnValuesChanged;
    }
}
