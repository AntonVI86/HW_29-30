using UnityEngine;

namespace InventoryHomework
{
    public class InventoryView
    {
        private Inventory _inventory;

        public InventoryView(Inventory inventory)
        {
            _inventory = inventory;
            _inventory.Changed += ShowItems;
        }

        public void ShowItems()
        {
            foreach (Item item in _inventory.Items)
                Debug.Log($"{item.Name} - {item.Count}");
        }

        public void Dispose()
        {
            _inventory.Changed -= ShowItems;
        }
    }
}
