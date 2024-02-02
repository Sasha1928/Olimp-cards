using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _healf;
    [SerializeField] private float _damage;
    [SerializeField] private float _damageCrit;

    public float Damage => _damage;
    public float DamageCrit => _damageCrit;

    public event UnityAction Dead;
    private void GetDamage(float damage)
    {
        _healf -= damage;
        if (_healf <= 0)
        {
            Dead.Invoke();
        }
    }
}
