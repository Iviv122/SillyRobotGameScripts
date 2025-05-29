using Zenject;
using UnityEngine;

public class MoneyOnDeath : MonoBehaviour
{
    [Inject] private Player player;

    // Serialized fields so you can set them in the Unity Inspector
    [SerializeField] private float chance = 0.5f; // 50% chance by default
    [SerializeField] private int value = 1;      // Adds 10 money by default

    private void OnDestroy() {
        if (Random.value <= chance) {
            player.Stats.CurrentMoney += value;
        }
    }
}
