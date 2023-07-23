using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;

namespace GUI.ViewModels;

public class ChangeItemAmountViewModel
{
    private Item _item;

    public ChangeItemAmountViewModel(Item item)
    {
        _item = item;
    }

    public bool ChangeItemAmount(uint amount)
    {
        _item.Amount = amount;
        return true;
    }

    public Item Item => _item;
}