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

    private UInt32 _pointerHelm;
    private UInt32 _pointerChest;
    private UInt32 _pointerGauntlets;
    private UInt32 _pointerLeggings;

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

    private Item _itemHelm;
    private Item _itemChest;
    private Item _itemGauntlets;
    private Item _itemLeggings;

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
        var leftID0 = BitConverter.ToUInt32(bytes, 768);
        var rightID0 = BitConverter.ToUInt32(bytes, 772);
        var leftID1 = BitConverter.ToUInt32(bytes, 776);
        var rightID1 = BitConverter.ToUInt32(bytes, 780);

        var arrowID0 = BitConverter.ToUInt32(bytes, 784);
        var boltID0 = BitConverter.ToUInt32(bytes, 788);
        var arrowID1 = BitConverter.ToUInt32(bytes, 792);
        var boltID1 = BitConverter.ToUInt32(bytes, 796);

        var helmID = BitConverter.ToUInt32(bytes, 800);
        var chestID = BitConverter.ToUInt32(bytes, 804);
        var gauntletsID = BitConverter.ToUInt32(bytes, 808);
        var leggingsID = BitConverter.ToUInt32(bytes, 812);

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

        _pointerHelm = BitConverter.ToUInt32(bytes, 692);
        _pointerChest = BitConverter.ToUInt32(bytes, 696);
        _pointerGauntlets = BitConverter.ToUInt32(bytes, 700);
        _pointerLeggings = BitConverter.ToUInt32(bytes, 704);

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
        ItemLeft0 = invItemLeft0.FullID == leftID0 ? invItemLeft0 : Inventory.UnknownItem;
        var invItemRight0 = invItems[_pointerRight0];
        ItemRight0 = invItemRight0.FullID == rightID0 ? invItemRight0 : Inventory.UnknownItem;
        var invItemLeft1 = invItems[_pointerLeft1];
        _itemLeft1 = invItemLeft1.FullID == leftID1 ? invItemLeft1 : Inventory.UnknownItem;
        var invItemRight1 = invItems[_pointerRight1];
        _itemRight1 = invItemRight1.FullID == rightID1 ? invItemRight1 : Inventory.UnknownItem;

        var invItemHelmet = invItems[_pointerHelm];
        _itemHelm = invItemHelmet.FullID == helmID ? invItemHelmet : Inventory.UnknownItem;
        var invItemChestplate = invItems[_pointerChest];
        _itemChest = invItemChestplate.FullID == chestID ? invItemChestplate : Inventory.UnknownItem;
        var invItemLeggings = invItems[_pointerGauntlets];
        _itemGauntlets = invItemLeggings.FullID == gauntletsID ? invItemLeggings : Inventory.UnknownItem;
        var invItemBoots = invItems[_pointerLeggings];
        _itemLeggings = invItemBoots.FullID == leggingsID ? invItemBoots : Inventory.UnknownItem;

        if (consumableID0 != 0xFFFFFFFF)
        {
            var invItemConsumable0 = invItems[_pointerConsumable00];
            _itemConsumable0 = invItemConsumable0.FullID == consumableID0 ? invItemConsumable0 : Inventory.UnknownItem;
        }
        else _itemConsumable0 = Inventory.NoRing;

        if (consumableID1 != 0xFFFFFFFF)
        {
            var invItemConsumable1 = invItems[_pointerConsumable10];
            _itemConsumable1 = invItemConsumable1.FullID == consumableID1 ? invItemConsumable1 : Inventory.UnknownItem;
        }
        else _itemConsumable1 = Inventory.NoRing;

        if (consumableID2 != 0xFFFFFFFF)
        {
            var invItemConsumable2 = invItems[_pointerConsumable20];
            _itemConsumable2 = invItemConsumable2.FullID == consumableID2 ? invItemConsumable2 : Inventory.UnknownItem;
        }
        else _itemConsumable2 = Inventory.NoRing;

        if (consumableID3 != 0xFFFFFFFF)
        {
            var invItemConsumable3 = invItems[_pointerConsumable30];
            _itemConsumable3 = invItemConsumable3.FullID == consumableID3 ? invItemConsumable3 : Inventory.UnknownItem;
        }
        else _itemConsumable3 = Inventory.NoRing;

        if (consumableID4 != 0xFFFFFFFF)
        {
            var invItemConsumable4 = invItems[_pointerConsumable40];
            _itemConsumable4 = invItemConsumable4.FullID == consumableID4 ? invItemConsumable4 : Inventory.UnknownItem;
        }
        else _itemConsumable4 = Inventory.NoRing;
    }

    public void UpdateData(ref byte[] data)
    {
        FillUInt32IntoData(ref data, _pointerLeft0, 660);
        FillUInt32IntoData(ref data, _pointerRight0, 664);
        FillUInt32IntoData(ref data, _pointerLeft1, 668);
        FillUInt32IntoData(ref data, _pointerRight1, 672);
        //TODO
        FillUInt32IntoData(ref data, _pointerHelm, 692);
        FillUInt32IntoData(ref data, _pointerChest, 696);
        FillUInt32IntoData(ref data, _pointerGauntlets, 700);
        FillUInt32IntoData(ref data, _pointerLeggings, 704);
        
        FillUInt32IntoData(ref data, _itemLeft0.FullID, 768);
        FillUInt32IntoData(ref data, _itemRight0.FullID, 772);
        FillUInt32IntoData(ref data, _itemLeft1.FullID, 776);
        FillUInt32IntoData(ref data, _itemRight1.FullID, 780);
        // TODO
        FillUInt32IntoData(ref data, _itemHelm.FullID, 800);
        FillUInt32IntoData(ref data, _itemChest.FullID, 804);
        FillUInt32IntoData(ref data, _itemGauntlets.FullID, 808);
        FillUInt32IntoData(ref data, _itemLeggings.FullID, 812);
    }

    private void FillUInt32IntoData(ref byte[] data, UInt32 fill, int offset)
    {
        var fillBytes = BitConverter.GetBytes(fill);
        for (int i = 0; i < 4; i++)
        {
            data[i + offset] = fillBytes[i];
        }
    }

    public Item ItemLeft0
    {
        get => _itemLeft0;
        set
        {
            _itemLeft0 = value;
            NotifyPropertyChanged();

            string path;
            /*if (value.IdSpace != 0) path = $"Images/ItemIcons/Weapons/{value.Name}.png";
            else path = WeaponImages.GetImage(WeaponMeta.Get(value.Name).SpecificWeaponType);
            if (File.Exists(path)) IconPathLeftHand = path;*/
        }
    }

    public Item ItemRight0
    {
        get => _itemRight0;
        set
        {
            _itemRight0 = value;
            NotifyPropertyChanged();

            string path;
            /*if (value.IdSpace != 0) path = $"Images/ItemIcons/Weapons/{value.Name}.png";
            else path = WeaponImages.GetImage(WeaponMeta.Get(value.Name).SpecificWeaponType);
            if (File.Exists(path)) IconPathRightHand = path;*/
        }
    }

    public Item ItemLeft1 => _itemLeft1;

    public Item ItemRight1 => _itemRight1;

    public Item ItemHelm => _itemHelm;

    public Item ItemChest => _itemChest;

    public Item ItemGauntlets => _itemGauntlets;

    public Item ItemLeggings => _itemLeggings;

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