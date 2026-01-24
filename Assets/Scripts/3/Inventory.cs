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
        {
            _cells.Add(new Cell());
        }
    }

    public int CurrentSize => _cells.Sum(cell => cell.Count); 

    public IReadOnlyList<Cell> Cells => _cells;

    public void Add(Item item)
    {
        if (CanAddItem() == false) 
            return;       

        foreach (Cell cell in _cells)
        {
            if (cell.CanAddItem(item))
            {
                cell.AddItem(item);
                return;
            }
        }
    }

    public void RemoveBy(string name, int count)
    {
        foreach (Cell cell in _cells)
        {
            if (cell.Item == null)
                return;

            if(cell.Item.Name == name)
            {
                if (cell.Count >= count)
                {
                    cell.RemoveItem(count);
                    return;
                }
            }

            UnityEngine.Debug.Log("Предмет не найден или его не достаточно");
        }
    }

    public List<Cell> GetItemsBy(string name, int count)
    {
        _cells = new List<Cell>();

        for (int i = 0; i < count; i++)
        {
            Cell cell = _cells.FirstOrDefault(cell => cell.Item.Name == name);
            cell.RemoveItem(count);
        }

        return _cells;
    }

    private bool CanAddItem() => CurrentSize < _maxSize;
}