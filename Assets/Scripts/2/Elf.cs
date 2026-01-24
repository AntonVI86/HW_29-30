using UnityEngine;

public class Elf : Enemy
{
    private EnemyType _type;

    private float _mana;

    public override void Initialize(EnemyType type, Vector3 position)
    {
        _type = type;
        transform.position = position;
    }

    public override void SetConfig(EnemySettings settings)
    {
        _mana = settings.GetMana(_type);
    }

    public override string GetName() => $"{_type}-Эльф";

    public override string GetStat() => $"Мана - {_mana}";
}
