using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllocationlStats : MonoBehaviour
{
    [SerializeField] private GameManegerSO _gameManeger;
    [SerializeField] private TMP_Text _hp, _armor, _damage, _crit;

    private void Awake()
    {
        Allocation();
    }
    public void Allocation()
    {
        _hp.text = _gameManeger.PlyerObject.Helth.ToString();
        _armor.text = _gameManeger.PlyerObject.Armor.ToString();
        _damage.text = _gameManeger.PlyerObject.Damage.ToString();
        _crit.text = _gameManeger.PlyerObject.CritDamage.ToString();
    }
}
