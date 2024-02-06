using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; private set; }
    [SerializeField] private GameObject _buttons;

    public event Action OnSceneLoaded;
    public void Exit()
    {
        OnSceneLoaded?.Invoke();
        Application.Quit();
    }
    public void PlayGame()
    {
        OnSceneLoaded?.Invoke();
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
        OnSceneLoaded?.Invoke();
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
