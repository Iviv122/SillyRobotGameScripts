using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrap : MonoBehaviour
{
    private async void Start(){

        BindingObjects();
        //_loadingScreen.Show();
        
        await InitializeObjects();
        // Do stuff
    
        //_loadingScreen.Hide();
    
        SceneManager.LoadScene("MainMenu"); 
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
