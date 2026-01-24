using System;
using UnityEngine;

[Serializable]
public class ElfSettings : EnemySettings
{
    [field: SerializeField] public int Mana { get; private set; }
    [field: SerializeField] public int Agility { get; private set; }
    [field: SerializeField] public int ViewRange { get; private set; }
}
