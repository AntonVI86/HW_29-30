using UnityEngine;

public class Dragon : Enemy
{
    private EnemyType _type;

    private float _defense;

    public override void Initialize(EnemyType type, Vector3 position)
    {
        _type = type;
        transform.position = position;
    }

    public override void SetConfig(EnemySettings settings)
    {
        _defense = settings.GetDefense(_type);
    }

    public override string GetName() => $"{_type}-Дракон";

    public override string GetStat() => $"Защита - {_defense}";
}
