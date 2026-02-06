public class Cell : IReadOnlyCell
{
    private Item _item;
    private int _count;

    public int Count => _count;

    public Item CurrentItem => _item;

    public bool CanAddItem(Item item)
    {
        if (_item == null || _item.Name == item.Name)
            return true;

        return false;
    }
    public void AddItem(Item item)
    {
        _item = item;
        _count++;
    }

    public void RemoveItem(int receivedValue)
    {
        _count -= receivedValue;

        if (_count <= 0)
            ClearCell();
    }

    private void ClearCell()
    {
        _item = null;
        _count = 0;
    }
}
