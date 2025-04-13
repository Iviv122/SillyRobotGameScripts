using System.ComponentModel;
using UnityEngine;
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
    
    public void AddBodyPart(BodyPart part, BodyPartsType type){
        if(getPart(type) != null){
            SwapBodyPart(part,type);
        }
        setPart(part,type);
        baseStats.Add(part.Stats);
    }
    public void RemoveBodyPart(BodyPartsType type){
        baseStats.Subtract(getPart(type).Stats);
        //TODO: drop on floor
    }
    private void SwapBodyPart(BodyPart part, BodyPartsType type){
        RemoveBodyPart(type);
        AddBodyPart(part,type);
    }
    private BodyPart getPart(BodyPartsType type){
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
                Debug.LogError("BodyPartManaget tried to work with " + type + " and failed!");
                throw new InvalidEnumArgumentException();
        }
    }
    private void setPart(BodyPart part,BodyPartsType type){
        switch (type)
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
                Debug.LogError("BodyPartManaget tried to work with " + type + " and failed!");
                throw new InvalidEnumArgumentException();
        }
    }
}

