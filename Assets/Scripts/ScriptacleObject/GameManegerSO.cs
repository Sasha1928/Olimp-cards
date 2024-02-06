using UnityEngine;

[CreateAssetMenu()]
public class GameManegerSO : ScriptableObject
{
    public bool FirstStart = true;
    public int LevelComplite = 1;
    [HideInInspector]public int VolumeMusic;
    [HideInInspector]public int VolumeSound;
    public EnemyObjectSO EnemyObject;
    public EnemyObjectSO PlyerObject;
}
