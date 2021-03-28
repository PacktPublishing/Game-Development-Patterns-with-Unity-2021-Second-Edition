using UnityEngine;

namespace Chapter.Adapter
{
    public class InventorySystemAdapter
    {
        public bool saveToDisk;

        private readonly InventorySystem _inventorySystem;
        
        public InventorySystemAdapter(InventorySystem inventorySystem)
        {
            _inventorySystem = inventorySystem;
        }
        
        public void AddItem(int itemID)
        {
            _inventorySystem.AddItem(itemID);

            if (saveToDisk)
            {
                // Implement here logic that calls local save system
                Debug.Log("Adding item {number} to local save".Replace("{number}", itemID.ToString()));
            }
        }

        public void RemoveItem(InventorySystem inventorySystem, int itemID)
        {
            _inventorySystem.AddItem(itemID);

            if (saveToDisk)
            {
                // Implement here logic that calls local save system
                Debug.Log("Removing item {number} from local save".Replace("{number}", itemID.ToString()));
            }
        }

        public void SyncToCloud()
        {
            // This method syncs the local and cloud inventory
        }
    }
}