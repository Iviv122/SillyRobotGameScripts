using System;
using UnityEngine;
using Zenject;

public class RefreshMachine : MonoBehaviour, IInteract, IBuy 
{
    [SerializeField] Player player;
    [SerializeField] float cost;

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
        player.Refresh(); 
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
        return $"First Aid Repair Machine";
    }

    public string GetDescription()
    {
        return $"Repairs you \n Costs: {cost}";
    }
}