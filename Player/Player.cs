using UnityEngine;

public class Player: MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] BaseStats baseStats;
    [SerializeField] private Stats stats;
    public Stats Stats 
    {
        get{
            return stats;
        }
    }
    void Awake() {
        
        baseStats = new BaseStats(20,5,5);
        stats = new Stats(new StatsMediator(),baseStats);
        stats.Mediator.AddModifier(new StatModifier(StatType.Speed,new AddOperation(5),3));
    
    }
    void Update(){
    
        stats.Mediator.Update(Time.deltaTime);

    }
    
}
