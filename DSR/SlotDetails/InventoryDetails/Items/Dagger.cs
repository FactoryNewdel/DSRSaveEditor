namespace DSR.SlotDetails.InventoryDetails.Items;

public class Dagger : Weapon
{
    public Dagger(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
    }

    public Dagger(ItemType type, byte idSpace, uint id, uint sorting, uint durability) : base(type, idSpace, id, sorting, durability)
    {
    }
}