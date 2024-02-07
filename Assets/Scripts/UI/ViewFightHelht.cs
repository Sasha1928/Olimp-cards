using TMPro;
using UnityEngine;

public class ViewFightHelht : MonoBehaviour
{
    [SerializeField] private TMP_Text _player;
    [SerializeField] private TMP_Text _enemy;
    [SerializeField] private Fight _fight;

    private void Awake()
    {
        _fight.SetHealth += SetHealths;    
    }

    private void SetHealths(int playerXp, int enemyXp)
    {
        if (playerXp < 0)
        {
            _player.text = "0";
        }
        else if (enemyXp < 0)
        {
            _enemy.text = "0";
        }
        else
        {
        _player.text = playerXp.ToString();
        _enemy.text = enemyXp.ToString();
        }
    }
}
