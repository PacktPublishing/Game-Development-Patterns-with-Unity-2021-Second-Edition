using System.Collections.Generic;
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

        public List<int> GetInventoryList()
        {
            Debug.Log("Returning item list stored in the cloud");
            return new List<int>(); // returning empty list for testing purposes
        }
    }
}