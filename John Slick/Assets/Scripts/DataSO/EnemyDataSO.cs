using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField][Range(1,10)]
    public int MaxHealth = 3;
    [SerializeField]
    [Range(1, 10)]
    public int Damage = 1;
}
