using System.ComponentModel;
using System.Runtime.CompilerServices;
using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails.InventoryDetails.Items;

public class Item : INotifyPropertyChanged
{
    #region Variables

    private byte _idSpace;
    private UInt32 _id;
    private ItemType _type;
    private UInt32 _amount;
    private UInt32 _sorting;
    private int _index;
    private bool _enabled;
    private UInt32 _durability;
    private UInt32 _durabilityLoss;

    private string _imagePath; 

    #endregion

    // Items from Inventory
    protected Item(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss)
    {
        _idSpace = idSpace;
        _id = id;

        var i = ItemList.GetItem(idSpace, idSpace == 0 ? id / 1000 * 1000 : id);
        if (i != null) _type = i._type;
        else _type = ItemType.UNKNOWN;

        Name = GetName();
        MaxAmount = 99;
        _amount = amount;
        _sorting = sorting;
        _index = index;
        _enabled = enabled;
        _durability = durability;
        _durabilityLoss = durabilityLoss;

        ImagePath = "Images/ItemIcons/";
    }

    // All items
    protected Item(ItemType type, byte idSpace, uint id, uint sorting, uint durability)
    {
        _idSpace = idSpace;
        _id = id;
        _type = type;
        Name = GetName();
        MaxAmount = 99;
        _amount = 1;
        _sorting = sorting;
        _index = 0;
        _enabled = true;
        _durability = durability;
        _durabilityLoss = 0;

        ImagePath = $"Images/ItemIcons/";
    }

    public Item(Item item)
    {
        _idSpace = item._idSpace;
        _id = item._id;
        _type = item._type;
        Name = item.Name;
        MaxAmount = item.MaxAmount;
        _amount = item._amount;
        _sorting = item._sorting;
        _index = item._index;
        _enabled = item._enabled;
        _durability = item._durability;
        _durabilityLoss = item._durabilityLoss;
        ImagePath = item.ImagePath;
    }

    public static Item GetItem(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss)
    {
        if (idSpace == 0) return new Weapon(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (idSpace == 16) return new Armor(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (idSpace == 32) return new Ring(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (idSpace == 64) return GetIngameItem(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (idSpace == 255) return new Item(255, UInt32.MaxValue, 0, UInt32.MaxValue, 2047, false, UInt32.MaxValue, 0);
        throw new InvalidDataException($"Invalid IDSpace: {idSpace}");
    }

    private static Item GetIngameItem(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss)
    {
        if (id / 1000 == 0 && id / 100 == 4) return new CommonSoul(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (id / 10000 == 0 && id / 1000 == 1) return new UpgradeMaterial(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (id / 10000 == 0 && id / 1000 == 2) return new KeyItem(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (id / 10000 == 0 && id / 1000 == 3) return new Spell(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
        if (id >= 200 && id <= 215) return new EstusFlask(id, amount, index);
        return new CommonItem(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss);
    }

    private string GetName()
    {
        if (_type == ItemType.UNKNOWN) return "";
        var compare = _type.ToString();
        var output = _type.ToString();
        var added = 0;

        for (var i = 0; i < compare.Length; i++)
        {
            var ascii = (int)compare[i];
            if (ascii >= 65 && ascii <= 90) output = output.Insert(i + added++, " ");
        }
        
        return output;
    }

    public byte IdSpace
    {
        get => _idSpace;
        set
        {
            _idSpace = value;
            NotifyPropertyChanged();
        }
    }

    public virtual uint FullID => _id;

    public uint ID
    {
        get => _id;
        set
        {
            _id = value;
            NotifyPropertyChanged();

        }
    }

    public ItemType Type => _type;

    public string Name { get; private set; }
    
    public virtual uint MaxAmount { get; private set; }

    public uint Amount
    {
        get => _amount;
        set
        {
            _amount = value < MaxAmount ? value : MaxAmount;
            NotifyPropertyChanged();
        }
    }

    public uint Sorting
    {
        get => _sorting;
        set
        {
            _sorting = value;
            NotifyPropertyChanged();
        }
    }
    
    public int Index
    {
        get => _index;
        set
        {
            _index = value;
            NotifyPropertyChanged();
        }
    }
    
    

    public bool Enabled
    {
        get => _enabled;
        set
        {
            _enabled = value;
            NotifyPropertyChanged();
        }
    }

    public uint Durability
    {
        get => _durability;
        set
        {
            _durability = value;
            NotifyPropertyChanged();
        }
    }

    public uint DurabilityLoss
    {
        get => _durabilityLoss;
        set
        {
            _durabilityLoss = value;
            NotifyPropertyChanged();
        }
    }

    public string ImagePath
    {
        get => _imagePath;
        protected set
        {
            _imagePath = Path.GetFullPath(value);
        } 
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}