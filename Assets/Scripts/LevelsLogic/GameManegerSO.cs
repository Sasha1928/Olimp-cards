using UnityEngine;

[CreateAssetMenu()]
public class GameManegerSO : ScriptableObject
{
    public int LevelComplite = 1;
    [HideInInspector]public int VolumeMusic;
    [HideInInspector]public int VolumeSound;
    [HideInInspector]public EnemyObjectSO EnemyObject;
}
