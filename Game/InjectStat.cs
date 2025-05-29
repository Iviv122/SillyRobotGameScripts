using UnityEngine;

public class InjectStat
{
    private const string HealthToken = "PermanentHealth";
    private const string EnergyToken = "PermanentEnergy";

    float Health;
    float Energy;

    public InjectStat()
    {
        Load();
    }
    public BaseStats getStats()
    {

        return new BaseStats(Health, 0, Energy, 0, 0);
    }
    public void Load()
    {
        Health = PlayerPrefs.GetFloat(HealthToken, 0);
        Energy = PlayerPrefs.GetFloat(EnergyToken, 0);
    }
    public void AddHealth()
    {
        Health += 1;
        Save();
    }
    public void AddEnergy()
    {
        Energy += 1;
        Save();
    }
    public void Save()
    {
        PlayerPrefs.SetFloat(HealthToken, Health);
        PlayerPrefs.SetFloat(EnergyToken, Energy);
        PlayerPrefs.Save();

    }
}
