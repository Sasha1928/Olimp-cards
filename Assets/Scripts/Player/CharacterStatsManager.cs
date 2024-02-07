using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager _instance;
    public DataSave DataSave;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
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

    private void OnApplicationQuit()
    {
        SaveData();
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
            DataSave = new DataSave();
        }
    }
}
