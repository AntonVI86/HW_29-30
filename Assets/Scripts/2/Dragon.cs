public class Dragon : Enemy
{
    private int _damage;
    private int _health;
    private int _critRate;

    public void Initialize(DragonSettings settings)
    {
        _damage = settings.Damage;
        _health = settings.Health;
        _critRate = settings.CritRate;
    }

    public override string GetName() => $"Дракон";

    public override string GetStats()
    {
        string stats =
            $"Урон - {_damage}\n" +
            $"Здоровье - {_health}\n" +
            $"Крит.шанс - {_critRate}";

        return stats;
    }
}
