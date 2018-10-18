using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Barrett/EnemyData", order = 0)]

public class EnemyData : ScriptableObject {
    
    public float spawnInterval;
    public float speed;
    public int maxEnemies;

}