using UnityEngine;

namespace Chapter.Adapter
{
    public class ClientAdapter : MonoBehaviour
    {
        private InventorySystem _inventorySystem;
        private InventorySystemAdapter _inventorySystemAdapter;

        void Start()
        {
            _inventorySystem = new InventorySystem();
            _inventorySystemAdapter = new InventorySystemAdapter(_inventorySystem);
        }

        void OnGUI()
        {
            GUILayout.Label("Output in console");

            if (GUILayout.Button("Add item (no adapter)"))
                _inventorySystem.AddItem(89);

            if (GUILayout.Button("Add item (with adapter)"))
                _inventorySystemAdapter.AddItem(89);
        }
    }
}
