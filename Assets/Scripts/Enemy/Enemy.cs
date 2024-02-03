using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction DeadEnemy;

    [SerializeField] private EnemyObjectSO _enemyObjectSO;

    private int _helth;

    private void Awake()
    {
        _helth = _enemyObjectSO.Helth;
    }

    public EnemyObjectSO GetEnemyObjectSO()
    {
        return _enemyObjectSO;
    }

    public void GetDamage(int damage)
    {
        _helth -= damage;

        if (_helth <= 0)
        {
            // DeadEnemy?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
