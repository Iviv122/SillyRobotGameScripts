using System;
using TMPro;
using UnityEngine;

public class DelayCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float Delay = 3;
    CountdownTimer timer;
    public event Action OnEnd;

    void Awake(){
        timer = new(Delay);
        timer.Reset(Delay);
        timer.OnTimerStop += End;
    }
    public void Update()
    {
        timer.Tick(Time.deltaTime);
        text.text = timer.Time.ToString("F2");
    }
    public void StartCount(){
        timer.Start();
    }
    public void End(){
        OnEnd?.Invoke();
        gameObject.SetActive(false);
    }

}
