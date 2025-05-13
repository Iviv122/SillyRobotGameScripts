using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int TriggersCount;
    [SerializeField] Trigger EndTrigger;
    [SerializeField] LevelEndBroadCast levelEndBroadCast;
    public event Action OnLevelEnd;

    public void Start()
    {
        if (EndTrigger != null)
        {
            EndTrigger.OnTriggered += TryEndLevel;
        }
        if (levelEndBroadCast != null)
        {
            levelEndBroadCast.OnBroadCastEnter += increaseCounter;
            levelEndBroadCast.OnTriggerEnd += SubjectiveClear;
            levelEndBroadCast.OnTriggerEnd += TryEndLevel;
        }
    }
    void increaseCounter()
    {
        TriggersCount++;
    }
    public void SubjectiveClear(){
        TriggersCount--;
    }  
    void TryEndLevel()
    {
        if (TriggersCount <= 0)
        {
            EndLevel();
        }
    }
    void EndLevel()
    {
        if (EndTrigger != null)
        {
            EndTrigger.OnTriggered -= TryEndLevel;
        }
        if (levelEndBroadCast != null)
        {
            levelEndBroadCast.OnBroadCastEnter -= increaseCounter;
            levelEndBroadCast.OnTriggerEnd -= TryEndLevel;
        }
        OnLevelEnd?.Invoke();
    }
}
