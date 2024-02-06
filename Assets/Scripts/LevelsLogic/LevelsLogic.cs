using UnityEngine;
using UnityEngine.UI;

public class LevelsLogic : MonoBehaviour
{
    [SerializeField] private GameManegerSO _gameManager;
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        for (int i = 0; i <= _gameManager.LevelComplite; i++)
        {
                _buttons[i].interactable = true;
        }
    }

    public void ChangeCurentLevel(EnemyObjectSO enemyObjectSO)
    {
        _gameManager.EnemyObject = enemyObjectSO;
    }
}
