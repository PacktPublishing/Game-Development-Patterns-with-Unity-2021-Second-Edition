using UnityEngine;

namespace Chapter.Adapter
{
    public class InventorySystemAdapter
    {
        private readonly InventorySystem _inventorySystem;
        
        public InventorySystemAdapter(InventorySystem inventorySystem)
        {
            _inventorySystem = inventorySystem;
        }
        
        public void AddItem(int itemID)
        {
            _inventorySystem.AddItem(itemID);
            Debug.Log("Adding item {number} to local save".Replace("{number}", itemID.ToString()));
        }

        public void RemoveItem(InventorySystem inventorySystem, int itemID)
        {
            _inventorySystem.AddItem(itemID);
            Debug.Log("Removing item {number} from local save".Replace("{number}", itemID.ToString()));
        }
    }
}
