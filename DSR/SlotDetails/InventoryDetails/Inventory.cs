using DSR.SlotDetails.InventoryDetails.Items;

namespace DSR.SlotDetails.InventoryDetails;

public class Inventory
{
    private const int InventoryOffset = 860;
    private const int InventorySize = 2048;
    private const int ItemSize = 28;

    private int _size;
    private Item[] _items;
    private UInt32 _inventorySize;
    private UInt32 _latestItemIndex;
    private static Item _unknownItem;
    private static Item _noRingItem;

    public Inventory(byte[] bytes)
    {
        var inventoryData = bytes.Skip(InventoryOffset).Take(InventorySize * ItemSize).ToArray();
        _items = new Item[InventorySize];
        
        _inventorySize = BitConverter.ToUInt32(bytes, 848);
        _latestItemIndex = BitConverter.ToUInt32(bytes, 58204);

        for (var i = 0; i < inventoryData.Length; i += ItemSize)
        {
            var idSpace = inventoryData[i + 3];
            var id =             BitConverter.ToUInt32(inventoryData, i + 4);
            var amount =         BitConverter.ToUInt32(inventoryData, i + 8);
            var sorting =        BitConverter.ToUInt32(new byte[]{ 0, (byte)(inventoryData[i + 13] & 0b11111000), inventoryData[i + 14], inventoryData[i + 15] });
            //var sorting =        BitConverter.ToUInt32(inventoryData, i + 12);
            var index = (inventoryData[i + 13] & 0b111) * 256 + inventoryData[i + 12];
            if (index != 2047)
            {
                _size = index + 1;
                if (index != i / 28) throw new Exception($"i = {i / 28}\tindex = {index} | {id}");
            }
            
            var enabled = inventoryData[i + 16] == 1;
            var durability =     BitConverter.ToUInt32(inventoryData, i + 20);
            var durabilityLoss = BitConverter.ToUInt32(inventoryData, i + 24);

            if (i / ItemSize > 119 && id == 0)
            {
                ;
            }
            
            _items[i / 28] = Item.GetItem(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);

            var item = _items[i / 28];
            if (item.ID != 0 && item.ID != 0xFFFFFFFF) Console.WriteLine((i + 2652) + " | " + (i / 28) + " ID = " + item.IdSpace + "    0x" + BitConverter.ToString(BitConverter.GetBytes(item.ID).Reverse().ToArray()).Replace("-", "").TrimStart('0') + "    " + item.ID + "    " + item.Sorting + "    0x" + BitConverter.ToString(BitConverter.GetBytes(item.Sorting).Reverse().ToArray()).Replace("-", "").TrimStart('0') + "    " + BitConverter.ToString(BitConverter.GetBytes(item.Sorting + item.Index)) + "    " + item.Index + "    " + item.Type + "    " + item.Durability);

        }
    }

    public void AddItem(Item item, bool forceNew = false)
    {
        if (item.IdSpace != 64 || forceNew)
        {
            LatestItemIndex++;
            item.Index = (int)LatestItemIndex;
            Items[LatestItemIndex] = item;
            _inventorySize++;
            return;
        }

        for (var i = 0; i < InventorySize; i++)
        {
            if (_items[i].ID != item.ID) continue;

            var add = _items[i];
            _items[i].Amount = add.Amount + item.Amount <= 999 ? add.Amount + item.Amount : 999;
            return;
        }
        
        AddItem(item, true);
    }

    public List<Item> GetItemOfType(Type type)
    {
        var list = new List<Item>();

        foreach (var item in _items)
        {
            if (item.GetType() == type) list.Add(item);
        }

        return list;
    }

    public void UpdateData(ref byte[] data)
    {
        for (var i = 0; i < _items.Length; i++)
        {
            var item = _items[i];
            if (item.Index != 2047)
            {
                data[InventoryOffset + i * ItemSize + 0] = 0;
                data[InventoryOffset + i * ItemSize + 1] = 0;
                data[InventoryOffset + i * ItemSize + 2] = 0;
            }
            else
            {
                data[InventoryOffset + i * ItemSize + 0] = 255;
                data[InventoryOffset + i * ItemSize + 1] = 255;
                data[InventoryOffset + i * ItemSize + 2] = 255;
            }
            data[InventoryOffset + i * ItemSize + 3] = item.IdSpace;
            FillUInt32IntoData(ref data, item is Weapon weapon ? weapon.FullID : item.ID, i, 4);
            FillUInt32IntoData(ref data, item.Amount, i, 8);
            var sorting = item.Sorting + item.Index;
            FillUInt32IntoData(ref data, (uint)sorting, i, 12);
            data[InventoryOffset + i * ItemSize + 16] = (byte)(item.Enabled ? 1 : 0);
            data[InventoryOffset + i * ItemSize + 17] = 0;
            data[InventoryOffset + i * ItemSize + 18] = 0;
            data[InventoryOffset + i * ItemSize + 19] = 0;
            FillUInt32IntoData(ref data, item.Durability, i, 20);
            FillUInt32IntoData(ref data, item.DurabilityLoss, i, 24);
        }

        FillUInt32IntoData(ref data, _inventorySize, 848);
        FillUInt32IntoData(ref data, _latestItemIndex, 58204);
    }
    
    private void FillUInt32IntoData(ref byte[] data, UInt32 fill, int index, int offset)
    {
        var fillBytes = BitConverter.GetBytes(fill);
        for (int i = 0; i < 4; i++)
        {
            data[i + offset + InventoryOffset + index * ItemSize] = fillBytes[i];
        }
    }
    
    private void FillUInt32IntoData(ref byte[] data, UInt32 fill, int offset)
    {
        var fillBytes = BitConverter.GetBytes(fill);
        for (int i = 0; i < 4; i++)
        {
            data[i + offset] = fillBytes[i];
        }
    }

    public int Size => _size;

    public Item[] Items => _items;

    public uint LatestItemIndex
    {
        get => _latestItemIndex;
        set => _latestItemIndex = value;
    }

    public static Item UnknownItem
    {
        get
        {
            if (_unknownItem != null) return _unknownItem;
            _unknownItem = Item.GetItem(255, UInt32.MaxValue, 0, UInt32.MaxValue, 2047, false, UInt32.MaxValue, 0);
            return _unknownItem;
        }
    }
    
    public static Item NoRing
    {
        get
        {
            if (_noRingItem != null) return _noRingItem;
            _noRingItem = Item.GetItem(255, UInt32.MaxValue, 0, UInt32.MaxValue, 2047, false, UInt32.MaxValue, 0);
            return _noRingItem;
        }
    }
}