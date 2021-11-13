using FPP.Scripts.Core;
using FPP.Scripts.Interfaces;
using System.Collections.Generic;

namespace FPP.Scripts.Systems
{
    public class InventorySystem
    {
        private readonly Player _player;
        
        public InventorySystem(Player player)
        {
            _player = player;
            
            if (_player.inventory == null)
                _player.inventory = new List<IInventoryItem>();
        }

        public void AddItem(IInventoryItem item)
        {
            _player.inventory.Add(item);
        }

        public void RemoveItem(IInventoryItem item)
        {
            _player.inventory.Remove(item);
        }

        public float GetTotalValueOfInventory()
        {
            float totalValue = 0;

            foreach (IInventoryItem item in _player.inventory)
                totalValue += item.GetItemValue();
            
            return totalValue;
        }
    }
}