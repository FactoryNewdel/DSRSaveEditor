using System.ComponentModel;
using System.Runtime.CompilerServices;
using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails;

public class Item : INotifyPropertyChanged
{
    #region Variables

    private byte _idSpace;
    private UInt32 _idNum;
    private ItemName _name;
    private UInt32 _amount;
    private UInt32 _sorting;
    private bool _enabled;
    private UInt32 _durability;
    private UInt32 _durabilityLoss;

    #endregion

    public Item(byte idSpace, uint id, uint amount, uint sorting, bool enabled, uint durability, uint durabilityLoss)
    {
        _idSpace = idSpace;
        _idNum = id;
        _name = ItemType.GetItem(_idSpace, _idNum);
        _amount = amount;
        _sorting = sorting;
        _enabled = enabled;
        _durability = durability;
        _durabilityLoss = durabilityLoss;
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

    public uint ID
    {
        get => _idNum;
        set
        {
            _idNum = value;
            NotifyPropertyChanged();

            _name = (ItemName)value;
            NotifyPropertyChanged("Type");
        }
    }

    public ItemName Name
    {
        get => _name;
        set
        {
            _name = value;
            NotifyPropertyChanged();

            _idNum = (uint)value;
            NotifyPropertyChanged("ID");
        }
    }

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