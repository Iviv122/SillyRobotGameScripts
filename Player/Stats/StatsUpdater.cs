using UnityEngine;
public class StatsUpdater 
{
    BaseStats baseStats;
    Stats stats;
    CountdownTimer countdownTimer;
    float updateTime = 1; // seconds
    public StatsUpdater(BaseStats baseStats, Stats stats,float updateTime = 1){

        this.updateTime = updateTime;
        this.baseStats = baseStats;
        this.stats = stats;

        countdownTimer = new(this.updateTime);
        countdownTimer.OnTimerStop = () =>{
            RegenStats();
            countdownTimer.Reset(updateTime);
            countdownTimer.Start();
        };
        countdownTimer.Start();
    }
    public void Update(float delta){
        countdownTimer.Tick(delta);
    }
    public void RegenStats(){
        stats.CurrentHealth += stats.HealthRegen;
        stats.CurrentEnergy += stats.EnergyRegen;
    }
}
