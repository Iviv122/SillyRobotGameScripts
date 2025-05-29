using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Hub : MonoBehaviour
{
    Player player;
    [SerializeField] LevelEndBroadCast levelEndBroadCast;

    [Scene]
    [SerializeField] string GameplayScene;

    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }
    void Awake()
    {
        levelEndBroadCast.OnTriggerEnd += ExitHub;   
    }
    public void ExitHub()
    {
        SceneManager.LoadScene(GameplayScene,LoadSceneMode.Single);
    }
}
