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
using GUI.Views;

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
    private List<ItemGroup> _upgradeMaterials;
    private List<ItemGroup> _keyItems;
    private List<ItemGroup> _spells;
    private List<ItemGroup> _weapons;
    private List<ItemGroup> _ammunition;
    private List<ItemGroup> _armor;
    private List<ItemGroup> _rings;

    public MainViewModel()
    {
        _selectedInventoryItems = new ObservableCollection<Item>();
        _selectedTree = new ObservableCollection<ItemGroup>();
        _saveSlotDetails = new ObservableCollection<SaveSlotDetails>();

        _consumables = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Consumables.png", "Consumables", ItemList.GetItems(typeof(CommonItem), true)),
            new ("Images/ItemIcons/Types/Souls.png",       "Souls",       ItemList.GetItems(typeof(CommonSoul)))
        };
        var upgradeMaterials = ItemList.GetItems(typeof(UpgradeMaterial));
        _upgradeMaterials = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Titanite.png",        "Titanite",         upgradeMaterials.Where(um => (um as UpgradeMaterial).MaterialType == MaterialType.Normal).ToList()),
            new ("Images/ItemIcons/Types/ColoredTitanite.png", "Colored Titanite", upgradeMaterials.Where(um => (um as UpgradeMaterial).MaterialType == MaterialType.Colored).ToList()),
            new ("Images/ItemIcons/Types/UniqueTitanite.png",  "Unique Titanite",  upgradeMaterials.Where(um => (um as UpgradeMaterial).MaterialType == MaterialType.Unique).ToList()),
        };
        // TODO
        _keyItems = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/KeyItems.png",      "Key Items",      ItemList.GetItems(typeof(KeyItem))),
        };
        // TODO 
        _spells = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Spells.png",      "Spells",      ItemList.GetItems(typeof(Spell))),
        };
        var weapons = ItemList.GetItems(typeof(Weapon)).Where(w => w.Type is not ItemType.Fists);
        _weapons = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Daggers.png",        "Daggers",         weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Dagger).ToList()),
            new ("Images/ItemIcons/Types/StraightSwords.png", "Straight Swords", weapons.Where(w => (w as Weapon).WeaponType == WeaponType.StraightSword).ToList()),
            new ("Images/ItemIcons/Types/Greatswords.png",    "Greatswords",     weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Greatsword).ToList()),
        };
        // TODO
        _ammunition = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Arrows.png",      "Arrows",      weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Arrow).ToList()),
            new ("Images/ItemIcons/Types/Bolts.png",       "Bolts",      weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Bolt).ToList()),
        };
        _armor = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Armor.png",      "Armor",      ItemList.GetItems(typeof(Armor)).Where(a => (a as Armor).BaseID is not 900000).ToList()),
        };
        _rings = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Rings.png",      "Rings",      ItemList.GetItems(typeof(Ring))),
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
        List<Item> inventoryItemList = new List<Item>();
        
        if (inventoryImageContainer.ImagePath.Contains("Consumable", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = new List<Item>();
            inventoryItemList.AddRange(SelectedSlot.Inventory.GetItemOfType(typeof(CommonItem)));
            
            FillTree(_consumables);
            
        } else if (inventoryImageContainer.ImagePath.Contains("UpgradeMaterial", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(UpgradeMaterial));
            
            FillTree(_upgradeMaterials);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("KeyItems", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(KeyItem));
            
            FillTree(_keyItems);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Spells", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Spell));
            
            FillTree(_spells);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Weapon", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Weapon)).Where(w => w.ID < 2000000).ToList();
            
            FillTree(_weapons);
            
        } 
        else if (inventoryImageContainer.ImagePath.Contains("Ammunition", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Weapon)).Where(w => (w as Weapon).WeaponType is WeaponType.Arrow or WeaponType.Bolt).ToList();
            
            FillTree(_ammunition);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Armor", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Armor));

            FillTree(_armor);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Rings", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Ring));

            FillTree(_rings);
            
        }
        
        FillItemList(inventoryItemList);
    }

    private void FillItemList(List<Item> items)
    {
        items.Sort((i1, i2) => (int)(i1.Sorting - i2.Sorting));
        
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



    public void AddItem(Item item)
    {
        var addItemView = new AddItemView(SelectedSlot.Inventory, item);
        var dialogResult = addItemView.ShowDialog();
        
        LoadTree(SelectedInventoryTab);
        
        if (true) return;
        
        if (item is Weapon weapon && weapon.WeaponType is not WeaponType.Arrow and WeaponType.Bolt)
        {
                
        }
            
        if (item is not UpgradeMaterial material) return;

        if (SelectedSlot.Inventory.TryGetItem(item.Type, out var invItem))
        {
            // Item already exists in inventory
            invItem.Amount = invItem.MaxAmount;
        }
        else
        {
            // Add new item
            item.Amount = item.MaxAmount;
            SelectedSlot.Inventory.AddItem(item);
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