using System;
using UnityEngine;

[Serializable]
public class DragonSettings : EnemySettings
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public int CritRate { get; private set; }
}
