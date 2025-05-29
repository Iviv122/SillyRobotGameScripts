using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] LoadingBar loadingBar;

    [Scene]
    [SerializeField] string mainMenu; 
    private async void Start()
    {

        BindingObjects();
        //_loadingScreen.Show();

        await InitializeObjects();
        loadingBar.SetProgress(100);
        // Do stuff

        //_loadingScreen.Hide();

        SceneManager.LoadScene(mainMenu);
    }
    private void BindingObjects(){

    } 
    private async Task InitializeObjects(){

    }
    private async Task CreateObjects(){

    }
    private async Task PrepareGame(){

    }
}
