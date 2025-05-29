using System;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    Player player;
    LevelGeneration levelGen;
    [SerializeField] LevelEndBroadCast levelEndBroadCast;
    [SerializeField] int Counter;
    public event Action OnPlayerHide;

    [Inject]
    public void Construct(Player player, LevelGeneration LevelGen)
    {
        this.player = player;
        this.levelGen = LevelGen;

    }
    void Awake()
    {
        
        levelGen.StopGenerate();
        this.OnPlayerHide += GenerateLevel;

        levelGen.OnEntrancePlaced += PlacePlayer;
        levelEndBroadCast.OnTriggerEnd += TryEndLevel;
    }
    void TryEndLevel()
    {
        NextLevel();
    }
    public void StartGame()
    {
        NextLevel();
    }
    public void NextLevel()
    {
        HidePlayer();
    }
    void GenerateLevel()
    {
        if (levelGen == null)
        {
            levelGen = FindAnyObjectByType<LevelGeneration>().GetComponent<LevelGeneration>();
        }
        if (Counter > 10)
        {
            GenerateFinalBossFight();
            return;
        }
        Counter++;
        levelGen.GenerateFromZero();
    }
    void GenerateFinalBossFight()
    {
        levelGen.GenerateFinalBossFight();
    }
    void HidePlayer()
    {
        Debug.Log($"Player is null? {player == null}, Destroyed? {!player}");
        if (player == null)
        {
            player = FindAnyObjectByType<Player>().GetComponent<Player>();
        }
        player.gameObject.transform.position = new Vector3(-100, -100, -100);
        OnPlayerHide?.Invoke();
    }

    private void PlacePlayer()
    {
        levelGen.PlaceOnSpawn(player.transform);
    }
}
