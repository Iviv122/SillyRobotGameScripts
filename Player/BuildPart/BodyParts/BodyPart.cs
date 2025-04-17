
using System.Collections.Generic;

public class BodyPart 
{
    public List<StatModifier> Mods {get;}
    public BaseStats Stats {get;}
    public BodyPartsType Type {get;}

    public BodyPart(BaseStats baseStats, BodyPartsType type,List<StatModifier> mods){
        Stats = baseStats;
        Mods = mods;
        Type = type;
    }
    public BodyPart(BaseStats baseStat, BodyPartsType type){
        Stats = baseStat;
        Type = type;
    }
}
