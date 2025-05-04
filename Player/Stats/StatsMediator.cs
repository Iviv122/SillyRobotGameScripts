using System.Linq;

public class StatsMediator 
{
    readonly public EventList<StatModifier> listModifiers = new();

    public void AddModifier(StatModifier modifier){
        listModifiers.Add(modifier);
        modifier.MarkedForRemoval = false;
    
        modifier.OnDispose += _ => listModifiers.Remove(modifier);
    }
    public void PerformQuerry(Querry query){
        foreach (StatModifier mod in listModifiers)
        {
            if(mod.StatType == query.StatType){
                mod.Handle(query);
            }     
        }
    }
    public void Update(float deltatime){
        foreach (StatModifier mod in listModifiers)
        {
            mod.Update(deltatime);    
        }
        
        foreach (StatModifier mod in listModifiers.Where(modifier => modifier.MarkedForRemoval).ToList())
        {
            mod.Dispose();
        }
    }
    
}
