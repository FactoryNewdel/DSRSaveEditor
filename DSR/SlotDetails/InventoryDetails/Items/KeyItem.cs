namespace DSR.SlotDetails.InventoryDetails.Items;

public class KeyItem : Item
{
    private KeyItemType _keyItemType;
    
    public KeyItem(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        ImagePath += $"Items/KeyItems/{Type}.png";
        GetKeyItemType();
    }

    public KeyItem(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting, 0)
    {
        ImagePath += $"Items/KeyItems/{Type}.png";
        GetKeyItemType();
    }

    public KeyItem(KeyItem keyItem) : base(keyItem)
    {
        _keyItemType = keyItem._keyItemType;
    }

    private void GetKeyItemType()
    {
        var type = ID / 100;
        if (type == 3)                    _keyItemType = KeyItemType.Special;
        else if (type == 8)               _keyItemType = KeyItemType.Ember;
        else if (type >= 20 && type < 25) _keyItemType = KeyItemType.Key;
        else if (type == 25)              _keyItemType = KeyItemType.LordItem;
        else if (type == 26)              _keyItemType = KeyItemType.BonfireUpgrade;
        else throw new Exception($"Invalid KeyItemType: {type}");
    }

    public override uint MaxAmount => 1;

    public KeyItemType KeyItemType => _keyItemType;
}