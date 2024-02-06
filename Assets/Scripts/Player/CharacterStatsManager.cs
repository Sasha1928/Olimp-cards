using System;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }

    [SerializeField] private GameManegerSO _characterStatsSO;
    [SerializeField] private ShopManagerSO _shopManagerSO;

    private void Awake()
    {
        MainMenu.Instance.OnSceneLoaded += Instance_OnSceneLoaded;
        // ������ �������� �� �������� ���� ��ﳿ �����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // ���� ��� � ���� ����, �� ������� �������� ��'���
            Destroy(gameObject);
        }
    }

    private void Instance_OnSceneLoaded()
    {
        SaveData();
    }

    private void Start()
    {
        LoadData();
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(Instance);
        PlayerPrefs.SetString("CharacterStatsManager", json);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        string json = JsonUtility.ToJson(Instance);
        PlayerPrefs.SetString("CharacterStatsManager", "");

        if (!string.IsNullOrEmpty(json))
        {
            Instance = JsonUtility.FromJson<CharacterStatsManager>(json);
        }
        else
        {
            // ���� ���� ���������� �����, ��������� ����� ��'��� ���
            Instance = new CharacterStatsManager();
        }

    }

}
