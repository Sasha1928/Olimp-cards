using System.Collections;
using TMPro;
using UnityEngine;

public class Fight : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Animator _theEndImage;
    [SerializeField] private TMP_Text _textViner;

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
