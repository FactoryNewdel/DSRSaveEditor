namespace DSR.SlotDetails.InventoryDetails.Items;

public class SpecialItem : CommonItem
{
    public SpecialItem(byte idSpace, uint id, uint amount, uint sorting, uint index, bool enabled, uint durability, uint durabilityLoss) : base(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
    }

    public SpecialItem(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting)
    {
    }

    public SpecialItem(SpecialItem specialItem) : base(specialItem)
    {
        
    }

    public override uint MaxAmount => 1;
}