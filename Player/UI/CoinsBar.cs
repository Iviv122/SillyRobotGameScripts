using TMPro;
using UnityEngine;
using Zenject;

public class CoinsBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Player player;

    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }
    void Start()
    {
        player.Stats.ValuesChanged += HandleUpdate;
        HandleUpdate();
    }
    void HandleUpdate()
    {
            text.text = player.Stats.CurrentMoney.ToString();
    }

}