public class Ork : Enemy
{
    private int _strength;
    private int _damage;
    private int _armor;

    public void Initialize(OrkSettings settings)
    {
        _strength = settings.Strength;
        _damage = settings.Damage;
        _armor = settings.Armor;
    }

    public override string GetName() => $"Орк";

    public override string GetStats() 
    {
        string stats = 
            $"Сила - {_strength}\n" +
            $"Урон - {_damage}\n" +
            $"Броня - {_armor}";

        return stats;
    }
}
