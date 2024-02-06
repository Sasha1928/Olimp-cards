using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _buttons;

    public void Exit()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Figth");
    }
    public void SetingOpen(GameObject settingMenu)
    {
        settingMenu.SetActive(true);
        _buttons.SetActive(false);
    }
    public void SettingClose(GameObject settingMenu)
    {
        _buttons.SetActive(true);
        settingMenu.SetActive(false);
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OpenShop() 
    {
        SceneManager.LoadScene("Shop");
    }
    public void OpenLevelMenu()
    {
        SceneManager.LoadScene("Levels");
    }
}
