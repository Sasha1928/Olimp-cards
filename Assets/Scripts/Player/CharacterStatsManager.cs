using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }

    [SerializeField] private GameManegerSO _characterStatsSO;
    [SerializeField] private ShopManagerSO _shopManagerSO;

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
}
