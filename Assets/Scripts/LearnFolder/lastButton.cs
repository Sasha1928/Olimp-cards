using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lastButton : MonoBehaviour
{
    [SerializeField] private GameManegerSO _managerSO;
    [SerializeField] private Button _buttonDamage, _buttonMenu;
    public void AccessToButton()
    {
        if (_managerSO.FirstStart)
        {
            _buttonDamage.interactable = false;
            _buttonMenu.interactable = true;
        }
    }
    public void EndTutorial()
    {
        _managerSO.FirstStart = false;
    }
}
