using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryHomework
{
    public class Example : MonoBehaviour
    {
        private List<Item> _items = new();

        private Inventory _inventory;

        private int _maxSize = 10;

        private InventoryView _inventoryView;

        private void Awake()
        {
            _inventory = new Inventory(_items, _maxSize);
            Create();
            _inventoryView = new InventoryView(_inventory);
            _inventoryView.ShowItems();
        }

        private void Create()
        {
            _inventory.Add(new Item("Sword", 1));
            _inventory.Add(new Item("Bow", 5));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
                _inventory.Add(new Item("Ùèò", 1));

            if (Input.GetKeyDown(KeyCode.Alpha1))
                _inventory.Add(new Item("Ðóæü¸", 1));

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _inventory.Add(new Item("Êèíæàë", 1));

            if (Input.GetKeyDown(KeyCode.Alpha3))
                _inventory.Remove("Ùèò");
        }

        private void OnDestroy()
        {
            _inventoryView.Dispose();
        }
    }
}