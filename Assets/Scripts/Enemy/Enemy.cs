using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public event UnityAction<bool> DeadEnemy;

    [SerializeField] private Image _image;
    [SerializeField] private GameManegerSO _gameManagerSO;

    private int _helth;

    private void Awake()
    {
        _image.sprite = _gameManagerSO.EnemyObject._sprite;
        _helth = _gameManagerSO.EnemyObject.Helth;
    }

    public EnemyObjectSO GetEnemyObjectSO()
    {
        return _gameManagerSO.EnemyObject;
    }

    public void GetDamage(int damage)
    {
        _helth -= damage;

        if (_helth <= 0)
        {
            if (_gameManagerSO.LevelComplite == _gameManagerSO.EnemyObject.NomberLevel)
                _gameManagerSO.LevelComplite++;

            DeadEnemy?.Invoke(true);
            gameObject.SetActive(false);
        }
    }
}
