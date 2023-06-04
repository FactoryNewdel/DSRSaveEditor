namespace DSR.SlotDetails.InventoryDetails.Items;

public class Armor : Item
{
    private UInt32 _baseID;
    private ArmorPieceType _armorPieceType;
    
    public Armor(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        GetArmorDetails();
    }

    public Armor(ItemType type, byte idSpace, uint id, uint sorting, uint durability) : base(type, idSpace, id, sorting, durability)
    {
        GetArmorDetails();
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

    public ArmorPieceType ArmorPieceType => _armorPieceType;
}