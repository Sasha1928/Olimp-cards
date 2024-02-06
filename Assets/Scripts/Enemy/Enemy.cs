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

    public void GetDamage(int damage, int armor, int critDamage)
    {
        // Визначити кінцевий збиток, враховуючи захист
        int finalDamage = Mathf.Max(0, damage - armor);

        // Визначити, чи відбудеться критичний удар
        bool isCritHit = Random.Range(0, 100) < critDamage;

        // Застосувати збиток
        _helth -= isCritHit ? finalDamage * 2 : finalDamage;

        if (_helth <= 0)
        {
            if (_gameManagerSO.LevelComplite == _gameManagerSO.EnemyObject.NomberLevel)
                _gameManagerSO.LevelComplite++;

            DeadEnemy?.Invoke(true);
            gameObject.SetActive(false);
        }
    }
}
