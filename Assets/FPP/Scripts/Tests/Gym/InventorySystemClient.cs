using UnityEngine;
using FPP.Scripts.Core;
using FPP.Scripts.Systems;
using FPP.Scripts.Weaponry;
using FPP.Scripts.Ingredients.Bike.Elements;

namespace FPP.Scripts.Tests.Gym
{
    public class InventorySystemClient : MonoBehaviour
    {
        private Player _player;
        private SaveSystem _saveSystem;
        private InventorySystem _inventorySystem;
        public WeaponAttachment weaponAttachment;
        private BikeWeaponAttachment _bikeWeaponAttachment;
        
        void Start()
        {
            _player = new Player();
            _saveSystem = new SaveSystem();
            _inventorySystem = new InventorySystem(_player);
        }
        
        void OnGUI()
        {
            if (GUILayout.Button("Add Item"))
            {
                _bikeWeaponAttachment = new BikeWeaponAttachment(weaponAttachment);
                _inventorySystem.AddItem(_bikeWeaponAttachment);
                _saveSystem.SavePlayer(_player);
            }
            
            GUI.color = Color.green;
            GUI.Label(new Rect(100, 20, 500, 20), "Inventory Count: " +  _player.inventory.Count);
        }
    }
}