using FPP.Scripts.Enums;

namespace FPP.Scripts.Interfaces
{
    public interface IInventoryItem
    {
        public ItemType GetItemType();
        public float GetItemValue();
    }
}