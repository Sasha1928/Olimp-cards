using System;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }

    public DataSave DataSave;

    private void Awake()
    {
        // Робимо перевірку на наявність іншої копії класу
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Якщо вже є інша копія, то знищуємо поточний об'єкт
            Destroy(gameObject);
        }
    }
    
    private void Instance_OnSceneLoaded()
    {
        MainMenu.Instance.OnSceneLoaded += Instance_OnSceneLoaded;
        SaveData();
    }

    private void Start()
    {
        LoadData();
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(DataSave);
        PlayerPrefs.SetString(" DataSave", json);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        string json = JsonUtility.ToJson(DataSave);
        PlayerPrefs.SetString(" DataSave", "");

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
