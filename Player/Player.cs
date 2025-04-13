using UnityEngine;

public class Player: MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] BaseStats baseStats;
    [SerializeField] private Stats stats;
    [SerializeField] private BodyPartsManager bodyPartsManager;
    public Stats Stats 
    {
        get{
            return stats;
        }
    }
    public BaseStats BaseStats 
    {
        get{
            return baseStats;
        }
    }
    void Awake() {
        
        baseStats = new BaseStats(20,5,5);
        stats = new Stats(new StatsMediator(),baseStats);
        stats.Mediator.AddModifier(new StatModifier(StatType.Speed,new AddOperation(5),3));
        bodyPartsManager = new BodyPartsManager(this,stats,baseStats);
        FillBodyParts(); 
    }
    void Update(){
    
        stats.Mediator.Update(Time.deltaTime);

    }

    public void FillBodyParts(){
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,0,1)),BodyPartsType.Head);
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,0,1)),BodyPartsType.Body);
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,0,1)),BodyPartsType.Arms);
        bodyPartsManager.AddBodyPart(new BodyPart(new BaseStats(1,2,1)),BodyPartsType.Legs);
        Debug.Log($"Health {Stats.Health}, Energy {Stats.Energy}, Speed {Stats.Speed}");
    }

}
