using System.ComponentModel;
public class BodyPartsManager : IDropPickUp 
{
    BaseStats baseStats;
    Stats stats;
    readonly Player player; // for events, change this if there is any need 
    
    BodyPart head;
    BodyPart body;
    BodyPart arms;
    BodyPart legs;

    public BodyPartsManager(Player player,Stats stats, BaseStats baseStats){
        this.player = player;
        this.stats = stats;
        this.baseStats = baseStats;
    }
    
    public void AddBodyPart(BodyPart part) {
        BodyPart existing = GetPart(part.Type);
        if (existing != null) {
            RemoveBodyPart(part.Type); // Remove before setting the new one
        }

        SetPart(part);
        baseStats.Add(part.Stats);
    }
    public void RemoveBodyPart(BodyPartsType type){
        baseStats.Subtract(GetPart(type).Stats);
        DropPickUp(GetPart(type),player.transform);
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

