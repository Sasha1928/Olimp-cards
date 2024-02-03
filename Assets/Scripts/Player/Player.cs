using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction DeadPlayer;

    [SerializeField] private EnemyObjectSO _playerObjectSO;

    private int _helth;

    private void Awake()
    {
        _helth = _playerObjectSO.Helth;
    }

    public EnemyObjectSO GetPlayerObjectSO()
    {
        return _playerObjectSO;
    }

    public void GetDamage(int damage)
    {
        _helth -= damage;

        if ( _helth <= 0)
        {
         //   DeadPlayer?.Invoke();
           gameObject.SetActive(false);
        }
    }
}
