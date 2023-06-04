namespace DSR.SlotDetails.InventoryDetails.Items;

public class CommonItem : Item
{
    public CommonItem(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        ImagePath += $"Items/{Type}.png";
        //Console.WriteLine($"Common Item = {Type}");
    }

    public CommonItem(ItemType type, byte idSpace, uint id, uint sorting, uint durability) : base(type, idSpace, id, sorting, durability)
    {
    }
}