using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField, Range(0,10)] private int _capacity;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new(_capacity);

        _inventoryView.Initialize(_inventory);

        _inventory.Add(new Item("Sword"));
        _inventory.Add(new Item("Sword"));
        _inventory.Add(new Item("Sword"));

        _inventory.Add(new Item("Shield"));
        _inventory.Add(new Item("Shield"));

        _inventory.Add(new Item("Sword"));
        _inventory.Add(new Item("Sword"));
        _inventory.Add(new Item("Sword"));

        _inventory.Add(new Item("Shield"));
        _inventory.Add(new Item("Shield"));

        _inventory.Add(new Item("Potion"));

        _inventoryView.Show();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _inventory.RemoveBy("Sword", 1);
            _inventoryView.Show();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _inventory.RemoveBy("Shield", 1);
            _inventoryView.Show();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _inventory.Add(new Item("Sword"));
            _inventoryView.Show();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _inventory.Add(new Item("Shield"));
            _inventoryView.Show();
        }
    }
}
