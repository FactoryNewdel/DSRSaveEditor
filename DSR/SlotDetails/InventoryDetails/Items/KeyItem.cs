namespace DSR.SlotDetails.InventoryDetails.Items;

public class KeyItem : Item
{
    public KeyItem(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        
    }

    public KeyItem(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting, 0)
    {
        
    }

}