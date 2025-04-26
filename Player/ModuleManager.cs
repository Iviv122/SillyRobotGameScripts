using System.ComponentModel;

public class ModuleManager
{
    readonly Player player;

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

    ActiveModule mainAttack;
    ActiveModule secondAttack;
    ActiveModule skill1;
    ActiveModule skill2;
    ActiveModule skill3;
    ActiveModule skill4;

    // Input handlers
   public void OnLeftMouse() => mainAttack?.Use(player);
   public void OnRightMouse() => secondAttack?.Use(player);
   public void OnE() => skill1?.Use(player);
   public void OnQ() => skill2?.Use(player);
   public void OnR() => skill3?.Use(player);
   public void OnShift() => skill4?.Use(player);

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

    public void RemoveModule(ModuleType type)
    {
        SetModule(type);
        //DropModule(ModuleType type);
        // TODO: Drop module on ground 
    }

    private void SwapModule(ActiveModule newModule)
    {
        RemoveModule(newModule.ModuleType);
        AddModule(newModule);
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
