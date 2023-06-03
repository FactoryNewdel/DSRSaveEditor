using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DSR.SavefileStructure;
using DSR.SlotDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using GUI.Helper;

namespace GUI.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private SaveFile _saveFile;
    private ObservableCollection<SaveSlotDetails> _saveSlotDetails;

    private SaveSlotDetails _selectedSlot;
    private InventoryImageContainer _selectedInventoryTab;
    
    private ObservableCollection<Item> _selectedInventoryItems;
    private ObservableCollection<ItemGroup> _selectedTree;
    private List<ItemGroup> _consumables;
    private List<ItemGroup> _weapons;

    public MainViewModel()
    {
        _selectedInventoryItems = new ObservableCollection<Item>();
        _selectedTree = new ObservableCollection<ItemGroup>();
        _saveSlotDetails = new ObservableCollection<SaveSlotDetails>();

        _consumables = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Consumables.png", "Consumables", ItemList.GetItems(typeof(CommonItem)))
        };
        var weapons = ItemList.GetItems(typeof(Weapon));
        _weapons = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Daggers.png",        "Daggers",         weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Dagger).ToList()),
            new ("Images/ItemIcons/Types/StraightSwords.png", "Straight Swords", weapons.Where(w => (w as Weapon).WeaponType == WeaponType.StraightSword).ToList()),
            new ("Images/ItemIcons/Types/Greatswords.png",    "Greatswords",     weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Greatsword).ToList()),
        };
    }

    public void ImportSavefile(string path)
    {
        _saveFile = new SaveFile(File.ReadAllBytes(path));
        _saveSlotDetails.Clear();
        foreach (var slot in _saveFile.SaveSlots)
        {
            _saveSlotDetails.Add(slot.Details);
        }
    }

    public void ExportSavefile(string path)
    {
        _saveFile.WriteToFile(path);
    }

    public void SetDefaultInventoryItem(InventoryImageContainer inventoryImageContainer)
    {
        _selectedInventoryTab = inventoryImageContainer;
        _selectedInventoryTab.Selected = true;
        LoadTree(inventoryImageContainer);
    }

    private void LoadTree(InventoryImageContainer inventoryImageContainer)
    {
        if (inventoryImageContainer.ImagePath.Contains("Consumable", StringComparison.InvariantCultureIgnoreCase))
        {
            var list = new List<Item>();
            list.AddRange(SelectedSlot.Inventory.GetItemOfType(typeof(CommonItem)));
            list.AddRange(SelectedSlot.Inventory.GetItemOfType(typeof(CommonSoul)));
            list.Sort((i1, i2) => (int)(i1.Sorting - i2.Sorting));
            FillItemList(list);
            FillTree(_consumables);
        }
        else if (inventoryImageContainer.ImagePath.Contains("Weapon", StringComparison.InvariantCultureIgnoreCase))
        {
            var list = SelectedSlot.Inventory.GetItemOfType(typeof(Weapon)).Where(w => w.ID < 2000000 && w.Type != ItemType.Fists).ToList();
            list.Sort((i1, i2) => (int)(i1.Sorting - i2.Sorting));
            FillItemList(list);
            FillTree(_weapons);
        }
    }

    private void FillItemList(List<Item> items)
    {
        _selectedInventoryItems.Clear();
        foreach (var item in items)
        {
            _selectedInventoryItems.Add(item);
        }
    }

    private void FillTree(List<ItemGroup> items)
    {
        _selectedTree.Clear();
        foreach (var item in items)
        {
            _selectedTree.Add(item);
        }
    }

    public ObservableCollection<SaveSlotDetails> SaveSlotDetails => _saveSlotDetails;

    public SaveSlotDetails SelectedSlot
    {
        get => _selectedSlot;
        set
        {
            _selectedSlot = value;
            NotifyPropertyChanged();
        }
    }

    public InventoryImageContainer SelectedInventoryTab
    {
        get => _selectedInventoryTab;
        set
        {
            if (_selectedInventoryTab == value) return;
            _selectedInventoryTab.Selected = false;

            _selectedInventoryTab = value;
            _selectedInventoryTab.Selected = true;

            LoadTree(_selectedInventoryTab);
            
            NotifyPropertyChanged();
        }
    }
    
    public ObservableCollection<Item> SelectedInventoryItems => _selectedInventoryItems;
    
    public ObservableCollection<ItemGroup> SelectedTree => _selectedTree;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}