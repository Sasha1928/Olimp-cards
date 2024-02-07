using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; private set; }
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameManegerSO _gameManegerSO;
    [SerializeField] private Slider _sliderMuzic, _sliderSound;

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
        GameObject.FindGameObjectWithTag("NoDestroyObject").GetComponent<AudioSource>().volume = _sliderMuzic.value;
        _gameManegerSO.VolumeMusic = _sliderMuzic.value;
        _gameManegerSO.VolumeSound = _sliderSound.value;
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
