using Zenject;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float delay;  // Time in seconds for the fade to complete
    [SerializeField] SpriteRenderer sr;

    [Inject] private DiContainer _container;  // The Zenject container for object instantiation
    [SerializeField] CountdownTimer timer;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        
        // Initialize the timer with the provided delay.
        timer = new CountdownTimer(delay);

        // Subscribe to timer stop event
        timer.OnTimerStop += () => {
            GameObject spawnedEnemy = _container.InstantiatePrefab(enemyPrefab, transform.position, Quaternion.identity, null); 
            // `InstantiatePrefab` ensures Zenject handles the creation and lifecycle of the enemy object
            Destroy(gameObject);  // Destroy the spawner object after instantiation
        };

        timer.Start();

        // Calculate fade speed based on delay
        float fadeSpeed = 1f / delay;
        StartCoroutine(FadeObject.FadeOutObject(sr, fadeSpeed));
    }

    void Update() {
        timer.Tick(Time.deltaTime);
    }
}
