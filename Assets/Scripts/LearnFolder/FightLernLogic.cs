using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class FightLernLogic : MonoBehaviour
{
    [SerializeField] private GameManegerSO _manegerSO;
    [SerializeField] private Button[] _buttons;

    private void Awake()
    {
        if (_manegerSO.FirstStart)
        {
            foreach (var button in _buttons)
            {
                button.interactable = false;
            }
        }
        else
        {
            foreach (var button in _buttons)
            {
                button.interactable = true;
            }
        }
    }
}
