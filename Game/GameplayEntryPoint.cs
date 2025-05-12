using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] Game Game;
    [SerializeField] SceneContext SceneDIContainer;
    [SerializeField] GameObject LevelLayout;
    [SerializeField] Camera Camera;
    [SerializeField] Player Player;
    private async void Start(){

        BindingObjects();

        //_loadingScreen.Show();
        
        await InitializeObjects();
        await CreateObjects();
        await PrepareGame();
        //_loadingScreen.Hide();


        StartGame();
    }
    private void BindingObjects(){
        
        SceneDIContainer = Instantiate(SceneDIContainer);
        Camera = SceneDIContainer.Container.InstantiatePrefab(Camera).GetComponent<Camera>();
        LevelLayout = SceneDIContainer.Container.InstantiatePrefab(LevelLayout);
        Player = SceneDIContainer.Container.InstantiatePrefab(Player).GetComponent<Player>();
        Game = SceneDIContainer.Container.InstantiatePrefab(Game).GetComponent<Game>();
    } 
    private async Task InitializeObjects(){
    }
    private async Task CreateObjects(){

    }
    private async Task PrepareGame(){
        Player.transform.position = new Vector3(0,-9,0);
        Game.transform.position = new Vector3(0,0,0);
    }
    private void StartGame(){
       Game.StartGame(); 
    }
}