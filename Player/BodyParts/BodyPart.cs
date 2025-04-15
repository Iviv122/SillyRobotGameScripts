
using System.Collections.Generic;

public class BodyPart 
{
    public List<StatModifier> Mods {get;}
    public BaseStats Stats {get;}

    public BodyPart(BaseStats baseStats,List<StatModifier> mods){
        Stats = baseStats;
        Mods = mods;
    }
    public BodyPart(BaseStats baseStats){
        Stats = baseStats;
    }
}
