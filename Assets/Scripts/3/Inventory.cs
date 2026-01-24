using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace InventoryHomework
{
    public class Inventory
    {
        public event Action Changed;

        private List<Item> _items = new();

        public IReadOnlyList<Item> Items => _items;

        public int CurrentSize => _items.Sum(item => item.Count);

        private int _maxSize;

        public Inventory(List<Item> items, int maxSize)
        {
            _items = new(items);
            _maxSize = maxSize;
        }

        public void Add(Item currentItem)
        {
            if (CurrentSize + currentItem.Count > _maxSize)
                return;

            if(HasItem(currentItem.Name, out Item item) == false)
            {
                _items.Add(item);
                return;
            }

            item.Add(1);
            _items.Add(item);
            Changed?.Invoke();
        }

        public void Remove(string name)
        {
            if (HasItem(name, out Item item))
            {
                _items.Remove(item);
                Changed?.Invoke();
            }
        }

        private bool HasItem(string name, out Item item)
        {
            item = _items.First(item => item.Name == name);

            if (item != null)
                return true;

            return false;
        }

        public List<Item> GetItemsBy(string name, int count)
        {
            _items = new List<Item>();

            for (int i = 0; i < count; i++)
            {
                Item item = _items.First(item => item.Name == name);
                _items.Remove(item);
            }

            return _items;
        }
    }
}