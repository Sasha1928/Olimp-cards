using UnityEngine;

[CreateAssetMenu()]
public class EnemyObjectSO : ScriptableObject
{
    public Sprite _sprite;
    public string ObjectName;
    public Transform Prefab;
    public int Helth;
    public int Armor;
    public int CritDamage;
    public int Damage;
    public int NomberLevel;
    public int Money;
}
