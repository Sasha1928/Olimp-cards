using UnityEngine;

[CreateAssetMenu()]
public class EnemyObjectSO : ScriptableObject
{
    public string ObjectName;
    public Transform Prefab;
    public int Helth;
    public int Armor;
    public int CritDamage;
    public int Damage;
}
