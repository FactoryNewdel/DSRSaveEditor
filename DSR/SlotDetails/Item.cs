using System.ComponentModel;
using System.Runtime.CompilerServices;
using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails;

public class Item : INotifyPropertyChanged
{
    #region Variables

    private byte _idSpace;
    private UInt32 _id;
    private Infusion _infusion;
    private int _level;
    private ItemType _type;
    private UInt32 _amount;
    private UInt32 _sorting;
    private int _index;
    private bool _enabled;
    private UInt32 _durability;
    private UInt32 _durabilityLoss;

    #endregion

    // Items from Inventory
    public Item(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss)
    {
        _idSpace = idSpace;
        _id = id;
        
        if (idSpace == 0)
        {
            _id = _id / 1000 * 1000;
            _infusion = (Infusion)((id - _id) / 100);
            _level = (int)(id - _id - (int)_infusion * 100);
        }

        var i = Items.GetItem(idSpace, idSpace == 0 ? id / 1000 * 1000 : id);
        if (i != null) _type = i._type;
        
        //_type = Items.GetItem(idSpace, id).Type;
        _amount = amount;
        _sorting = sorting;
        _index = index;
        _enabled = enabled;
        _durability = durability;
        _durabilityLoss = durabilityLoss;
    }

    // All items
    public Item(ItemType type, byte idSpace, uint id, uint sorting, uint durability)
    {
        _idSpace = idSpace;
        _id = id;
        _type = type;
        _amount = 1;
        _sorting = sorting;
        _index = 0;
        _enabled = true;
        _durability = durability;
        _durabilityLoss = 0;
    }

    public Item(Item item)
    {
        _idSpace = item._idSpace;
        _id = item._id;
        _infusion = item._infusion;
        _level = item._level;
        _type = item._type;
        _amount = item._amount;
        _sorting = item._sorting;
        _index = item._index;
        _enabled = item._enabled;
        _durability = item._durability;
        _durabilityLoss = item._durabilityLoss;
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

    public uint FullID => (uint)(ID + (int)_infusion * 100 + Level);

    public uint ID
    {
        get => _id;
        set
        {
            _id = value;
            NotifyPropertyChanged();

        }
    }

    public Infusion Infusion
    {
        get => _infusion;
        set => _infusion = value;
    }

    public int Level
    {
        get => _level;
        set => _level = value;
    }

    public ItemType Type => _type;

    public uint Amount
    {
        get => _amount;
        set
        {
            _amount = value;
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

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}