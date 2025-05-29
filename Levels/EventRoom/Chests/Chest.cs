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
        int option = UnityEngine.Random.Range(0, 4);
        switch (option)
        {
            case 1:
                ItemSpawner.GetRandomCommonBodyPart(transform.position.x, transform.position.y + 0.2f);
                break;
            case 2:
                ItemSpawner.GetRandomCommonActiveModule(transform.position.x, transform.position.y + 0.2f);
                break;
            case 3:
                ItemSpawner.GetRandomCandy(transform.position.x, transform.position.y + 0.2f);
                break;
            default:
                ItemSpawner.GetRandomCommonItem(transform.position.x, transform.position.y + 0.2f);
                break;
        }
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