using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] LoadingBar loadingBar;

    [SerializeField] Game Game;
    [SerializeField] LevelGeneration LevelGeneration;
    //[SerializeField] LevelManager LevelManager;
    [SerializeField] SceneContext SceneDIContainer;
    //[SerializeField] GameObject LevelLayout;
    [SerializeField] Camera Camera;
    [SerializeField] Player Player;
    private async void Start()
    {
        loadingBar.gameObject.SetActive(true);

        BindingObjects();

        //_loadingScreen.Show();

        await InitializeObjects();
        loadingBar.SetProgress(30);
        await CreateObjects();
        loadingBar.SetProgress(60);

        PrepareGame();
        loadingBar.SetProgress(90);

        //_loadingScreen.Hide();


        StartGame();
        loadingBar.SetProgress(90);
        loadingBar.gameObject.SetActive(false);
    }
    private void BindingObjects()
    {

        SceneDIContainer = Instantiate(SceneDIContainer);
        LevelGeneration = SceneDIContainer.Container.InstantiatePrefab(LevelGeneration).GetComponent<LevelGeneration>();
        //LevelLayout = SceneDIContainer.Container.InstantiatePrefab(LevelLayout);

        Camera = SceneDIContainer.Container.InstantiatePrefab(Camera).GetComponent<Camera>();
        Player = SceneDIContainer.Container.InstantiatePrefab(Player).GetComponent<Player>();
        Game = SceneDIContainer.Container.InstantiatePrefab(Game).GetComponent<Game>();
    }
    private async Task InitializeObjects()
    {
        await Task.Yield();  // this ensures Unity finishes Start() for all components

        // Wait until LevelGen is fully initialized
        while (LevelGeneration == null || LevelGeneration.startingPoint == null || LevelGeneration.startingPoint.Length == 0)
        {
            await Task.Yield(); // yield until LevelGeneration is ready
        }

        Camera.GetComponent<CameraMove>().Target = Player.transform;
    }
    private async Task CreateObjects()
    {

    }
    private void PrepareGame()
    {
    }
    private void StartGame()
    {
        Game.StartGame();
    }
}