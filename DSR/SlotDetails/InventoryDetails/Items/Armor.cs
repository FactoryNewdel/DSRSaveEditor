namespace DSR.SlotDetails.InventoryDetails.Items;

public class Armor : Item
{
    private UInt32 _baseID;
    private ArmorPieceType _armorPieceType;
    private ArmorUpgradeType _armorUpgradeType;
    
    public Armor(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        _armorUpgradeType = (ItemList.GetItem(Type) as Armor).ArmorUpgradeType;
        GetArmorDetails();
    }

    public Armor(ItemType type, byte idSpace, uint id, uint sorting, uint durability, ArmorUpgradeType armorUpgradeType) : base(type, idSpace, id, sorting, durability)
    {
        _armorUpgradeType = armorUpgradeType;
        GetArmorDetails();
    }

    public Armor(Armor armor) : base(armor)
    {
        _baseID = armor._baseID;
        _armorUpgradeType = armor._armorUpgradeType;
        _armorPieceType = armor._armorPieceType;

    }

    private void GetArmorDetails()
    {
        _baseID = ID / 10000 * 10000;
        var armorPieceTypeNum = (ID - _baseID) / 1000;
        if (!Enum.IsDefined(typeof(ArmorPieceType), (int)armorPieceTypeNum)) throw new InvalidDataException($"Invalid ArmorPieceType: {armorPieceTypeNum}");
        _armorPieceType = (ArmorPieceType)armorPieceTypeNum;

        ImagePath += $"Armor/{Type}.png";
    }

    public uint BaseID => _baseID;

    public ArmorUpgradeType ArmorUpgradeType => _armorUpgradeType;

    public ArmorPieceType ArmorPieceType => _armorPieceType;
}