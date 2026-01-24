public class Cell
{
    private Item _item;
    private int _count;

    public Item Item => _item;
    public int Count => _count;

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
