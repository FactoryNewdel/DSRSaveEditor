namespace DSR.SlotDetails;

public class Inventory
{
    private Item[] _items;
    private static Item _unknownItem;
    private static Item _noRingItem;
    
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
        }
    }

    public Item[] Items => _items;

    public static Item UnknownItem
    {
        get
        {
            if (_unknownItem != null) return _unknownItem;
            _unknownItem = new Item(0, 0, 0, 0, false, 0, 0);
            return _unknownItem;
        }
    }
    
    public static Item NoRing
    {
        get
        {
            if (_noRingItem != null) return _noRingItem;
            _noRingItem = new Item(0, 0, 0, 0, false, 0, 0);
            return _noRingItem;
        }
    }
}