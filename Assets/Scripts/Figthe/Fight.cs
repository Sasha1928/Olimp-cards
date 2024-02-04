using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Animator _theEndImage;

    private int currentPlayerIndex;
    private Animator _playerAnimator;
    private Animator _enemyAnimator;
    private bool _coroutine = true;

    private void OnEnable()
    {
        _player.DeadPlayer += StopCorotine;
        _enemy.DeadEnemy += StopCorotine;
    }
    private void OnDisable()
    {
        _player.DeadPlayer -= StopCorotine;
        _enemy.DeadEnemy -= StopCorotine;
        
    }

    private void Awake()
    {
        _playerAnimator = _player.gameObject.GetComponent<Animator>();
        _enemyAnimator = _enemy.gameObject.GetComponent<Animator>();
        currentPlayerIndex = 1;
    }

    private void Start()
    {
        StartCoroutine(AnimatorDelay());
    }

    private IEnumerator AnimatorDelay()
    {
        yield return new WaitForSeconds(0.5f);
        if (currentPlayerIndex == 1)
        {
            _playerAnimator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.17f);
            _enemy.GetDamage(_player.GetPlayerObjectSO().Damage);
            currentPlayerIndex = 0;
            _enemyAnimator.SetTrigger("Block");
        }
        else
        {
            _enemyAnimator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.17f);
            _player.GetDamage(_enemy.GetEnemyObjectSO().Damage);
            currentPlayerIndex = 1;
            _playerAnimator.SetTrigger("Block");
        }
        if (_coroutine)
            StartCoroutine(AnimatorDelay());
    }

    private void StopCorotine()
    {
        _coroutine = false;
        _theEndImage.SetTrigger("TheEnd");
    }
}
