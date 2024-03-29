using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Fight : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Animator _theEndImage;
    [SerializeField] private TMP_Text _textViner;
    [SerializeField] private AudioSource _fightSound;

    public event Action<int, int> SetHealth;

    private int currentPlayerIndex;
    private Animator _playerAnimator;
    private Animator _enemyAnimator;
    private bool _coroutine = true;

    private void OnEnable()
    {
        _player.DeadPlayer += StopFight;
        _enemy.DeadEnemy += StopFight;
    }
    private void OnDisable()
    {
        _player.DeadPlayer -= StopFight;
        _enemy.DeadEnemy -= StopFight;       
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
            _enemy.GetDamage(_player.GetPlayerObjectSO().Damage, _player.GetPlayerObjectSO().Armor, _player.GetPlayerObjectSO().CritDamage);
            SetHealth?.Invoke(_player.Health(), _enemy.Health());
            currentPlayerIndex = 0;
            _enemyAnimator.SetTrigger("Block");
        }
        else
        {
            _enemyAnimator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.17f);
            _player.GetDamage(_enemy.GetEnemyObjectSO().Damage, _enemy.GetEnemyObjectSO().Armor, _enemy.GetEnemyObjectSO().CritDamage);
            SetHealth?.Invoke(_player.Health(), _enemy.Health());
            currentPlayerIndex = 1;
            _playerAnimator.SetTrigger("Block");
        }
        _fightSound.Play();
        if (_coroutine)
            StartCoroutine(AnimatorDelay());
    }

    private void StopFight(bool Viner)
    {
        _coroutine = false;
        _theEndImage.SetTrigger("TheEnd");
        if (Viner)
        {
            _textViner.text = "Victory";
            AddMoney(_enemy.GetEnemyObjectSO().Money);         
        }
        else
            _textViner.text = "Loss";
    }

    private void AddMoney(int money)
    {
        _player.GetPlayerObjectSO().Money += money;
    }
}
