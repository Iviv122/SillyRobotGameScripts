using UnityEngine;

public class Pulsejump : ActiveModule 
{
    public override ModuleType ModuleType => ModuleType.Skill1;

    public override float EnergyConsuption => 3;

    public override Sprite Sprite()
    {
        return Resources.Load<Sprite>("Sprites/ActiveModules/PulseModule");
    }
    public override string GetTitle()
    {
        return "Pulse jumper";
    }
    public override string GetDescription()
    {
        return $"Jumps in cost of {EnergyConsuption}";
    }

    public override void Use(Player player)
    {
        player.PlayerMovement.Jump();
    }
}
