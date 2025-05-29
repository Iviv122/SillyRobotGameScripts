using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    [SerializeField] GameObject settingsMenu;
    [Scene] public string MainMenu;
    private bool isOn = false;
    private void Awake()
    {

        pausemenu.SetActive(isOn);
    }
    void PauseSwitch()
    {
        isOn = !isOn;
        pausemenu.SetActive(isOn);
        settingsMenu.SetActive(false);

        if (isOn)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Continue()
    {
        isOn = false;
        pausemenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainMenu);
    }
}