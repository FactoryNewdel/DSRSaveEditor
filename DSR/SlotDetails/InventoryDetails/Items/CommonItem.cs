namespace DSR.SlotDetails.InventoryDetails.Items;

public class CommonItem : Item
{
    public CommonItem(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        ImagePath += $"Items/{Type}.png";
    }

    public CommonItem(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting, 0)
    {
        ImagePath += $"Items/{Type}.png";
    }

    public CommonItem(CommonItem commonItem) : base(commonItem)
    {
        
    }
}