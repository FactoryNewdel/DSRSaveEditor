namespace DSR.SlotDetails.InventoryDetails.Items;

public class UpgradeMaterial : Item
{
    public UpgradeMaterial(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        
    }

    public UpgradeMaterial(ItemType type, byte idSpace, uint id, uint sorting, uint durability) : base(type, idSpace, id, sorting, durability)
    {
        
    }
}