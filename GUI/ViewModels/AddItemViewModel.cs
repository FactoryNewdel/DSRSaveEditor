using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;

namespace GUI.ViewModels;

public class AddItemViewModel
{
    private Inventory _inventory;
    private Item _item;

    public AddItemViewModel(Inventory inventory, Item item)
    {
        _inventory = inventory;
        _item = item;
    }

    public bool AddItem(uint amount)
    {
        if (amount <= 0) return false;
        _item.Amount = amount;
        return _inventory.AddItem(_item);
    }

    public Inventory Inventory => _inventory;

    public Item Item => _item;
}