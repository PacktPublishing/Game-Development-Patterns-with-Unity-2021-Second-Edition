using UnityEngine;

namespace Chapter.Adapter
{
    public class InventorySystem
    {
        public void AddItem(int itemID)
        {
            Debug.Log("Adding item to the cloud");
        }

        public void RemoveItem(int itemID)
        {
            Debug.Log("Removing item from the cloud");
        }
    }
}