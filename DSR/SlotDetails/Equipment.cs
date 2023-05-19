using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DSR.SlotDetails;

public class Equipment : INotifyPropertyChanged
{
    #region Variables
    
    // TODO ammunition, rings, attunement

    private UInt32 _pointerLeft0;
    private UInt32 _pointerRight0;
    private UInt32 _pointerLeft1;
    private UInt32 _pointerRight1;
    
    private UInt32 _pointerHelmet;
    private UInt32 _pointerChestplate;
    private UInt32 _pointerLeggings;
    private UInt32 _pointerBoots;
    
    // Consumables got 2 pointers for whatever reason
    private UInt32 _pointerConsumable00;
    private UInt32 _pointerConsumable01;
    private UInt32 _pointerConsumable10;
    private UInt32 _pointerConsumable11;
    private UInt32 _pointerConsumable20;
    private UInt32 _pointerConsumable21;
    private UInt32 _pointerConsumable30;
    private UInt32 _pointerConsumable31;
    private UInt32 _pointerConsumable40;
    private UInt32 _pointerConsumable41;



    private Item _itemLeft0;
    private Item _itemRight0;
    private Item _itemLeft1;
    private Item _itemRight1;
    
    private Item _itemHelmet;
    private Item _itemChestplate;
    private Item _itemLeggings;
    private Item _itemBoots;
    
    private Item _itemConsumable0;
    private Item _itemConsumable1;
    private Item _itemConsumable2;
    private Item _itemConsumable3;
    private Item _itemConsumable4;



    private string _iconPathAttunement;
    private string _iconPathLeftHand;
    private string _iconPathRightHand;
    private string _iconPathConsumable;

    #endregion

    public Equipment(byte[] bytes, Item[] invItems)
    {
        // Get IDs for comparison
        var leftID0 = BitConverter.ToUInt32(bytes, 768);
        var rightID0 = BitConverter.ToUInt32(bytes, 772);
        var leftID1 = BitConverter.ToUInt32(bytes, 776);
        var rightID1 = BitConverter.ToUInt32(bytes, 780);

        var arrowID0 = BitConverter.ToUInt32(bytes, 784);
        var boltID0 = BitConverter.ToUInt32(bytes, 788);
        var arrowID1 = BitConverter.ToUInt32(bytes, 792);
        var boltID1 = BitConverter.ToUInt32(bytes, 796);
        
        var helmetID = BitConverter.ToUInt32(bytes, 800);
        var chestplateID = BitConverter.ToUInt32(bytes, 804);
        var leggingsID = BitConverter.ToUInt32(bytes, 808);
        var bootsID = BitConverter.ToUInt32(bytes, 812);

        var ringID0 = BitConverter.ToUInt32(bytes, 820);
        var ringID1 = BitConverter.ToUInt32(bytes, 824);
        
        var consumableID0 = BitConverter.ToUInt32(bytes, 828);
        var consumableID1 = BitConverter.ToUInt32(bytes, 832);
        var consumableID2 = BitConverter.ToUInt32(bytes, 836);
        var consumableID3 = BitConverter.ToUInt32(bytes, 840);
        var consumableID4 = BitConverter.ToUInt32(bytes, 844);
        
        

        _pointerLeft0 = BitConverter.ToUInt32(bytes, 660);
        _pointerRight0 = BitConverter.ToUInt32(bytes, 664);
        _pointerLeft1 = BitConverter.ToUInt32(bytes, 668);
        _pointerRight1 = BitConverter.ToUInt32(bytes, 672);
        
        _pointerHelmet = BitConverter.ToUInt32(bytes, 692);
        _pointerChestplate = BitConverter.ToUInt32(bytes, 696);
        _pointerLeggings = BitConverter.ToUInt32(bytes, 700);
        _pointerBoots = BitConverter.ToUInt32(bytes, 704);
        
        _pointerConsumable00 = BitConverter.ToUInt32(bytes, 720);
        _pointerConsumable01 = BitConverter.ToUInt32(bytes, 58308);
        _pointerConsumable10 = BitConverter.ToUInt32(bytes, 724);
        _pointerConsumable11 = BitConverter.ToUInt32(bytes, 58312);
        _pointerConsumable20 = BitConverter.ToUInt32(bytes, 728);
        _pointerConsumable21 = BitConverter.ToUInt32(bytes, 58316);
        _pointerConsumable30 = BitConverter.ToUInt32(bytes, 732);
        _pointerConsumable31 = BitConverter.ToUInt32(bytes, 58320);
        _pointerConsumable40 = BitConverter.ToUInt32(bytes, 736);
        _pointerConsumable41 = BitConverter.ToUInt32(bytes, 58324);



        var invItemLeft0 = invItems[_pointerLeft0];
        ItemLeft0 = invItemLeft0.ID == leftID0 ? invItemLeft0 : Inventory.UnknownItem;
        var invItemRight0 = invItems[_pointerRight0];
        ItemRight0 = invItemRight0.ID == rightID0 ? invItemRight0 : Inventory.UnknownItem;
        var invItemLeft1 = invItems[_pointerLeft1];
        _itemLeft1 = invItemLeft1.ID == leftID1 ? invItemLeft1 : Inventory.UnknownItem;
        var invItemRight1 = invItems[_pointerRight1];
        _itemRight1 = invItemRight1.ID == rightID1 ? invItemRight1 : Inventory.UnknownItem;
        
        var invItemHelmet = invItems[_pointerHelmet];
        _itemHelmet = invItemHelmet.ID == helmetID ? invItemHelmet : Inventory.UnknownItem;
        var invItemChestplate = invItems[_pointerChestplate];
        _itemChestplate = invItemChestplate.ID == chestplateID ? invItemChestplate : Inventory.UnknownItem;
        var invItemLeggings = invItems[_pointerLeggings];
        _itemLeggings = invItemLeggings.ID == leggingsID ? invItemLeggings : Inventory.UnknownItem;
        var invItemBoots = invItems[_pointerBoots];
        _itemBoots = invItemBoots.ID == bootsID ? invItemBoots : Inventory.UnknownItem;

        if (consumableID0 != 0xFFFFFFFF)
        {
            var invItemConsumable0 = invItems[_pointerConsumable00];
            _itemConsumable0 = invItemConsumable0.ID == consumableID0 ? invItemConsumable0 : Inventory.UnknownItem;
        } else _itemConsumable0 = Inventory.NoRing;
        
        if (consumableID1 != 0xFFFFFFFF)
        {
            var invItemConsumable1 = invItems[_pointerConsumable10];
            _itemConsumable1 = invItemConsumable1.ID == consumableID1 ? invItemConsumable1 : Inventory.UnknownItem;
        } else _itemConsumable1 = Inventory.NoRing;
        
        if (consumableID2 != 0xFFFFFFFF)
        {
            var invItemConsumable2 = invItems[_pointerConsumable20];
            _itemConsumable2 = invItemConsumable2.ID == consumableID2 ? invItemConsumable2 : Inventory.UnknownItem;
        } else _itemConsumable2 = Inventory.NoRing;
        
        if (consumableID3 != 0xFFFFFFFF)
        {
            var invItemConsumable3 = invItems[_pointerConsumable30];
            _itemConsumable3 = invItemConsumable3.ID == consumableID3 ? invItemConsumable3 : Inventory.UnknownItem;
        } else _itemConsumable3 = Inventory.NoRing;
        
        if (consumableID4 != 0xFFFFFFFF)
        {
            var invItemConsumable4 = invItems[_pointerConsumable40];
            _itemConsumable4 = invItemConsumable4.ID == consumableID4 ? invItemConsumable4 : Inventory.UnknownItem;
        } else _itemConsumable4 = Inventory.NoRing;
        
    }

    public Item ItemLeft0
    {
        get => _itemLeft0;
        set
        {
            _itemLeft0 = value;
            NotifyPropertyChanged();
            var path = $"Images/ItemIcons/Weapons/{value.Name}.png";
            if (File.Exists(path)) IconPathLeftHand = path;
        }
    }

    public Item ItemRight0
    {
        get => _itemRight0;
        set
        {
            _itemRight0 = value;
            NotifyPropertyChanged();
            var path = Path.GetFullPath($"Images/ItemIcons/Weapons/{value.Name}.png");
            if (File.Exists(path)) IconPathRightHand = path;
        }
    }

    public Item ItemLeft1 => _itemLeft1;

    public Item ItemRight1 => _itemRight1;

    public Item ItemHelmet => _itemHelmet;

    public Item ItemChestplate => _itemChestplate;

    public Item ItemLeggings => _itemLeggings;

    public Item ItemBoots => _itemBoots;

    public Item ItemConsumable0 => _itemConsumable0;

    public Item ItemConsumable1 => _itemConsumable1;

    public Item ItemConsumable2 => _itemConsumable2;

    public Item ItemConsumable3 => _itemConsumable3;

    public Item ItemConsumable4 => _itemConsumable4;

    public string IconPathAttunement
    {
        get => _iconPathAttunement;
        private set
        {
            _iconPathAttunement = value;
            NotifyPropertyChanged();
        }
    }
    
    public string IconPathLeftHand
    {
        get => _iconPathLeftHand;
        private set
        {
            _iconPathLeftHand = value;
            NotifyPropertyChanged();
        }
    }
    
    public string IconPathRightHand
    {
        get => _iconPathRightHand;
        private set
        {
            _iconPathRightHand = value;
            NotifyPropertyChanged();
        }
    }

    public string IconPathConsumable
    {
        get => _iconPathConsumable;
        private set
        {
            _iconPathConsumable = value;
            NotifyPropertyChanged();
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}