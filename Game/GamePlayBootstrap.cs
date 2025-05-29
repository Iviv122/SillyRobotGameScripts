using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayBootstrap : MonoBehaviour
{
    [Scene]
    public string GameplayScene;
    public void Start()
    {
        SceneManager.LoadScene(GameplayScene, LoadSceneMode.Single);   
    }
}