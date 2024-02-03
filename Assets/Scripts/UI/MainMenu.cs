using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(1);
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
}
