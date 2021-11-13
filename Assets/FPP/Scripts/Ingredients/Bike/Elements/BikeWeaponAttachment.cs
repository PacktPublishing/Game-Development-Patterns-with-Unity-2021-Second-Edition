using System;
using FPP.Scripts.Enums;
using FPP.Scripts.Weaponry;
using FPP.Scripts.Interfaces;

namespace FPP.Scripts.Ingredients.Bike.Elements
{
    [Serializable]
    public class BikeWeaponAttachment : IInventoryItem
    {
        public BikeWeaponAttachment(WeaponAttachment weaponAttachment) { }
        
        public ItemType GetItemType()
        {
            throw new System.NotImplementedException();
        }

        public float GetItemValue()
        {
            throw new System.NotImplementedException();
        }
    }
}