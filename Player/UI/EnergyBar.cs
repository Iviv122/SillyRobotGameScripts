using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnergyBar : MonoBehaviour
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
        player.BaseStats.ValuesChanged += HandleUpdate;
        HandleUpdate();
    }
    void HandleUpdate()
    {
        if(slider != null){
            slider.maxValue = player.Stats.Energy;
            slider.value = player.BaseStats.CurrentEnergy;
        }else{
            Debug.Log("No HealthBar Slider");
        }
    
        if(text != null){
            text.text = player.BaseStats.CurrentEnergy + "/" + player.Stats.Energy;
        }else{
            Debug.Log("No HealthBar Text");
        }
    }
}
