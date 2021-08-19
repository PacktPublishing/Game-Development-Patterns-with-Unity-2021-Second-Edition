using UnityEngine;
using FPP.Scripts.Core;
using FPP.Scripts.Systems;
using FPP.Scripts.Weaponry;
using FPP.Scripts.Ingredients.Bike.Elements;

namespace FPP.Scripts.Tests.Gym
{
    public class InventorySystemClient : MonoBehaviour
    {
        public WeaponAttachment weaponAttachment;
        private BikeWeaponAttachment bikeWeaponAttachment;
        
        void Start()
        {
            SaveSystem saveSystem = new SaveSystem();

            Player player = new Player();
            
            InventorySystem inventorySystem = new InventorySystem(player);

            bikeWeaponAttachment = new BikeWeaponAttachment(weaponAttachment);
            inventorySystem.AddItem(bikeWeaponAttachment);
            
            saveSystem.SavePlayer(player);

            Debug.Log(player.inventory.Count.ToString());
        }
    }
}