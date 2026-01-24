public class Elf : Enemy
{
    private int _mana;
    private int _agility;
    private int _viewRange;

    public void Initialize(ElfSettings settings)
    {
        _mana = settings.Mana;
        _agility = settings.Agility;
        _viewRange = settings.ViewRange;
    }

    public override string GetName() => $"Эльф";

    public override string GetStats()
    {
        string stats =
            $"Мана - {_mana}\n" +
            $"Ловкость - {_agility}\n" +
            $"Дальность - {_viewRange}";

        return stats;
    }
}
