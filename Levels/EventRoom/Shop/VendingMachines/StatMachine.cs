using System;
using UnityEngine;
using Zenject;

public class StatMachine : MonoBehaviour, IInteract, IBuy 
{
    [SerializeField] Player player;
    [SerializeField] float cost;
    [SerializeField] int amount;
    [SerializeField] StatType type;
    public event Action OnUse;
    public event Action OnBuy;
    [Inject]
    void Construct(Player player)
    {
        this.player = player;
    }
    public void Buy()
    {
        player.Stats.CurrentMoney -= cost;
        player.Stats.Mediator.AddModifier(new StatModifier(type, new AddOperation((float)amount),0));
    }
    public void Use(object obj)
    {
        if (obj is InteractManager interactManager)
        {
            // multiply on level?
            if (player.Stats.CurrentMoney >= cost)
            {
                Buy();
            }
            else
            {
                // play cancel sound
            }
        }
    }

    public string GetTitle()
    {
        return $"Upgrade Machine";
    }

    public string GetDescription()
    {
        return $"Permanently increases {type} by {amount} \n Costs: {cost}";
    }
}