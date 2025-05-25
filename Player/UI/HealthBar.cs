using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider slider;
    [SerializeField] Player player;

    [Inject]
    public void Construct(Player player){
        this.player = player;
    }
    void Start()
    {
        player.Stats.ValuesChanged += HandleUpdate;
        HandleUpdate();
    }
    void HandleUpdate()
    {
        if(slider != null){
            slider.maxValue = player.Stats.Health;
            slider.value = player.Stats.CurrentHealth;
        }else{
            Debug.Log("No HealthBar Slider");
        }
    
        if(text != null){
            text.text = player.Stats.CurrentHealth + "/" + player.Stats.Health;
        }else{
            Debug.Log("No HealthBar Text");
        }
    }
}
