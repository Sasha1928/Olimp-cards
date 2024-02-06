using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLernLogic : MonoBehaviour
{
    [SerializeField] private GameManegerSO _manegerSO;
    [SerializeField] private GameObject _learnCanvas, _levelCanvas;

    private void Awake()
    {
        if (_manegerSO.FirstStart)
        {
            _learnCanvas.SetActive(true);
            _levelCanvas.SetActive(false);
        }
        else
        {
            _learnCanvas.SetActive(false);
            _levelCanvas.SetActive(true);
        }
    }
}
