using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ExpienceBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider slider;
    [SerializeField] Player player;

    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }
    void Start()
    {

        player.LevelUpManager.OnChange += HandleUpdate;
        HandleUpdate();
    }
    void HandleUpdate()
    {
        if (slider != null)
        {
            slider.maxValue = player.LevelUpManager.NextLevelExp;
            slider.value = player.LevelUpManager.CurrentExpirience;
        }
        else
        {
            Debug.Log("No Exp Slider");
        }
        if (text != null)
        {
            text.text = player.LevelUpManager.CurrentExpirience + "/" + player.LevelUpManager.NextLevelExp;
        }
        else
        {
            Debug.Log("No HealthBar Text");
        }
    }
}