namespace DSR.SlotDetails;

public class Inventory
{
    private Item[] _items;
    
    public Inventory(byte[] bytes)
    {
        var inventoryData = bytes.Skip(2652 - 64 * 28).Take(2048 * 28).ToArray();
        _items = new Item[2048];
        
        Console.WriteLine("Inventory");

        for (var i = 0; i < inventoryData.Length; i += 28)
        {
            var type = inventoryData[i + 3];
            var id =             BitConverter.ToUInt32(inventoryData, i + 4);
            var amount =         BitConverter.ToUInt32(inventoryData, i + 8);
            var sorting =        BitConverter.ToUInt32(inventoryData, i + 12);
            var enabled = inventoryData[i + 16] == 1;
            var durability =     BitConverter.ToUInt32(inventoryData, i + 20);
            var durabilityLoss = BitConverter.ToUInt32(inventoryData, i + 24);

            _items[i / 28] = new Item(type, id, amount, sorting, enabled, durability, durabilityLoss);

            var item = _items[i / 28];
            
            if (item.ID != 0 && item.ID != 0xFFFFFFFF) Console.WriteLine((i + 2652) + " | " + (i / 28) + " ID = " + item.IdSpace + "    " + BitConverter.ToString(BitConverter.GetBytes(item.ID)) + "    " + item.ID + "    " + item.Type);
        }
    }
}