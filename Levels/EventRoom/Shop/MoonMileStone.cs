using System;
using UnityEngine;
using Zenject;

public class MoonMileStone : MonoBehaviour, IInteract, IBuy
{
    [SerializeField] Player player;
    [SerializeField] int cost;
    public event Action OnUse;
    public event Action OnBuy;
    [Inject]
    void Construct(Player player)
    {
        this.player = player;
    }
    public void Buy()
    {
        player.MoonTokenCollector.SpendTokens(cost);
        InjectStat inject = new();
        if (UnityEngine.Random.Range(0, 101) == 100)
        {
            inject.AddEnergy();
        }
        else
        {
            inject.AddHealth();
        }

    }
    public void Use(object obj)
    {
        if (obj is InteractManager interactManager)
        {
            // multiply on level?
            if (player.MoonTokenCollector.Tokens >= cost)
            {
                Debug.Log("Moon tokens spent");
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
        return $"Moon Mile Stone";
    }

    public string GetDescription()
    {
        return $"Permanently increases to all your runs random stat \n Costs: {cost} Moon tokens. \n You currently have {new MoonTokeCollector().Tokens} tokens";
    }
}