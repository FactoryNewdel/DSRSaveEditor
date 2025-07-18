﻿namespace DSR.SlotDetails.InventoryDetails.Items;

public class BossSoul : CommonItem
{
    private UInt32 _soulAmount;
    
    public BossSoul(byte idSpace, uint id, uint amount, uint sorting, uint index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        ImagePath = ImagePath.Insert(ImagePath.LastIndexOf("\\", StringComparison.InvariantCulture) + 1, "BossSouls\\");
    }

    public BossSoul(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting)
    {
        ImagePath = ImagePath.Insert(ImagePath.LastIndexOf("\\", StringComparison.InvariantCulture) + 1, "BossSouls\\");
    }

    public BossSoul(BossSoul bossSoul) : base(bossSoul)
    {
        _soulAmount = bossSoul._soulAmount;
    }

    public uint SoulAmount => _soulAmount;
}