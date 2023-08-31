using System.ComponentModel;
using System.Runtime.CompilerServices;
using DSR.Exceptions;
using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using DSR.SlotDetailsDefinition;
using DSR.Utils;

namespace DSR.SlotDetails.EquipmentDetails;

public class Equipment : INotifyPropertyChanged
{
    #region Variables

    private SaveSlotDetails _parent;

    private byte[] _bytes;

    private bool _twoHanded;
    private Item _selectedLeft;
    private Item _selectedRight;
    private Item _selectedSpell;
    private Item _selectedConsumable;

    private UInt32 _pointerLeft0;
    private UInt32 _pointerRight0;
    private UInt32 _pointerLeft1;
    private UInt32 _pointerRight1;
    
    private UInt32 _pointerArrow0;
    private UInt32 _pointerBolt0;
    private UInt32 _pointerArrow1;
    private UInt32 _pointerBolt1;

    private UInt32 _pointerHelm;
    private UInt32 _pointerChest;
    private UInt32 _pointerGauntlets;
    private UInt32 _pointerLeggings;
    
    private UInt32 _pointerRing0;
    private UInt32 _pointerRing1;

    // Consumables got 2 pointers for whatever reason
    private UInt32 _pointerConsumable00;
    private UInt32 _pointerConsumable10;
    private UInt32 _pointerConsumable20;
    private UInt32 _pointerConsumable30;
    private UInt32 _pointerConsumable40;
    
    private UInt32 _pointerConsumable01;
    private UInt32 _pointerConsumable11;
    private UInt32 _pointerConsumable21;
    private UInt32 _pointerConsumable31;
    private UInt32 _pointerConsumable41;
    
    private Item _itemLeft0;
    private Item _itemRight0;
    private Item _itemLeft1;
    private Item _itemRight1;
    
    private Item _itemArrow0;
    private Item _itemBolt0;
    private Item _itemArrow1;
    private Item _itemBolt1;

    private Item _itemHelm;
    private Item _itemChest;
    private Item _itemGauntlets;
    private Item _itemLeggings;
    
    private Item _itemRing0;
    private Item _itemRing1;

    private Item _itemConsumable0;
    private Item _itemConsumable1;
    private Item _itemConsumable2;
    private Item _itemConsumable3;
    private Item _itemConsumable4;
    
    private Item _itemSpell0;
    private Item _itemSpell1;
    private Item _itemSpell2;
    private Item _itemSpell3;
    private Item _itemSpell4;
    private Item _itemSpell5;
    private Item _itemSpell6;
    private Item _itemSpell7;
    private Item _itemSpell8;
    private Item _itemSpell9;

    private UInt32 _usagesSpell0;
    private UInt32 _usagesSpell1;
    private UInt32 _usagesSpell2;
    private UInt32 _usagesSpell3;
    private UInt32 _usagesSpell4;
    private UInt32 _usagesSpell5;
    private UInt32 _usagesSpell6;
    private UInt32 _usagesSpell7;
    private UInt32 _usagesSpell8;
    private UInt32 _usagesSpell9;

    private UInt32 _selectedSpellIndex;

    #endregion

    public Equipment(SaveSlotDetails parent, byte[] bytes)
    {
        _bytes = bytes;
        _parent = parent;

        var invItems = _parent.Inventory.Items;
        
        _pointerLeft0 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerLeft0);
        _pointerRight0 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerRight0);
        _pointerLeft1 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerLeft1);
        _pointerRight1 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerRight1);

        _pointerArrow0 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerArrow0);
        _pointerBolt0  =  BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerBolt0);
        _pointerArrow1 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerArrow1);
        _pointerBolt1  =  BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerBolt1);
        
        _pointerHelm =      BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerHelm);
        _pointerChest =     BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerChest);
        _pointerGauntlets = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerGauntlets);
        _pointerLeggings =  BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerLeggings);
        
        _pointerRing0 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerRing0);
        _pointerRing1 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerRing1);

        _pointerConsumable00 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables00);
        _pointerConsumable10 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables10);
        _pointerConsumable20 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables20);
        _pointerConsumable30 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables30);
        _pointerConsumable40 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables40);
        
        _pointerConsumable01 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables01);
        _pointerConsumable11 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables11);
        _pointerConsumable21 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables21);
        _pointerConsumable31 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables31);
        _pointerConsumable41 = BitConverter.ToUInt32(bytes, EquipmentDefinition.PointerConsumables41);



        var idLeft0 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDLeft0);
        var idRight0 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDRight0);
        var idLeft1 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDLeft1);
        var idRight1 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDRight1);

        var idArrow0 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDArrow0);
        var idBolt0 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDBolt0);
        var idArrow1 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDArrow1);
        var idBolt1 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDBolt1);

        var idHelm =      BitConverter.ToUInt32(bytes, EquipmentDefinition.IDHelm);
        var idChest =     BitConverter.ToUInt32(bytes, EquipmentDefinition.IDChest);
        var idGauntlets = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDGauntlets);
        var idLeggings =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDLeggings);

        var idRing0 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDRing0);
        var idRing1 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDRing1);

        var idConsumable0 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDConsumable0);
        var idConsumable1 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDConsumable1);
        var idConsumable2 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDConsumable2);
        var idConsumable3 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDConsumable3);
        var idConsumable4 = BitConverter.ToUInt32(bytes, EquipmentDefinition.IDConsumable4);

        var idSpell0 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell0);
        _usagesSpell0 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell0);
        var idSpell1 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell1);
        _usagesSpell1 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell1);
        var idSpell2 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell2);
        _usagesSpell2 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell2);
        var idSpell3 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell3);
        _usagesSpell3 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell3);
        var idSpell4 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell4);
        _usagesSpell4 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell4);
        var idSpell5 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell5);
        _usagesSpell5 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell5);
        var idSpell6 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell6);
        _usagesSpell6 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell6);
        var idSpell7 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell7);
        _usagesSpell7 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell7);
        var idSpell8 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell8);
        _usagesSpell8 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell8);
        var idSpell9 =  BitConverter.ToUInt32(bytes, EquipmentDefinition.IDSpell9);
        _usagesSpell9 = BitConverter.ToUInt32(bytes, EquipmentDefinition.UsagesSpell9);
        
        
        _itemLeft0 =  invItems[_pointerLeft0];
        if (_itemLeft0.FullID != idLeft0)   throw new InvalidEquipmentIDException($"Inventory: {_itemLeft0.FullID}, SaveFile: {idLeft0}");
        _itemRight0 = invItems[_pointerRight0];
        if (_itemRight0.FullID != idRight0) throw new InvalidEquipmentIDException($"Inventory: {_itemRight0.FullID}, SaveFile: {idRight0}");
        _itemLeft1 =  invItems[_pointerLeft1];
        if (_itemLeft1.FullID != idLeft1)   throw new InvalidEquipmentIDException($"Inventory: {_itemLeft1.FullID}, SaveFile: {idLeft1}");
        _itemRight1 = invItems[_pointerRight1];
        if (_itemRight1.FullID != idRight1) throw new InvalidEquipmentIDException($"Inventory: {_itemRight1.FullID}, SaveFile: {idRight1}");

        
        if (idArrow0 != 0xFFFFFFFF)
        {
            _itemArrow0 = invItems[_pointerArrow0];
            if (_itemArrow0.FullID != idArrow0) throw new InvalidEquipmentIDException($"Inventory: {_itemArrow0.FullID}, SaveFile: {idArrow0}");
        } 
        else _itemArrow0 = Inventory.NoItem;

        if (idBolt0 != 0xFFFFFFFF)
        {
            _itemBolt0 = invItems[_pointerBolt0];
            if (_itemBolt0.FullID != idBolt0) throw new InvalidEquipmentIDException($"Inventory: {_itemBolt0.FullID}, SaveFile: {idBolt0}");
        }
        else _itemBolt0 = Inventory.NoItem;

        if (idArrow1 != 0xFFFFFFFF)
        {
            _itemArrow1 = invItems[_pointerArrow1];
            if (_itemArrow1.FullID != idArrow1) throw new InvalidEquipmentIDException($"Inventory: {_itemArrow1.FullID}, SaveFile: {idArrow1}");
        }
        else _itemArrow1 = Inventory.NoItem;

        if (idBolt1 != 0xFFFFFFFF)
        {

            _itemBolt1 = invItems[_pointerBolt1];
            if (_itemBolt1.FullID != idBolt1) throw new InvalidEquipmentIDException($"Inventory: {_itemBolt1.FullID}, SaveFile: {idBolt1}");
        }
        else _itemBolt1 = Inventory.NoItem;
        
        
        
        _itemHelm = invItems[_pointerHelm];
        if (_itemHelm.FullID != idHelm)           throw new InvalidEquipmentIDException($"Inventory: {_itemHelm.FullID}, SaveFile: {idHelm}");
        _itemChest = invItems[_pointerChest];
        if (_itemChest.FullID != idChest)         throw new InvalidEquipmentIDException($"Inventory: {_itemChest.FullID}, SaveFile: {idChest}");
        _itemGauntlets = invItems[_pointerGauntlets];
        if (_itemGauntlets.FullID != idGauntlets) throw new InvalidEquipmentIDException($"Inventory: {_itemGauntlets.FullID}, SaveFile: {idGauntlets}");
        _itemLeggings = invItems[_pointerLeggings];
        if (_itemLeggings.FullID != idLeggings)   throw new InvalidEquipmentIDException($"Inventory: {_itemLeggings.FullID}, SaveFile: {idLeggings}");
        
        
        
        if (idRing0 != 0xFFFFFFFF)
        {
            _itemRing0 = invItems[_pointerRing0];
            if (_itemRing0.FullID != idRing0) throw new InvalidEquipmentIDException($"Inventory: {_itemRing0.FullID}, SaveFile: {idRing0}");
        }
        else _itemRing0 = Inventory.NoItem;
        
        if (idRing1 != 0xFFFFFFFF)
        {
            _itemRing1 = invItems[_pointerRing1];
            if (_itemRing1.FullID != idRing1) throw new InvalidEquipmentIDException($"Inventory: {_itemRing1.FullID}, SaveFile: {idRing1}");
        }
        else _itemRing1 = Inventory.NoItem;
        
        
        
        if (idConsumable0 != 0xFFFFFFFF || _pointerConsumable00 != _pointerConsumable01)
        {
            _itemConsumable0 = invItems[_pointerConsumable00];
            if (_itemConsumable0.FullID != idConsumable0) throw new InvalidEquipmentIDException($"Inventory: {_itemConsumable0.FullID}, SaveFile: {idConsumable0}");
        }
        else _itemConsumable0 = Inventory.NoItem;
        
        if (idConsumable1 != 0xFFFFFFFF || _pointerConsumable10 != _pointerConsumable11)
        {
            _itemConsumable1 = invItems[_pointerConsumable10];
            if (_itemConsumable1.FullID != idConsumable1) throw new InvalidEquipmentIDException($"Inventory: {_itemConsumable1.FullID}, SaveFile: {idConsumable1}");
        }
        else _itemConsumable1 = Inventory.NoItem;
        
        if (idConsumable2 != 0xFFFFFFFF || _pointerConsumable20 != _pointerConsumable21)
        {
            _itemConsumable2 = invItems[_pointerConsumable20];
            if (_itemConsumable2.FullID != idConsumable2) throw new InvalidEquipmentIDException($"Inventory: {_itemConsumable2.FullID}, SaveFile: {idConsumable2}");
        }
        else _itemConsumable2 = Inventory.NoItem;
        
        if (idConsumable3 != 0xFFFFFFFF || _pointerConsumable30 != _pointerConsumable31)
        {
            _itemConsumable3 = invItems[_pointerConsumable30];
            if (_itemConsumable3.FullID != idConsumable3) throw new InvalidEquipmentIDException($"Inventory: {_itemConsumable3.FullID}, SaveFile: {idConsumable3}");
        }
        else _itemConsumable3 = Inventory.NoItem;
        
        if (idConsumable4 != 0xFFFFFFFF || _pointerConsumable40 != _pointerConsumable41)
        {
            _itemConsumable4 = invItems[_pointerConsumable40];
            if (_itemConsumable4.FullID != idConsumable4) throw new InvalidEquipmentIDException($"Inventory: {_itemConsumable4.FullID}, SaveFile: {idConsumable4}");
        }
        else _itemConsumable4 = Inventory.NoItem;
        
        
        
        if (idSpell0 != 0xFFFFFFFF)
        {
            _itemSpell0 = ItemList.GetItem(64, idSpell0);
            if (_itemSpell0.FullID != idSpell0) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell0.FullID}, SaveFile: {idSpell0}");
        }
        else _itemSpell0 = Inventory.NoItem;
        
        if (idSpell1 != 0xFFFFFFFF)
        {
            _itemSpell1 = ItemList.GetItem(64, idSpell1);
            if (_itemSpell1.FullID != idSpell1) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell1.FullID}, SaveFile: {idSpell1}");
        }
        else _itemSpell1 = Inventory.NoItem;
        
        if (idSpell2 != 0xFFFFFFFF)
        {
            _itemSpell2 = ItemList.GetItem(64, idSpell2);
            if (_itemSpell2.FullID != idSpell2) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell2.FullID}, SaveFile: {idSpell2}");
        }
        else _itemSpell2 = Inventory.NoItem;
        
        if (idSpell3 != 0xFFFFFFFF)
        {
            _itemSpell3 = ItemList.GetItem(64, idSpell3);
            if (_itemSpell3.FullID != idSpell3) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell3.FullID}, SaveFile: {idSpell3}");
        }
        else _itemSpell3 = Inventory.NoItem;
        
        if (idSpell4 != 0xFFFFFFFF)
        {
            _itemSpell4 = ItemList.GetItem(64, idSpell4);
            if (_itemSpell4.FullID != idSpell4) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell4.FullID}, SaveFile: {idSpell4}");
        }
        else _itemSpell4 = Inventory.NoItem;
        
        if (idSpell5 != 0xFFFFFFFF)
        {
            _itemSpell5 = ItemList.GetItem(64, idSpell5);
            if (_itemSpell5.FullID != idSpell5) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell5.FullID}, SaveFile: {idSpell5}");
        }
        else _itemSpell5 = Inventory.NoItem;
        
        if (idSpell6 != 0xFFFFFFFF)
        {
            _itemSpell6 = ItemList.GetItem(64, idSpell6);
            if (_itemSpell6.FullID != idSpell6) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell6.FullID}, SaveFile: {idSpell6}");
        }
        else _itemSpell6 = Inventory.NoItem;
        
        if (idSpell7 != 0xFFFFFFFF)
        {
            _itemSpell7 = ItemList.GetItem(64, idSpell7);
            if (_itemSpell7.FullID != idSpell7) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell7.FullID}, SaveFile: {idSpell7}");
        }
        else _itemSpell7 = Inventory.NoItem;
        
        if (idSpell8 != 0xFFFFFFFF)
        {
            _itemSpell8 = ItemList.GetItem(64, idSpell8);
            if (_itemSpell8.FullID != idSpell8) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell8.FullID}, SaveFile: {idSpell8}");
        }
        else _itemSpell8 = Inventory.NoItem;
        
        if (idSpell9 != 0xFFFFFFFF)
        {
            _itemSpell9 = ItemList.GetItem(64, idSpell9);
            if (_itemSpell9.FullID != idSpell9) throw new InvalidEquipmentIDException($"Inventory: {_itemSpell9.FullID}, SaveFile: {idSpell9}");
        }
        else _itemSpell9 = Inventory.NoItem;

        
        SelectedLeft = _bytes[EquipmentDefinition.SelectedLeft] == 0 ? _itemLeft0 : _itemLeft1;
        SelectedRight = _bytes[EquipmentDefinition.SelectedRight] == 0 ? _itemRight0 : _itemRight1;
        var selectedConsumableID = BitConverter.ToUInt32(bytes, EquipmentDefinition.SelectedConsumableID);
        if (_pointerConsumable00 == selectedConsumableID) SelectedConsumable = _itemConsumable0;
        else if (_pointerConsumable10 == selectedConsumableID) SelectedConsumable = _itemConsumable1;
        else if (_pointerConsumable20 == selectedConsumableID) SelectedConsumable = _itemConsumable2;
        else if (_pointerConsumable30 == selectedConsumableID) SelectedConsumable = _itemConsumable3;
        else if (_pointerConsumable40 == selectedConsumableID) SelectedConsumable = _itemConsumable4;

        _twoHanded = _bytes[EquipmentDefinition.TwoHanded] >> 1 == 1;
        
        SelectedSpellIndex = BitConverter.ToUInt32(bytes, EquipmentDefinition.SelectedSpellIndex);
    }

    public void UpdateData(ref byte[] data)
    {
        FillUInt32IntoData(ref data, _pointerLeft0,  EquipmentDefinition.PointerLeft0);
        FillUInt32IntoData(ref data, _pointerRight0, EquipmentDefinition.PointerRight0);
        FillUInt32IntoData(ref data, _pointerLeft1,  EquipmentDefinition.PointerLeft1);
        FillUInt32IntoData(ref data, _pointerRight1, EquipmentDefinition.PointerRight1);
        
        FillUInt32IntoData(ref data, _pointerArrow0, EquipmentDefinition.PointerArrow0);
        FillUInt32IntoData(ref data, _pointerBolt0,  EquipmentDefinition.PointerBolt0);
        FillUInt32IntoData(ref data, _pointerArrow1, EquipmentDefinition.PointerArrow1);
        FillUInt32IntoData(ref data, _pointerBolt1,  EquipmentDefinition.PointerBolt1);

        FillUInt32IntoData(ref data, _pointerHelm,      EquipmentDefinition.PointerHelm);
        FillUInt32IntoData(ref data, _pointerChest,     EquipmentDefinition.PointerChest);
        FillUInt32IntoData(ref data, _pointerGauntlets, EquipmentDefinition.PointerGauntlets);
        FillUInt32IntoData(ref data, _pointerLeggings,  EquipmentDefinition.PointerLeggings);
        
        FillUInt32IntoData(ref data, _pointerRing0, EquipmentDefinition.PointerRing0);
        FillUInt32IntoData(ref data, _pointerRing1, EquipmentDefinition.PointerRing1);
        
        FillUInt32IntoData(ref data, _pointerConsumable00, EquipmentDefinition.PointerConsumables00);
        FillUInt32IntoData(ref data, _pointerConsumable10, EquipmentDefinition.PointerConsumables10);
        FillUInt32IntoData(ref data, _pointerConsumable20, EquipmentDefinition.PointerConsumables20);
        FillUInt32IntoData(ref data, _pointerConsumable30, EquipmentDefinition.PointerConsumables30);
        FillUInt32IntoData(ref data, _pointerConsumable40, EquipmentDefinition.PointerConsumables40);
        FillUInt32IntoData(ref data, _pointerConsumable01, EquipmentDefinition.PointerConsumables01);
        FillUInt32IntoData(ref data, _pointerConsumable11, EquipmentDefinition.PointerConsumables11);
        FillUInt32IntoData(ref data, _pointerConsumable21, EquipmentDefinition.PointerConsumables21);
        FillUInt32IntoData(ref data, _pointerConsumable31, EquipmentDefinition.PointerConsumables31);
        FillUInt32IntoData(ref data, _pointerConsumable41, EquipmentDefinition.PointerConsumables41);
        
        FillUInt32IntoData(ref data, _itemLeft0.FullID,  EquipmentDefinition.IDLeft0);
        FillUInt32IntoData(ref data, _itemRight0.FullID, EquipmentDefinition.IDRight0);
        FillUInt32IntoData(ref data, _itemLeft1.FullID,  EquipmentDefinition.IDLeft1);
        FillUInt32IntoData(ref data, _itemRight1.FullID, EquipmentDefinition.IDRight1);
        
        FillUInt32IntoData(ref data, _itemArrow0.FullID, EquipmentDefinition.IDArrow0);
        FillUInt32IntoData(ref data, _itemBolt0.FullID,  EquipmentDefinition.IDBolt0);
        FillUInt32IntoData(ref data, _itemArrow1.FullID, EquipmentDefinition.IDArrow1);
        FillUInt32IntoData(ref data, _itemBolt1.FullID,  EquipmentDefinition.IDBolt1);
        
        FillUInt32IntoData(ref data, _itemHelm.FullID,      EquipmentDefinition.IDHelm);
        FillUInt32IntoData(ref data, _itemChest.FullID,     EquipmentDefinition.IDChest);
        FillUInt32IntoData(ref data, _itemGauntlets.FullID, EquipmentDefinition.IDGauntlets);
        FillUInt32IntoData(ref data, _itemLeggings.FullID,  EquipmentDefinition.IDLeggings);
        
        FillUInt32IntoData(ref data, _itemRing0.FullID, EquipmentDefinition.IDRing0);
        FillUInt32IntoData(ref data, _itemRing1.FullID, EquipmentDefinition.IDRing1);
        
        FillUInt32IntoData(ref data, _itemConsumable0.FullID, EquipmentDefinition.IDConsumable0);
        FillUInt32IntoData(ref data, _itemConsumable1.FullID, EquipmentDefinition.IDConsumable1);
        FillUInt32IntoData(ref data, _itemConsumable2.FullID, EquipmentDefinition.IDConsumable2);
        FillUInt32IntoData(ref data, _itemConsumable3.FullID, EquipmentDefinition.IDConsumable3);
        FillUInt32IntoData(ref data, _itemConsumable4.FullID, EquipmentDefinition.IDConsumable4);
        
        FillUInt32IntoData(ref data, _itemSpell0.FullID, EquipmentDefinition.IDSpell0);
        FillUInt32IntoData(ref data, _usagesSpell0, EquipmentDefinition.UsagesSpell0);
        FillUInt32IntoData(ref data, _itemSpell1.FullID, EquipmentDefinition.IDSpell1);
        FillUInt32IntoData(ref data, _usagesSpell1, EquipmentDefinition.UsagesSpell1);
        FillUInt32IntoData(ref data, _itemSpell2.FullID, EquipmentDefinition.IDSpell2);
        FillUInt32IntoData(ref data, _usagesSpell2, EquipmentDefinition.UsagesSpell2);
        FillUInt32IntoData(ref data, _itemSpell3.FullID, EquipmentDefinition.IDSpell3);
        FillUInt32IntoData(ref data, _usagesSpell3, EquipmentDefinition.UsagesSpell3);
        FillUInt32IntoData(ref data, _itemSpell4.FullID, EquipmentDefinition.IDSpell4);
        FillUInt32IntoData(ref data, _usagesSpell4, EquipmentDefinition.UsagesSpell4);
        FillUInt32IntoData(ref data, _itemSpell5.FullID, EquipmentDefinition.IDSpell5);
        FillUInt32IntoData(ref data, _usagesSpell5, EquipmentDefinition.UsagesSpell5);
        FillUInt32IntoData(ref data, _itemSpell6.FullID, EquipmentDefinition.IDSpell6);
        FillUInt32IntoData(ref data, _usagesSpell6, EquipmentDefinition.UsagesSpell6);
        FillUInt32IntoData(ref data, _itemSpell7.FullID, EquipmentDefinition.IDSpell7);
        FillUInt32IntoData(ref data, _usagesSpell7, EquipmentDefinition.UsagesSpell7);
        FillUInt32IntoData(ref data, _itemSpell8.FullID, EquipmentDefinition.IDSpell8);
        FillUInt32IntoData(ref data, _usagesSpell8, EquipmentDefinition.UsagesSpell8);
        FillUInt32IntoData(ref data, _itemSpell9.FullID, EquipmentDefinition.IDSpell9);
        FillUInt32IntoData(ref data, _usagesSpell9, EquipmentDefinition.UsagesSpell9);
        
        if (_twoHanded) data[EquipmentDefinition.TwoHanded] |= 0b00000010;
        else data[EquipmentDefinition.TwoHanded] &= 0b11111101;
        
        FillUInt32IntoData(ref data, _selectedSpellIndex, EquipmentDefinition.SelectedSpellIndex);
        FillUInt32IntoData(ref data, _selectedConsumable.FullID, EquipmentDefinition.SelectedConsumableID);

        if (_selectedLeft.Type == _itemLeft0.Type) data[EquipmentDefinition.SelectedLeft] = 0;
        else data[EquipmentDefinition.SelectedLeft] = 1;
        if (_selectedRight.Type == _itemRight0.Type) data[EquipmentDefinition.SelectedRight] = 0;
        else data[EquipmentDefinition.SelectedRight] = 1;
    }

    private void FillUInt32IntoData(ref byte[] data, UInt32 fill, int offset)
    {
        var fillBytes = BitConverter.GetBytes(fill);
        for (int i = 0; i < 4; i++)
        {
            data[i + offset] = fillBytes[i];
        }
    }
    
    public void ChangeSpell()
    {
        if (SelectedSpell.Type == Inventory.NoItem.Type) return;

        if (SelectedSpellIndex == 0 && ItemSpell1.Type != Inventory.NoItem.Type) SelectedSpellIndex = 1;
        else if (SelectedSpellIndex == 1)
        {
            if (ItemSpell2.Type != Inventory.NoItem.Type) SelectedSpellIndex = 2;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 2)
        {
            if (ItemSpell3.Type != Inventory.NoItem.Type) SelectedSpellIndex = 3;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 3)
        {
            if (ItemSpell4.Type != Inventory.NoItem.Type) SelectedSpellIndex = 4;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 4)
        {
            if (ItemSpell5.Type != Inventory.NoItem.Type) SelectedSpellIndex = 5;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 5)
        {
            if (ItemSpell6.Type != Inventory.NoItem.Type) SelectedSpellIndex = 6;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 6)
        {
            if (ItemSpell7.Type != Inventory.NoItem.Type) SelectedSpellIndex = 7;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 7)
        {
            if (ItemSpell8.Type != Inventory.NoItem.Type) SelectedSpellIndex = 8;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 8)
        {
            if (ItemSpell9.Type != Inventory.NoItem.Type) SelectedSpellIndex = 9;
            else if (ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
        } 
        else if (SelectedSpellIndex == 9 && ItemSpell0.Type != Inventory.NoItem.Type) SelectedSpellIndex = 0;
    }
    
    public void ChangeLeft()
    {
        if (SelectedLeft.FullID == ItemLeft0.FullID) SelectedLeft = ItemLeft1;
        else if (SelectedLeft.FullID == ItemLeft1.FullID) SelectedLeft = ItemLeft0;
    }
    
    public void ChangeRight()
    {
        if (SelectedRight.FullID == ItemRight0.FullID) SelectedRight = ItemRight1;
        else if (SelectedRight.FullID == ItemRight1.FullID) SelectedRight = ItemRight0;

        if (SelectedRight.Type == ItemType.Fists) TwoHanded = false;
    }
    
    public void ChangeConsumable()
    {
        if (SelectedConsumable.Type == Inventory.NoItem.Type) return;

        if (SelectedConsumable.Type == ItemConsumable0.Type && ItemConsumable1.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable1;
        else if (SelectedConsumable.Type == ItemConsumable1.Type)
        {
            if (ItemConsumable2.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable2;
            else if (ItemConsumable0.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable0;
        } 
        else if (SelectedConsumable.Type == ItemConsumable2.Type)
        {
            if (ItemConsumable3.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable3;
            else if (ItemConsumable0.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable0;
        } 
        else if (SelectedConsumable.Type == ItemConsumable3.Type)
        {
            if (ItemConsumable2.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable4;
            else if (ItemConsumable0.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable0;
        } 
        else if (SelectedConsumable.Type == ItemConsumable4.Type && ItemConsumable2.Type != Inventory.NoItem.Type) SelectedConsumable = ItemConsumable0;
    }
    
    #region Properties
    
    public Item SelectedLeft
    {
        get => _selectedLeft;
        private set
        {
            _selectedLeft = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item SelectedRight
    {
        get => _selectedRight;
        private set
        {
            _selectedRight = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item SelectedSpell
    {
        get => _selectedSpell;
        private set
        {
            _selectedSpell = value;
            NotifyPropertyChanged();
        }
    }
    public Item SelectedConsumable
    {
        get => _selectedConsumable;
        private set
        {
            _selectedConsumable = value;
            NotifyPropertyChanged();
        }
    }
    
    
    
    public Item ItemLeft0
    {
        get => _itemLeft0;
        set
        {
            _itemLeft0 = value;
            _pointerLeft0 = (uint)_itemLeft0.Index;
            NotifyPropertyChanged();
        }
    }

    public Item ItemRight0
    {
        get => _itemRight0;
        set
        {
            _itemRight0 = value;
            _pointerRight0 = (uint)_itemRight0.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemLeft1
    {
        get => _itemLeft1;
        set
        {
            _itemLeft1 = value;
            _pointerLeft1 = (uint)_itemLeft1.Index;
            NotifyPropertyChanged();
        }
    }

    public Item ItemRight1
    {
        get => _itemRight1;
        set
        {
            _itemRight1 = value;
            _pointerRight1 = (uint)_itemRight1.Index;
            NotifyPropertyChanged();
        }
    }
    
    
    
    public Item ItemArrow0
    {
        get => _itemArrow0;
        set
        {
            _itemArrow0 = value;
            _pointerArrow0 = (uint)_itemArrow0.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemBolt0
    {
        get => _itemBolt0;
        set
        {
            _itemBolt0 = value;
            _pointerBolt0 = (uint)_itemBolt0.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemArrow1
    {
        get => _itemArrow1;
        set
        {
            _itemArrow1 = value;
            _pointerArrow1 = (uint)_itemArrow1.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemBolt1
    {
        get => _itemBolt1;
        set
        {
            _itemBolt1 = value;
            _pointerBolt1 = (uint)_itemBolt1.Index;
            NotifyPropertyChanged();
        }
    }
    
    
    
    public Item ItemHelm
    {
        get => _itemHelm;
        set
        {
            _itemHelm = value;
            _pointerHelm = (uint)_itemHelm.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemChest
    {
        get => _itemChest;
        set
        {
            _itemChest = value;
            _pointerChest = (uint)_itemChest.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemGauntlets
    {
        get => _itemGauntlets;
        set
        {
            _itemGauntlets = value;
            _pointerGauntlets = (uint)_itemGauntlets.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemLeggings
    {
        get => _itemLeggings;
        set
        {
            _itemLeggings = value;
            _pointerLeggings = (uint)_itemLeggings.Index;
            NotifyPropertyChanged();
        }
    }
    
    
    
    
    public Item ItemRing0
    {
        get => _itemRing0;
        set
        {
            _itemRing0 = value;
            _pointerRing0 = (uint)_itemRing0.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemRing1
    {
        get => _itemRing1;
        set
        {
            _itemRing1 = value;
            _pointerRing1 = (uint)_itemRing1.Index;
            NotifyPropertyChanged();
        }
    }
    
    
    
    
    public Item ItemConsumable0
    {
        get => _itemConsumable0;
        set
        {
            _itemConsumable0 = value;
            _pointerConsumable00 = (uint)_itemConsumable0.Index;
            _pointerConsumable01 = (uint)_itemConsumable0.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemConsumable1
    {
        get => _itemConsumable1;
        set
        {
            _itemConsumable1 = value;
            _pointerConsumable10 = (uint)_itemConsumable1.Index;
            _pointerConsumable11 = (uint)_itemConsumable1.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemConsumable2
    {
        get => _itemConsumable2;
        set
        {
            _itemConsumable2 = value;
            _pointerConsumable20 = (uint)_itemConsumable2.Index;
            _pointerConsumable21 = (uint)_itemConsumable2.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemConsumable3
    {
        get => _itemConsumable3;
        set
        {
            _itemConsumable3 = value;
            _pointerConsumable30 = (uint)_itemConsumable3.Index;
            _pointerConsumable31 = (uint)_itemConsumable3.Index;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemConsumable4
    {
        get => _itemConsumable4;
        set
        {
            _itemConsumable4 = value;
            _pointerConsumable40 = (uint)_itemConsumable4.Index;
            _pointerConsumable41 = (uint)_itemConsumable4.Index;
            NotifyPropertyChanged();
        }
    }
    
    
    
    
    public Item ItemSpell0
    {
        get => _itemSpell0;
        set
        {
            _itemSpell0 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell1
    {
        get => _itemSpell1;
        set
        {
            _itemSpell1 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell2
    {
        get => _itemSpell2;
        set
        {
            _itemSpell2 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell3
    {
        get => _itemSpell3;
        set
        {
            _itemSpell3 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell4
    {
        get => _itemSpell4;
        set
        {
            _itemSpell4 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell5
    {
        get => _itemSpell5;
        set
        {
            _itemSpell5 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell6
    {
        get => _itemSpell6;
        set
        {
            _itemSpell6 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell7
    {
        get => _itemSpell7;
        set
        {
            _itemSpell7 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell8
    {
        get => _itemSpell8;
        set
        {
            _itemSpell8 = value;
            NotifyPropertyChanged();
        }
    }
    
    public Item ItemSpell9
    {
        get => _itemSpell9;
        set
        {
            _itemSpell9 = value;
            NotifyPropertyChanged();
        }
    }
    

    public uint SelectedSpellIndex
    {
        get => _selectedSpellIndex;
        set
        {
            if (value > 9 && value != 0xFFFFFFFF) throw new Exception($"Invalid Spell Index: {value}");
            _selectedSpellIndex = value;
            SelectedSpell = _selectedSpellIndex switch
            {
                0 => ItemSpell0,
                1 => ItemSpell1,
                2 => ItemSpell2,
                3 => ItemSpell3,
                4 => ItemSpell4,
                5 => ItemSpell5,
                6 => ItemSpell6,
                7 => ItemSpell7,
                8 => ItemSpell8,
                9 => ItemSpell9,
                _ => Inventory.NoItem
            };
            NotifyPropertyChanged();
        }
    }

    public bool TwoHanded
    {
        get => _twoHanded;
        set
        {
            if (value && SelectedRight.Type == ItemType.Fists) return;
            _twoHanded = value;
            NotifyPropertyChanged();
        }
    }

    #endregion

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}