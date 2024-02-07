using UnityEngine;

[CreateAssetMenu()]
public class GameManegerSO : ScriptableObject
{
    
    public bool FirstStart = true;
    public int LevelComplite = 1;
    public AudioSource[] Muzic;
    public AudioSource[] Sound;
    [HideInInspector]public float VolumeMusic;
    [HideInInspector]public float VolumeSound;
    public EnemyObjectSO EnemyObject;
    public EnemyObjectSO PlyerObject;
}
