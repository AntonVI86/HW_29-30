using System;
using UnityEngine;

[Serializable]
public class OrkSettings : EnemySettings
{
    [field: SerializeField] public int Strength { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Armor { get; private set; }
}
