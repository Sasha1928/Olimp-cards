using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager Instance { get; private set; }

    [SerializeField] private GameManegerSO _characterStatsSO;
    [SerializeField] private ShopManagerSO _shopManagerSO;

    private void Awake()
    {
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
}
