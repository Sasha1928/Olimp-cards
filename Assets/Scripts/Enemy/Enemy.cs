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
    [SerializeField] private ParticleSystem _particleSystem;
 
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

    public int Health()
    {
        return _helth;
    }

    public void GetDamage(int damage, int armor, int critDamage)
    {
        // Визначаємо фактор захисту, де 1.0 представляє 100% захисту
        float protectionFactor = 1f - armor / 100f;

        // Розраховуємо кінцевий збиток, враховуючи захист
        int finalDamage = Mathf.Max(0, Mathf.RoundToInt(damage * protectionFactor));

        // Визначаємо, чи відбудеться критичний удар
        bool isCritHit = Random.Range(0, 100) < critDamage;

        // Застосовуємо збиток
        _helth -= isCritHit ? finalDamage * 2 : finalDamage;

        _particleSystem.Play();

        if (_helth <= 0)
        {
            if (_gameManagerSO.LevelComplite == _gameManagerSO.EnemyObject.NomberLevel - 1)
                _gameManagerSO.LevelComplite++;

            DeadEnemy?.Invoke(true);
            gameObject.SetActive(false);
        }
    }
}
