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
        player.BaseStats.ValuesChanged += HandleUpdate;
    }
    void HandleUpdate()
    {
        slider.maxValue = player.Stats.Health;
        slider.value = player.BaseStats.CurrentHealth;
    }
}
