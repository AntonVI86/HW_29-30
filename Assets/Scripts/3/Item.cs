public class Item : IReadOnlyItem
{
    public Item(string name)
    {
        Name = name;
    }

    public string Name{ get; private set; }
}
