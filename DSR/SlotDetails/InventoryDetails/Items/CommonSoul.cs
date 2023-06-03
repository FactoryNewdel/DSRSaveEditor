namespace DSR.SlotDetails.InventoryDetails.Items;

public class CommonSoul : Item
{
    private UInt32 _soulAmount;
    
    public CommonSoul(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        
    }

    public CommonSoul(ItemType type, byte idSpace, uint id, uint sorting, uint durability) : base(type, idSpace, id, sorting, durability)
    {
        
    }

    public uint SoulAmount => _soulAmount;
}