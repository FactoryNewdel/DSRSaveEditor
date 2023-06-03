namespace DSR.SlotDetails.InventoryDetails.Items;

public class Armor : Item
{
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
        var substract = ID / 10000;
        _armorPieceType = (ArmorPieceType)((ID - substract) / 1000);

        ImagePath += $"Armor/{Type}.png";
    }

    public ArmorPieceType ArmorPieceType => _armorPieceType;
}