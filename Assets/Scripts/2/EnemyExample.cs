using UnityEngine;

public class EnemyExample : MonoBehaviour
{
    private Spawner _spawner;

    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Dragon _dragonPrefab;


    [SerializeField] private OrkSettings[] _orkSettings;
    [SerializeField] private ElfSettings[] _elfSettings;
    [SerializeField] private DragonSettings[] _dragonSettings;

    private void Awake()
    {
        _spawner = new Spawner(_orkPrefab, _elfPrefab, _dragonPrefab);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _spawner.SpawnEnemy(_orkSettings[Random.Range(0, _orkSettings.Length)], GetPosition());
        if (Input.GetKeyDown(KeyCode.Alpha2))
            _spawner.SpawnEnemy(_elfSettings[Random.Range(0, _elfSettings.Length)], GetPosition());
        if (Input.GetKeyDown(KeyCode.Alpha3))
            _spawner.SpawnEnemy(_dragonSettings[Random.Range(0, _dragonSettings.Length)], GetPosition());
    }

    private Vector3 GetPosition()
    {
        float minPosX = 1;
        float maxPosX = 45;

        return new Vector3(Random.Range(minPosX, maxPosX), 0,0);
    }
}
