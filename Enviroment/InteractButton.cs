using System;
using UnityEngine;

public class InteractButton : MonoBehaviour, IInteract
{
    public event Action OnUse;
    public void Use(System.Object obj)
    {
        OnUse?.Invoke();
        Debug.Log("Button was used");
    }
}
