using System;
using UnityEngine;

abstract public class Trigger : MonoBehaviour
{
    public event Action OnTriggered;

    public void Triggered()
    {
        OnTriggered?.Invoke();
    }
}
