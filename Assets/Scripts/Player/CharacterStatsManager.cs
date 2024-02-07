using Unity.VisualScripting;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager _instance;
    public DataSave DataSave;

        private void Awake()
        {
            // Перевірка, чи вже існує екземпляр GameController
            if (_instance == null)
            {
                // Якщо немає, то цей екземпляр GameController стає головним
                _instance = this;
                DontDestroyOnLoad(gameObject); // Не видаляти GameController при переході між сценами
            }
            else
            {
                // Якщо вже існує інший GameController, знищуємо цей
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
            // Якщо немає збережених даних, створюємо новий об'єкт гри
            DataSave = new DataSave();
        }
    }
}
