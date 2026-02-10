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

        Cell newCell = new Cell();
        _cells.Add(newCell);
        newCell.AddItem(item);
    }

    public bool TryRemoveBy(string name, int count)
    {
        foreach (Cell cell in Cells)
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

    public IReadOnlyList<Cell> GetItemsBy(string name, int count)
    {
        Cell cell = _cells.FirstOrDefault(cell => cell.CurrentItem.Name == name);

        if (TryRemoveBy(name, count) == false)
            throw new ArgumentException("Предмета с таким именем нет или его количества в ячейке недостаточно");

        return _cells;
    }

    private bool CanAddItem() => CurrentSize < _maxSize;
}