using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ManagerButton : MonoBehaviour
{
    [SerializeField] private EnemyObjectSO _playerObjectSO;
    [SerializeField] private EnemyObjectSO _shopObjectSO;
    [SerializeField] private Button[] _buttonsList;
    [SerializeField] private TMP_Text[] _buyTexts;
    [SerializeField] private TMP_Text[] _levelUpTexts;

    private void Awake()
    {
        _buttonsList[0].onClick.AddListener(() => LevelUp(ref _playerObjectSO.Helth, _shopObjectSO.Helth, ref _buyTexts[0], ref _levelUpTexts[0]));
        _buttonsList[1].onClick.AddListener(() => LevelUp(ref _playerObjectSO.Damage, _shopObjectSO.Damage, ref _buyTexts[1], ref _levelUpTexts[1]));
        _buttonsList[2].onClick.AddListener(() => LevelUp(ref _playerObjectSO.CritDamage, _shopObjectSO.CritDamage, ref _buyTexts[2], ref _levelUpTexts[2]));
        _buttonsList[3].onClick.AddListener(() => LevelUp(ref _playerObjectSO.Armor, _shopObjectSO.Armor, ref _buyTexts[3], ref _levelUpTexts[3]));

    }
    private void LevelUp(ref int getValue, int setValue, ref TMP_Text texts, ref TMP_Text textLevelUp)
    {
        getValue += setValue;
        BuyText(ref texts);
        LevelUpText(ref textLevelUp);
    }

    private void BuyText(ref TMP_Text textsBuy)
    {
        if(int.TryParse(textsBuy.text, out int intValue))
        {
            if(intValue < 100)
            {
                int money = int.Parse(textsBuy.text) + 10;
                textsBuy.text = money.ToString();

            }
        }
    }

    private void LevelUpText(ref TMP_Text textLevelUp)
    {
        string[] parts = textLevelUp.text.Split('/');

        if (parts.Length == 2 && int.TryParse(parts[0], out int intValue))
        {
            if (intValue < 10)
            {
            int money = intValue + 1;
            textLevelUp.text = $"{money}/10";
            }
        }
    }
}
