using System;

namespace Inventory
{
    public sealed class InventoryItemId : IEquatable<InventoryItemId>
    {
        private readonly string _itemId;

        public InventoryItemId(string itemId)
        {
            _itemId = itemId;
        }

        public bool Equals(InventoryItemId other)
        {
            return other is not null && string.Equals(_itemId, other._itemId, StringComparison.InvariantCulture);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is InventoryItemId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _itemId != null ? StringComparer.InvariantCulture.GetHashCode(_itemId) : 0;
        }

        public static bool operator ==(InventoryItemId left, InventoryItemId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InventoryItemId left, InventoryItemId right)
        {
            return !Equals(left, right);
        }
    }
}