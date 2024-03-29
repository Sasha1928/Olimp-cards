using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerButton : MonoBehaviour
{
    [SerializeField] private GameManegerSO _playerObjectSO;
    [SerializeField] private ShopManagerSO _shopManagerSO;
    [SerializeField] private ShopObjectSO _shopObjectSO;
    [SerializeField] private Button[] _buttonsList;
    [SerializeField] private TMP_Text[] _buyTexts;
    [SerializeField] private TMP_Text[] _levelUpTexts;
    [SerializeField] private ParticleSystem[] _particleSistem;
    [SerializeField] private TMP_Text _shopMoney;

    private AllocationlStats _stats;

    private void Awake()
    {
        _buttonsList[0].onClick.AddListener(() => LevelUp(ref _playerObjectSO.PlyerObject.Helth, _shopObjectSO.Helth, ref _buyTexts[0], ref _levelUpTexts[0], _particleSistem[0]));
        _buttonsList[1].onClick.AddListener(() => LevelUp(ref _playerObjectSO.PlyerObject.Damage, _shopObjectSO.Damage, ref _buyTexts[1], ref _levelUpTexts[1], _particleSistem[1]));
        _buttonsList[2].onClick.AddListener(() => LevelUp(ref _playerObjectSO.PlyerObject.CritDamage, _shopObjectSO.CritDamage, ref _buyTexts[2], ref _levelUpTexts[2], _particleSistem[2]));
        _buttonsList[3].onClick.AddListener(() => LevelUp(ref _playerObjectSO.PlyerObject.Armor, _shopObjectSO.Armor, ref _buyTexts[3], ref _levelUpTexts[3], _particleSistem[3]));

        _shopMoney.text = _playerObjectSO.PlyerObject.Money.ToString();
        _stats = GetComponent<AllocationlStats>();
    }

    private void Start()
    {
        SetParametersShop();
    }

    private void LevelUp(ref int getValue, int setValue, ref TMP_Text texts, ref TMP_Text textLevelUp, ParticleSystem partile)
    {

        if (GetMoney(int.Parse(texts.text), ref _playerObjectSO.PlyerObject.Money))
        {
            getValue += setValue;

            BuyText(ref texts);
            LevelUpText(ref textLevelUp);
            SaveParametersShop(texts, textLevelUp);
            _stats.Allocation();

            partile.Play();
        }
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

    private void SaveParametersShop(TMP_Text textsBuy, TMP_Text textLevelUp)
    {
        for (int i = 0; i < _buttonsList.Length; i++)
        {
            if (textsBuy == _buyTexts[i] && textLevelUp == _levelUpTexts[i]) 
            {
                _shopManagerSO.SaveStatsBuys[i] = int.Parse(textsBuy.text);
                SaveLevelUpParametr(ref _shopManagerSO.SaveStats[i], textLevelUp);
            }
        }
    }

    private void SaveLevelUpParametr(ref int money, TMP_Text textLevelUp)
    {
        string[] parts = textLevelUp.text.Split('/');

        if (parts.Length == 2 && int.TryParse(parts[0], out int intValue))
        {
            money = intValue;
        }
    }

    private void SetParametersShop()
    {
        for (int i = 0; i < _buttonsList.Length; i++)
        {
            _buyTexts[i].text = _shopManagerSO.SaveStatsBuys[i].ToString();
            _levelUpTexts[i].text = $"{_shopManagerSO.SaveStats[i]}/10";
        }
    }

    private bool GetMoney(int money, ref int playerMoney)
    {
        if (playerMoney >= money)
        {
            playerMoney -= money;
            _shopMoney.text = playerMoney.ToString();

            return true;
        }
        return false;
    }
}
