using System;
using System.ComponentModel;

public class ModuleManager : IDropPickUp 
{
    readonly Player player;
    public event Action OnModuleUse;
    public ModuleManager(Player player)
    {
        this.player = player;
        player.Attack += OnLeftMouse;
        player.Attack1 += OnRightMouse;
        player.Module1 += OnE;
        player.Module2 += OnQ;
        player.Module3 += OnR;
        player.Module4 += OnShift;


    }
    public void ModuleUse()
    {
        OnModuleUse?.Invoke();
    }
    ActiveModule mainAttack;
    ActiveModule secondAttack;
    ActiveModule skill1;
    ActiveModule skill2;
    ActiveModule skill3;
    ActiveModule skill4;

    // Input handlers
    private void OnLeftMouse() => TryToUse(GetModule(ModuleType.MainAttack));
    private void OnRightMouse() => TryToUse(GetModule(ModuleType.SecondAttack));
    private void OnE() => TryToUse(GetModule(ModuleType.Skill1));
    private void OnQ() => TryToUse(GetModule(ModuleType.Skill2));
    private void OnR() => TryToUse(GetModule(ModuleType.Skill3));
    private void OnShift() => TryToUse(GetModule(ModuleType.Skill4));

    // Module management
    public void AddModule(ActiveModule module)
    {
        if (GetModule(module.ModuleType) != null)
        {
            SwapModule(module);
        }
        else
        {
            SetModule(module);
        }
    }

    private void RemoveModule(ModuleType type)
    {
        DropPickUp(GetModule(type),player.transform);
        SetModule(type); // clear the module slot
    }

    private void SwapModule(ActiveModule newModule)
    {
        RemoveModule(newModule.ModuleType);
        AddModule(newModule);
    }
    private void TryToUse(ActiveModule module){
        if (module != null)
        {
            if (module.EnergyConsuption > player.Stats.CurrentEnergy)
            {
                // Show that there is no energy or cooldown
                return;
            }
            player.Stats.CurrentEnergy -= module.EnergyConsuption;
            module.Use(player);
            ModuleUse();
        }
    }
    private ActiveModule GetModule(ModuleType type)
    {
        return type switch
        {
            ModuleType.MainAttack => mainAttack,
            ModuleType.SecondAttack => secondAttack,
            ModuleType.Skill1 => skill1,
            ModuleType.Skill2 => skill2,
            ModuleType.Skill3 => skill3,
            ModuleType.Skill4 => skill4,
            _ => throw new InvalidEnumArgumentException()
        };
    }

    private void SetModule(ActiveModule module)
    {
        module.OnPickUpThis(player);
        switch (module.ModuleType)
        {
            case ModuleType.MainAttack:
                mainAttack = module;
                break;
            case ModuleType.SecondAttack:
                secondAttack = module;
                break;
            case ModuleType.Skill1:
                skill1 = module;
                break;
            case ModuleType.Skill2:
                skill2 = module;
                break;
            case ModuleType.Skill3:
                skill3 = module;
                break;
            case ModuleType.Skill4:
                skill4 = module;
                break;
            default:
                Game.LogError($"ModuleManager tried to use invalid module type: {module.ModuleType}");
                throw new InvalidEnumArgumentException();
        }
    }
    private void SetModule(ModuleType type)
    {
        switch (type)
        {
            case ModuleType.MainAttack:
                mainAttack = null;
                break;
            case ModuleType.SecondAttack:
                secondAttack = null;
                break;
            case ModuleType.Skill1:
                skill1 = null;
                break;
            case ModuleType.Skill2:
                skill2 = null;
                break;
            case ModuleType.Skill3:
                skill3 = null;
                break;
            case ModuleType.Skill4:
                skill4 = null;
                break;
            default:
                Game.LogError($"ModuleManager tried to use invalid module type: {type}");
                throw new InvalidEnumArgumentException();
        }
    }
}
