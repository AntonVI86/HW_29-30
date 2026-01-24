using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private List<Enemy> _enemyPrefabs;
    private List<EnemySettings> _enemySettings;
    private float _defaultPositionX = 0;
    private float _offset = 5f;

    public Spawner(List<EnemySettings> enemySettings, List<Enemy> enemyPrefabs)
    {
        _enemySettings = enemySettings;
        _enemyPrefabs = enemyPrefabs;
    }

    public void Spawn()
    {
        for (int i = 0; i < _enemySettings.Count; i++)
        {
            for (int j = 0; j < _enemyPrefabs.Count; j++)
            {
                _defaultPositionX += _offset;
                Vector3 newPosition = new Vector3(_defaultPositionX, 0,0);

                Enemy enemy = Object.Instantiate(_enemyPrefabs[j]);
                enemy.Initialize((EnemyType)i, newPosition);
                enemy.SetConfig(_enemySettings[i]);
            }
        }
    }
}
