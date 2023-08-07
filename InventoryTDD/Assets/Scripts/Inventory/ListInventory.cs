using System.Collections.Generic;
using System.Linq;

namespace Inventory
{
    public sealed class ListInventory
    {
        private readonly List<InventoryItem> _items = new();

        public void Add(InventoryItem item)
        {
            if (_items.Contains(item)) return;
            _items.Add(item);
        }

        public int GetItemCount(InventoryItemId itemId)
        {
            return _items.Count(i => i.Id == itemId);
        }

        public void Remove(InventoryItemId itemId)
        {
            if (!GetItemById(itemId, out var item)) return;
            _items.Remove(item);
        }

        private bool GetItemById(InventoryItemId itemId, out InventoryItem item)
        {
            item = _items.FirstOrDefault(i => i.Id == itemId);
            return item is not null;
        }
    }
}