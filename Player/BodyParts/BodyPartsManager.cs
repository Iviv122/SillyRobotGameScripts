using System.ComponentModel;
public class BodyPartsManager 
{
    BaseStats baseStats;
    Stats stats;
    Player player; // for events, change this if there is any need 


    BodyPart head;
    BodyPart body;
    BodyPart arms;
    BodyPart legs;

    public BodyPartsManager(Player player,Stats stats, BaseStats baseStats){
        this.player = player;
        this.stats = stats;
        this.baseStats = baseStats;
    }
    
    public void AddBodyPart(BodyPart part){
        if(GetPart(part.Type) != null){
            SwapBodyPart(part);
        }
        SetPart(part);
        baseStats.Add(part.Stats);
    }
    public void RemoveBodyPart(BodyPartsType type){
        baseStats.Subtract(GetPart(type).Stats);
        //TODO: drop on floor
    }
    private void SwapBodyPart(BodyPart part){
        RemoveBodyPart(part.Type);
        AddBodyPart(part);
    }
    private BodyPart GetPart(BodyPartsType type){
        switch (type)
        {
            case BodyPartsType.Head:
                return head;
            case BodyPartsType.Body:
                return body;
            case BodyPartsType.Arms:
                return arms;
            case BodyPartsType.Legs:
                return legs;
            default:
                Game.LogError("BodyPartManaget tried to work with " + type + " and failed!");
                throw new InvalidEnumArgumentException();
        }
    }
    private void SetPart(BodyPart part){
        switch (part.Type)
        {
            case BodyPartsType.Head:
                head = part;
                break;
            case BodyPartsType.Body:
                body = part;
                break;
            case BodyPartsType.Arms:
                arms = part;
                break;
            case BodyPartsType.Legs:
                legs = part;
                break;
            default:
                Game.LogError("BodyPartManaget tried to work with " + part.Type + " and failed!");
                throw new InvalidEnumArgumentException();
        }
    }
}

