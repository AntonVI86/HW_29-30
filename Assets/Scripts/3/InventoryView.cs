using UnityEngine;

public class InventoryView : MonoBehaviour
{
    private Inventory _inventory;

    public void Initialize(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void Show()
    {
        foreach (Cell cell in _inventory.Cells)
        {
            if (cell.CurrentItem == null)
            {
                return;
            }

            Debug.Log($"{cell.CurrentItem.Name} - {cell.Count}");
        }
    }
}
