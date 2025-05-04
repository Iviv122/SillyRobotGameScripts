using TMPro;
using UnityEngine;
using Zenject;

public class Dashboard : MonoBehaviour
{
    
    [SerializeField] private Player player;
    [SerializeField] TextMeshProUGUI currentHealth;
    [SerializeField] TextMeshProUGUI maxHealth;
    [SerializeField] TextMeshProUGUI speed;
    [SerializeField] TextMeshProUGUI energy;

    [Inject]
    private void Construct(Player _player){
        player = _player;
    }
    private void Start(){
        player.BaseStats.ValuesChanged += UpdateUI;
        player.Stats.ValuesChanged += UpdateUI;
        UpdateUI(); 
    }
    private void OnEnable() {
        UpdateUI();
    }
    void UpdateUI()
    {
        currentHealth.SetText("Current Health: " + player.BaseStats.CurrentHealth.ToString());
        maxHealth.SetText("Max Health: " + player.Stats.Health.ToString());
        speed.SetText("Speed: " + player.Stats.Speed.ToString());
        energy.SetText("Energy: " + player.Stats.Energy.ToString());
    }
}
