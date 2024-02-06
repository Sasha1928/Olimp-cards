using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public event UnityAction<bool> DeadEnemy;

    [SerializeField] private Image _image;
    [SerializeField] private GameManegerSO _gameManagerSO;
    [SerializeField] private TMP_Text _hp, _armor, _damage, _crit;

    private int _helth;

    private void Awake()
    {
        _image.sprite = _gameManagerSO.EnemyObject._sprite;
        _hp.text = _gameManagerSO.EnemyObject.Helth.ToString();
        _armor.text = _gameManagerSO.EnemyObject.Armor.ToString();
        _damage.text = _gameManagerSO.EnemyObject.Damage.ToString();
        _crit.text = _gameManagerSO.EnemyObject.CritDamage.ToString();
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
            if (_gameManagerSO.LevelComplite == _gameManagerSO.EnemyObject.NomberLevel - 1)
                _gameManagerSO.LevelComplite++;

            DeadEnemy?.Invoke(true);
            gameObject.SetActive(false);
        }
    }
}
