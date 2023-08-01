namespace DSR.SlotDetails.InventoryDetails.Items;

public class Armor : Item
{
    private UInt32 _baseID;
    private ArmorPieceType _armorPieceType;
    private ArmorUpgradeType _armorUpgradeType;
    private uint _level;
    
    public Armor(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        try
        {
            _armorUpgradeType = (ItemList.GetItem(Type) as Armor).ArmorUpgradeType;
        }
        catch (Exception e)
        {
            Console.WriteLine($"UNKNOWN ARMOR: {id}\t{sorting}\t{durability}");
        }
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
        _level = armor._level;
    }

    private void GetArmorDetails()
    {
        _baseID = ID / 10000 * 10000;
        var armorPieceTypeNum = (ID - _baseID) / 1000;
        if (!Enum.IsDefined(typeof(ArmorPieceType), (int)armorPieceTypeNum)) throw new InvalidDataException($"Invalid ArmorPieceType: {armorPieceTypeNum}");
        _armorPieceType = (ArmorPieceType)armorPieceTypeNum;
        _level = ID - _baseID - armorPieceTypeNum * 1000;

        ImagePath += $"Armor/{_armorPieceType}/{Type}.png";
    }

    public uint BaseID => _baseID;

    public ArmorUpgradeType ArmorUpgradeType => _armorUpgradeType;

    public ArmorPieceType ArmorPieceType => _armorPieceType;

    public uint Level
    {
        get => _level;
        set
        {
            _level = value;
            NotifyPropertyChanged();
        }
    }

    public override uint MaxAmount => 1;
}