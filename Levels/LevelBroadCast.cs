using System;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelEndBroadCast", menuName = "Custom/LevelEndBroadCast")]
public class LevelEndBroadCast : ScriptableObject 
{
    public event Action OnBroadCastEnter;
    public event Action OnTriggerEnd;

    public void Subscribe(){
        OnBroadCastEnter?.Invoke();
    }
    public void UnSubscribe(){
        OnTriggerEnd?.Invoke();
    }
}
