using Unity.VisualScripting;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager _instance;
    public DataSave DataSave;

        private void Awake()
        {
            // ��������, �� ��� ���� ��������� GameController
            if (_instance == null)
            {
                // ���� ����, �� ��� ��������� GameController ��� ��������
                _instance = this;
                DontDestroyOnLoad(gameObject); // �� �������� GameController ��� ������� �� �������
            }
            else
            {
                // ���� ��� ���� ����� GameController, ������� ���
                Destroy(gameObject);
            }

            if (MainMenu.Instance != null)
            {
            MainMenu.Instance.OnSceneLoaded += Instance_OnSceneLoaded;
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
        string json = JsonUtility.ToJson(DataSave);
        PlayerPrefs.SetString("DataSave", json);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        string json = PlayerPrefs.GetString("DataSave");

        if (!string.IsNullOrEmpty(json))
        {
            DataSave = JsonUtility.FromJson<DataSave>(json);
        }
        else
        {
            // ���� ���� ���������� �����, ��������� ����� ��'��� ���
            DataSave = new DataSave();
        }
    }
}
