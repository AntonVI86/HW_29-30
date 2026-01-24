using UnityEngine;

public class Ork : Enemy
{
    private EnemyType _type;

    private float _strength;

    public override void Initialize(EnemyType type, Vector3 position)
    {
        _type = type;
        transform.position = position;
    }

    public override void SetConfig(EnemySettings settings)
    {
        _strength = settings.GetStrength(_type);
    }

    public override string GetName() => $"{_type}-Орк";

    public override string GetStat() => $"Сила - {_strength}";
}
