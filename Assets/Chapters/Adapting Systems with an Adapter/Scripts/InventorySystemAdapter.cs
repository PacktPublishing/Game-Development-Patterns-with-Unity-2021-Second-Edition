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

            // TODO: Add item to local save file
            
            Debug.Log("Adding item to local save file");
        }

        public void RemoveItem(InventorySystem inventorySystem, int itemID)
        {
            _inventorySystem.AddItem(itemID);
            
            // TODO: Remove item from local save file
            
            Debug.Log("Removing item from local save file");
        }

        public void SyncInventory()
        {
            var list = _inventorySystem.GetInventoryList();
            
            // TODO: Merge the cloud and local inventory
            
            Debug.Log("Synchronizing  inventories");
        }
    }
}