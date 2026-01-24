using System.Collections.Generic;
using UnityEngine;

public class EnemyExample : MonoBehaviour
{
    private Spawner _spawner;

    [SerializeField] private List<Enemy> _prefabs;
    [SerializeField] private List<EnemySettings> _enemySettings;

    private void Awake()
    {
        _spawner = new(_enemySettings, _prefabs);
        _spawner.Spawn();
    }
}
