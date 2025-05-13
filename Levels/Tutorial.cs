using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Tutorial : MonoBehaviour
{
    [SerializeField] InteractButton button;
    public event Action OnTutorialEnd;
    void Start()
    {
        button.OnUse += End;
    }
    void End(){
        OnTutorialEnd?.Invoke();
    } 
}
