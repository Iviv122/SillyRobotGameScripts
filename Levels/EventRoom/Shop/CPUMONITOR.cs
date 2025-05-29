using System;
using UnityEngine;
using Zenject;

public class CPUMONITOR : MonoBehaviour, IInteract, IInfo
{
    [SerializeField] Player player;
    public event Action OnUse;
    public event Action OnBuy;
    [Inject]
    void Construct(Player player)
    {
        this.player = player;
    }
    public void Use(object obj)
    {
        if (obj is InteractManager interactManager)
        {
            InjectItems.NextCharacter();
        }
    }

    public string GetTitle()
    {
        return $"Unit SELECTOR";
    }

    public string GetDescription()
    {
        string o = "";
        switch (InjectItems.characterSet)
        {
            case 0:
                o = "Basic";
                break;
            case 1:
                o = "Funny Guy";
                break;
            case 2:
                o = "Glass Cannon";
                break;
        }
        return $"Choose your character! Use it to see and use next one! {o}";
    }
}