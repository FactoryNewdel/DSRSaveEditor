namespace DSR.SlotDetails.InventoryDetails.Items;

public class SpecialItem : CommonItem
{
    public SpecialItem(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
    }

    public SpecialItem(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting)
    {
    }

    public override uint MaxAmount => 1;
}