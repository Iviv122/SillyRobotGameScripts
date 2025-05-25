using System;
using UnityEngine;

public class Chest : MonoBehaviour, IInteract
{
    public event Action OnUse;
    public event Action OnBuy;
    public void Use(object obj)
    {
        if (obj is InteractManager interactManager)
        {
            Open();
        }
        Destroy(gameObject);
    }

    public void Open()
    {
        ItemSpawner.GetRandomCommonItem(transform.position.x, transform.position.y+0.2f);
    }

    public string GetTitle()
    {
        return $"Chest";
    }

    public string GetDescription()
    {
        return $"Open me!";
    }
}