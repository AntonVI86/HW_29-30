using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Cell> _cells = new();

    private int _maxSize;

    public Inventory(int maxSize)
    {
        _maxSize = maxSize;

        for (int i = 0; i < _maxSize; i++)
            _cells.Add(new Cell());
    }

    public int CurrentSize => _cells.Sum(cell => cell.Count); 

    public IReadOnlyList<IReadOnlyCell> Cells => _cells;

    public void Add(Item item)
    {
        if (CanAddItem() == false)
            throw new ArgumentException("Инвентарь полон");

        foreach (Cell cell in _cells)
        {
            if (cell.CanAddItem(item))
            {
                cell.AddItem(item);
                return;
            }
        }
    }

    public bool TryRemoveBy(string name, int count)
    {
        foreach (Cell cell in _cells)
        {
            if (cell.CurrentItem == null)
                continue;

            if(cell.CurrentItem.Name == name)
            {
                if (cell.Count >= count)
                {
                    cell.RemoveItem(count);
                    return true;
                }
            }
        }
        
        return false;
    }

    public List<Cell> GetItemsBy(string name, int count)
    {
        Cell cell = _cells.FirstOrDefault(cell => cell.CurrentItem.Name == name);

        if (cell != null)
            cell.RemoveItem(count);

        return _cells;
    }

    private bool CanAddItem() => CurrentSize < _maxSize;
}