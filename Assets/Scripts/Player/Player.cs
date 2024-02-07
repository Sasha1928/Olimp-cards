using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public event UnityAction<bool> DeadPlayer;

    [SerializeField] private GameManegerSO _playerObjectSO;
    [SerializeField] private Image _playerImage;
    [SerializeField] private TMP_Text _hp, _armor, _damage, _critDamage;

    private int _helth;

    private void Awake()
    {
        _playerImage.sprite = _playerObjectSO.PlyerObject._sprite;
        _hp.text = _playerObjectSO.PlyerObject.Helth.ToString();
        _armor.text = _playerObjectSO.PlyerObject.Armor.ToString();
        _damage.text = _playerObjectSO.PlyerObject.Damage.ToString();
        _critDamage.text = _playerObjectSO.PlyerObject.CritDamage.ToString();
        _helth = _playerObjectSO.PlyerObject.Helth;
    }

    public EnemyObjectSO GetPlayerObjectSO()
    {
        return _playerObjectSO.PlyerObject;
    }

    public int Health()
    {
        return _helth;
    }

    public void GetDamage(int damage, int armor, int critDamage)
    {
        // Визначити кінцевий збиток, враховуючи захист
        int finalDamage = Mathf.Max(0, Mathf.RoundToInt(damage * (1 - armor)));

        // Визначити, чи відбудеться критичний удар
        bool isCritHit = Random.Range(0, 100) < critDamage;

        // Застосувати збиток
        _helth -= isCritHit ? finalDamage * 2 : finalDamage;

        if ( _helth <= 0)
        {
           DeadPlayer?.Invoke(false);
           gameObject.SetActive(false);
        }
    }
}
