
using System;

public class LevelUpManager
{
    BaseStats stats;
    private float currentExp = 0;
    private float nextLevelExp = 100;

    public event Action OnChange;

    public LevelUpManager(BaseStats stats)
    {
        this.stats = stats;
    }
    public void LevelUp()
    {
        stats.Health += 0.5f;
        stats.EnergyRegen += 0.1f;
        currentExp = 0;
        nextLevelExp *= 1.5f;
        OnChange?.Invoke();
    }
    public float CurrentExpirience
    {
        get
        {
            return currentExp;
        }
        set
        {
            if (value >= nextLevelExp)
            {
                LevelUp();
            }
            else if (value <= 0)
            {
                currentExp = 0;
            }
            else
            {
                currentExp = value;
            }
            OnChange?.Invoke();
        }
    }
    public float NextLevelExp 
    {
        get
        {
            return nextLevelExp;
        }
    }
}