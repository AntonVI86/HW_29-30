using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Spawner
{
    private Ork _orkPrefab;
    private Elf _elfPrefab;
    private Dragon _dragonPrefab;

    public Spawner(Ork orkPrefab, Elf elfPrefab, Dragon dragonPrefab)
    {
        _orkPrefab = orkPrefab;
        _elfPrefab = elfPrefab;
        _dragonPrefab = dragonPrefab;
    }

    public Enemy SpawnEnemy(EnemySettings settings, Vector3 position)
    {
        switch (settings)
        {
            case OrkSettings orkSettings:
                Ork ork = Object.Instantiate(_orkPrefab, position, Quaternion.identity);
                ork.Initialize(orkSettings);
                return ork;

            case ElfSettings elfSettings:
                Elf elf = Object.Instantiate(_elfPrefab, position, Quaternion.identity);
                elf.Initialize(elfSettings);
                return elf;

            case DragonSettings dragonSettings:
                Dragon dragon = Object.Instantiate(_dragonPrefab, position, Quaternion.identity);
                dragon.Initialize(dragonSettings);
                return dragon;

            default:
                throw new ArgumentOutOfRangeException(nameof(settings), settings, null);
        }
    }
}
