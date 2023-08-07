namespace Inventory
{
    public sealed class InventoryItem
    {
        public readonly InventoryItemId Id;
        private readonly InventoryItemParams _inventoryItemParams;

        public InventoryItem(InventoryItemId id, InventoryItemParams inventoryItemParams)
        {
            Id = id;
            _inventoryItemParams = inventoryItemParams;
        }
    }
}