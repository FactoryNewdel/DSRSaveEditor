namespace DSR.SlotDetails.InventoryDetails.Items;

public class CommonSoul : CommonItem
{
    private UInt32 _soulAmount;
    
    public CommonSoul(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        
    }

    public CommonSoul(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting)
    {
        
    }

    public CommonSoul(CommonSoul commonSoul) : base(commonSoul)
    {
        
    }

    public uint SoulAmount => _soulAmount;
}