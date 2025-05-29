using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float value;
    void Start()
    {
    }
    public void SetProgress(float value)
    {
        this.value = value;
        UpdateValue();
    }
    void UpdateValue()
    {
        if(slider != null){
            slider.maxValue = 100;
            slider.value = value;
        }else{
            Debug.LogError("No Slider");
        }
    }
}
