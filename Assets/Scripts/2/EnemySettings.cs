using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class EnemySettings
{
    [SerializeField] private List<EnemyConfig> _enemyConfigs;

    public float GetStrength(EnemyType type) 
        => _enemyConfigs.First(config => config.Type == type).Strength;
    public float GetDefense(EnemyType type)
        => _enemyConfigs.First(config => config.Type == type).Defense;
    public float GetMana(EnemyType type)
        => _enemyConfigs.First(config => config.Type == type).Mana;

    [Serializable]
    private class EnemyConfig
    {
        [field: SerializeField] public EnemyType Type { get; private set; }
        [field: SerializeField] public float Strength { get; private set; }
        [field: SerializeField] public float Defense { get; private set; }
        [field: SerializeField] public float Mana { get; private set; }
    }
}
