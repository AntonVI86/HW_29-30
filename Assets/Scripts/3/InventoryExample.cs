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

        //_inventory.Add(new Item("Potion"));

        _inventoryView.Show();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (_inventory.TryRemoveBy("Sword", 1))
                Debug.Log("Предмет удалён из инвентаря");

            _inventoryView.Show();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(_inventory.TryRemoveBy("Shield", 1))
                Debug.Log("Предмет удалён из инвентаря");

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

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            _inventory.GetItemsBy("Sword", 5);
            _inventoryView.Show();
        }
    }
}
