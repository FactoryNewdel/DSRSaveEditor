namespace DSR.SlotDetails.InventoryDetails.Items;

public class CommonSoul : CommonItem
{
    private UInt32 _soulAmount;
    
    public CommonSoul(byte idSpace, uint id, uint amount, uint sorting, uint index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        ImagePath = ImagePath.Insert(ImagePath.LastIndexOf("\\", StringComparison.InvariantCulture) + 1, "Souls/");
    }

    public CommonSoul(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting)
    {
        ImagePath = ImagePath.Insert(ImagePath.LastIndexOf("\\", StringComparison.InvariantCulture) + 1, "Souls/");
    }

    public CommonSoul(CommonSoul commonSoul) : base(commonSoul)
    {
        _soulAmount = commonSoul._soulAmount;
    }

    public uint SoulAmount => _soulAmount;
}