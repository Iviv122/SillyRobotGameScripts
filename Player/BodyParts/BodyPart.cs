
using System.Collections.Generic;

public class BodyPart 
{
    public List<StatModifier> Mods {get;}
    public ModuleGrid Grid {get;}
    public BaseStats Stats {get;}

    public BodyPart(BaseStats baseStats,ModuleGrid grid, List<StatModifier> mods){
        Stats = baseStats;
        Grid = grid;
        Mods = mods;
    }
    public BodyPart(BaseStats baseStats){
        Stats = baseStats;
    }
}
