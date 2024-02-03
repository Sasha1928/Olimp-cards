using System.Collections;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;

    private int currentPlayerIndex;

    private void Awake()
    {
        currentPlayerIndex = 1;
    }

    private void Update()
    {
        StartCoroutine(AnimatorDelay());
    }

    private IEnumerator AnimatorDelay()
    {
        if (currentPlayerIndex == 1)
        {
         //   _playerCard.animator.Atactk();
            yield return new WaitForSeconds(1);
          //  _enemy.animator.Damage();
        }
        else
        {
          //  _oponnentCard.animator.Atactk();
            yield return new WaitForSeconds(1);
          //  _player.animator.Damage();
        }
        yield return new WaitForSeconds(1);

        TakeDamagePerson();
        NextXid();
    }

    private void NextXid()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 0;
        }
        else 
            currentPlayerIndex = 1;
    }

    private void TakeDamagePerson()
    {
        if (currentPlayerIndex == 1)
        {
            _enemy.GetDamage(_player.GetPlayerObjectSO().Damage);
        }
        else
        {
            _player.GetDamage(_enemy.GetEnemyObjectSO().Damage);
        }
    }
}
