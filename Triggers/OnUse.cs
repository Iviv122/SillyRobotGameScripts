using System;
using UnityEngine;
public class OnUseInteract : Trigger, IInteract
{
    public event Action OnUse;
    [SerializeField] LevelEndBroadCast levelEndBroadCast;
    public void Construct(LevelEndBroadCast levelEndBroadCast)
    {
        this.levelEndBroadCast = levelEndBroadCast;
    }
    void Start()
    {
        levelEndBroadCast.Subscribe();
    }
    public void Use(System.Object obj)
    {
        levelEndBroadCast.UnSubscribe();
        Triggered();
    }
}
