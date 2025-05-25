using System;
using UnityEngine;
using Zenject;

public class RandomItemMachine : MonoBehaviour, IInteract, IBuy 
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
        ItemSpawner.GetRandomCommonItem(transform.position.x, 0);
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
        return $"Vending Machine";
    }

    public string GetDescription()
    {
        return $"Buy random item \n Costs: {cost}";
    }
}