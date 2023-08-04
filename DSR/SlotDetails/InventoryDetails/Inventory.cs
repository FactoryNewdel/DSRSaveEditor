using System.ComponentModel;
using System.Runtime.CompilerServices;
using DSR.SlotDetails.InventoryDetails.Items;
using DSR.Utils;

namespace DSR.SlotDetails.InventoryDetails;

public class Inventory : INotifyPropertyChanged
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

    private static int slot = 0;

    public Inventory(byte[] bytes)
    {
        var inventoryData = bytes.Skip(InventoryOffset).Take(InventorySize * ItemSize).ToArray();
        _items = new Item[InventorySize];

        _inventorySize = BitConverter.ToUInt32(bytes, 848);
        _latestItemIndex = BitConverter.ToUInt32(bytes, 58204);
        
        DetailComparer.Add(InventoryOffset, InventorySize * ItemSize);
        DetailComparer.Add(848, 4);
        DetailComparer.Add(58204, 4);
        
        //Console.WriteLine($"INVENTORY No {slot}");
        for (var i = 0; i < inventoryData.Length; i += ItemSize)
        {
            var idSpace = inventoryData[i + 3];
            var id = BitConverter.ToUInt32(inventoryData, i + 4);
            var amount = BitConverter.ToUInt32(inventoryData, i + 8);
            var index = (inventoryData[i + 13] & 0b00000111) * 256 + inventoryData[i + 12];
            var sorting = (BitConverter.ToUInt32(inventoryData, i + 12) - (uint)index) / 256;
            var enabled = inventoryData[i + 16] == 1;
            var durability = BitConverter.ToUInt32(inventoryData, i + 20);
            var durabilityLoss = BitConverter.ToUInt32(inventoryData, i + 24);

            _items[i / 28] = Item.GetItem(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);

            var item = _items[i / 28];
            if (slot == 0 && item.ID != 0 && item.ID != 0xFFFFFFFF) Console.WriteLine((i + 2652) + " | " + (i / 28) + " ID = " + item.IdSpace + "    0x" + BitConverter.ToString(BitConverter.GetBytes(item.ID).Reverse().ToArray()).Replace("-", "").TrimStart('0') + "    " + item.ID + "    " + item.Sorting + "    0x" + BitConverter.ToString(BitConverter.GetBytes(item.Sorting).Reverse().ToArray()).Replace("-", "").TrimStart('0') + "    " + BitConverter.ToString(BitConverter.GetBytes(item.Sorting + item.Index)) + "    " + item.Index + "    " + item.Type + "    " + item.Durability);
        }

        slot++;
    }

    public bool AddItem(Item item, bool forceNew = false)
    {
        if (item.IdSpace != 64 || forceNew)
        {
            if (_inventorySize == InventorySize) return false;
            
            LatestItemIndex++;
            item.Index = (int)LatestItemIndex;
            Items[LatestItemIndex] = item;
            _inventorySize++;
            return true;
        }

        for (var i = 0; i < InventorySize; i++)
        {
            if (_items[i].ID != item.ID) continue;

            if (_items[i].Amount == _items[i].MaxAmount) return false;
            
            _items[i].Amount += item.Amount;
            return true;
        }

        return AddItem(item, true);
    }

    public bool RemoveItem(Item item)
    {
        if (item.Index == LatestItemIndex) LatestItemIndex--;

        _inventorySize--;
        item.Delete();
        _items[item.Index] = new Item(item);
        
        return true;
    }

    public bool TryGetItem(ItemType type, out Item? item)
    {
        item = null;
        foreach (var invItem in _items)
        {
            if (type != invItem.Type) continue;

            item = invItem;
            return true;
        }

        return false;
    }

    public List<Item> GetItemOfType(Type type, bool explicitType = false)
    {
        var list = new List<Item>();

        if (!explicitType)
        {
            foreach (var item in _items)
            {
                if (type.IsInstanceOfType(item)) list.Add(item);
            }
        }
        else
        {
            foreach (var item in _items)
            {
                if (item.GetType() == type) list.Add(item);
            }   
        }

        return list.OrderBy(i => i.Sorting).ToList();
    }

    public void UpdateData(ref byte[] data)
    {
        for (var i = 0; i < _items.Length; i++)
        {
            var item = _items[i];
            if (item.IdSpace != 255)
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
            FillUInt32IntoData(ref data, item.FullID, i, 4);
            FillUInt32IntoData(ref data, item.Amount, i, 8);
            var sorting = item.Sorting * 256 + item.Index;
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

    public static Item NoItem
    {
        get
        {
            if (_noRingItem != null) return _noRingItem;
            _noRingItem = Item.GetItem(255, UInt32.MaxValue, 0, UInt32.MaxValue, 2047, false, UInt32.MaxValue, 0);
            return _noRingItem;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}