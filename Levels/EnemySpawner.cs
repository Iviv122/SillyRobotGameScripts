using Zenject;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float delay;  // Time in seconds for the fade to complete
    [SerializeField] SpriteRenderer sr;
    [SerializeField] LevelEndBroadCast EndBroadCast;

    [Inject] private DiContainer _container;  // The Zenject container for object instantiation
    [SerializeField] CountdownTimer timer;

    private GameObject spawnedEnemy;


    void Start()
    {
        Debug.Log("Enemy Spawned");
        sr = GetComponent<SpriteRenderer>();

        // Initialize the timer with the provided delay.
        if (timer != null)
        {
            if (!timer.IsRunning)
            {
                timer.Start();
            }
        }
        else
        {
            timer = new CountdownTimer(delay);
            timer.Start();
        }


        // Subscribe to timer stop event
        timer.OnTimerStop += Spawnenemy;
        timer.Start();

        // Calculate fade speed based on delay
        float fadeSpeed = 1f / delay;
        StartCoroutine(FadeObject.FadeOutObject(sr, fadeSpeed));
    }
    void Spawnenemy()
    {
        if(spawnedEnemy != null){
            return;
        }
        spawnedEnemy = _container.InstantiatePrefab(enemyPrefab, transform.position, Quaternion.identity, null);
        // `InstantiatePrefab` ensures Zenject handles the creation and lifecycle of the enemy object

        if (EndBroadCast)
        {
            spawnedEnemy.AddComponent<OnDeath>().Construct(EndBroadCast);
        }

        Destroy(gameObject);  // Destroy the spawner object after instantiation
    }
    void Update()
    {
        timer.Tick(Time.deltaTime);
    }
}
