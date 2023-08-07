using System;

namespace Inventory
{
    [Flags]
    public enum InventoryItemParams
    {
        None = 0,
        Stackable = 1,
        Equippable = 2,
        Consumable = 4,
        Effectable = 8
    }
}