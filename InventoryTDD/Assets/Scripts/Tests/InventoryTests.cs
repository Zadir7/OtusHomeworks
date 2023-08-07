using Inventory;
using NUnit.Framework;

[TestFixture]
public class InventoryTests
{
    [Test]
    public void InventoryItemAdded()
    {
        var inventory = new ListInventory();
        var itemId = new InventoryItemId("Stone");
        var item = new InventoryItem(itemId, InventoryItemParams.None);

        inventory.Add(item);

        bool hasItem = inventory.GetItemCount(itemId) == 1;
        Assert.True(hasItem);
    }

    [Test]
    public void InventoryItemRemoved()
    {
        var inventory = new ListInventory();
        var itemId = new InventoryItemId("Stone");
        var item = new InventoryItem(itemId, InventoryItemParams.None);
        inventory.Add(item);

        inventory.Remove(itemId);

        bool hasNoItem = inventory.GetItemCount(itemId) == 0;
        Assert.True(hasNoItem);
    }
}
