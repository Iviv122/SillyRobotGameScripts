using UnityEngine;

[CreateAssetMenu(fileName = "BodyPart", menuName = "Player/Create BodyPart")]
public class BodyPart : ScriptableObject 
{
    public BodyPartType PartType {get;}
    public int Health {get;}
    public int Energy {get;}
    public ModuleGrid Grid {get;}
}

public enum BodyPartType{
    Legs,
    Arms,
    Body,
    Head
}