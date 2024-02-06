using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllocationlStatsCharacter : MonoBehaviour
{
    [SerializeField] private GameManegerSO _gameManeger;
    [SerializeField] private EnemyObjectSO _character;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _hp,_armor,_damage,_crit;

    private void Awake()
    {
        _image.sprite = _character._sprite;
        _hp.text = _character.Helth.ToString();
        _armor.text = _character.Armor.ToString();
        _damage.text = _character.Damage.ToString();
        _crit.text = _character.CritDamage.ToString();
    }

    public void AllocationCharacter()
    {
        _gameManeger.PlyerObject = _character;
    }
}
