using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using DSR.SavefileStructure;
using DSR.SlotDetails;
using DSR.SlotDetails.InventoryDetails;
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
            new ("Images/ItemIcons/Types/Consumables.png",  "Consumables",   ItemList.GetItems(typeof(CommonItem), true).OrderBy(i => i.Name).ToList()),
            new ("Images/ItemIcons/Types/SpecialItems.png", "Special Items", ItemList.GetItems(typeof(SpecialItem)).OrderBy(i => i.Name).ToList()),
            new ("Images/ItemIcons/Types/Souls.png",        "Souls",         ItemList.GetItems(typeof(CommonSoul))),
            new ("Images/ItemIcons/Types/BossSouls.png",    "Boss Souls",    ItemList.GetItems(typeof(BossSoul))),
        };
        var upgradeMaterials = ItemList.GetItems(typeof(UpgradeMaterial));
        _upgradeMaterials = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Titanite.png",        "Titanite",         upgradeMaterials.Where(um => (um as UpgradeMaterial).MaterialType == MaterialType.Normal).ToList()),
            new ("Images/ItemIcons/Types/ColoredTitanite.png", "Colored Titanite", upgradeMaterials.Where(um => (um as UpgradeMaterial).MaterialType == MaterialType.Colored).ToList()),
            new ("Images/ItemIcons/Types/UniqueTitanite.png",  "Unique Titanite",  upgradeMaterials.Where(um => (um as UpgradeMaterial).MaterialType == MaterialType.Unique).ToList()),
        };
        var keyItems = ItemList.GetItems(typeof(KeyItem));
        _keyItems = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Keys.png",             "Keys",             keyItems.Where(k => (k as KeyItem).KeyItemType == KeyItemType.Key).ToList()),
            new ("Images/ItemIcons/Types/Embers.png",           "Embers",           keyItems.Where(k => (k as KeyItem).KeyItemType == KeyItemType.Ember).ToList()),
            new ("Images/ItemIcons/Types/BonfireUpgrades.png",  "Bonfire Upgrades", keyItems.Where(k => (k as KeyItem).KeyItemType == KeyItemType.BonfireUpgrade).ToList()),
            new ("Images/ItemIcons/Types/LordItems.png",        "Lord Items",       keyItems.Where(k => (k as KeyItem).KeyItemType == KeyItemType.LordItem).ToList()),
            new ("Images/ItemIcons/Types/SpecialItemsKeys.png", "Special Items",    keyItems.Where(k => (k as KeyItem).KeyItemType == KeyItemType.Special).ToList()),
        };
        // TODO 
        var spells = ItemList.GetItems(typeof(Spell));
        _spells = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Sorceries.png",       "Sorceries",      spells.Where(s => (s as Spell).SpellType == SpellType.Sorcery).ToList()),
            new ("Images/ItemIcons/Types/Pyromancies.png",     "Pyromancy",      spells.Where(s => (s as Spell).SpellType == SpellType.Pyromancy).ToList()),
            new ("Images/ItemIcons/Types/Miracles.png",        "Miracle",        spells.Where(s => (s as Spell).SpellType == SpellType.Miracle).ToList()),
        };
        var weapons = ItemList.GetItems(typeof(Weapon)).Where(w => w.Type is not ItemType.Fists);
        _weapons = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Daggers.png",            "Daggers",            weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Dagger).ToList()),
            new ("Images/ItemIcons/Types/StraightSwords.png",     "Straight Swords",    weapons.Where(w => (w as Weapon).WeaponType == WeaponType.StraightSword).ToList()),
            new ("Images/ItemIcons/Types/Greatswords.png",        "Greatswords",        weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Greatsword).ToList()),
            new ("Images/ItemIcons/Types/UltraGreatswords.png",   "Ultra Greatswords",  weapons.Where(w => (w as Weapon).WeaponType == WeaponType.UltraGreatsword).ToList()),
            new ("Images/ItemIcons/Types/CurvedSwords.png",       "Curved Swords",      weapons.Where(w => (w as Weapon).WeaponType == WeaponType.CurvedSword).ToList()),
            new ("Images/ItemIcons/Types/Katanas.png",            "Katanas",            weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Katana).ToList()),
            new ("Images/ItemIcons/Types/CurvedGreatswords.png",  "Curved Greatswords", weapons.Where(w => (w as Weapon).WeaponType == WeaponType.CurvedGreatsword).ToList()),
            new ("Images/ItemIcons/Types/PiercingSwords.png",     "Piercing Swords",    weapons.Where(w => (w as Weapon).WeaponType == WeaponType.PiercingSword).ToList()),
            new ("Images/ItemIcons/Types/Axes.png",               "Axes",               weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Axe).ToList()),
            new ("Images/ItemIcons/Types/GreatAxes.png",          "Great Axes",         weapons.Where(w => (w as Weapon).WeaponType == WeaponType.GreatAxe).ToList()),
            new ("Images/ItemIcons/Types/Hammers.png",            "Hammers",            weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Hammer).ToList()),
            new ("Images/ItemIcons/Types/GreatHammers.png",       "Great Hammers",      weapons.Where(w => (w as Weapon).WeaponType == WeaponType.GreatHammer).ToList()),
            new ("Images/ItemIcons/Types/FistWeapons.png",        "Fist Weapons",       weapons.Where(w => (w as Weapon).WeaponType == WeaponType.FistWeapon).ToList()),
            new ("Images/ItemIcons/Types/Spears.png",             "Spears",             weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Spear).ToList()),
            new ("Images/ItemIcons/Types/Halberds.png",           "Halberds",           weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Halberd).ToList()),
            new ("Images/ItemIcons/Types/Whips.png",              "Whips",              weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Whip).ToList()),
            new ("Images/ItemIcons/Types/Bows.png",               "Bows",               weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Bow).ToList()),
            new ("Images/ItemIcons/Types/Crossbows.png",          "Crossbows",          weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Crossbow).ToList()),
            new ("Images/ItemIcons/Types/Catalysts.png",          "Catalysts",          weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Catalyst).ToList()),
            new ("Images/ItemIcons/Types/PyromancyFlames.png",    "Pyromancy Flames",   weapons.Where(w => (w as Weapon).WeaponType == WeaponType.PyromancyFlame).ToList()),
            new ("Images/ItemIcons/Types/Talismans.png",          "Talismans",          weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Talisman).ToList()),
            new ("Images/ItemIcons/Types/SmallShields.png",       "Small Shields",      weapons.Where(w => (w as Weapon).WeaponType == WeaponType.SmallShield).ToList()),
            new ("Images/ItemIcons/Types/StandardShields.png",    "Standard Shields",   weapons.Where(w => (w as Weapon).WeaponType == WeaponType.StandardShield).ToList()),
            new ("Images/ItemIcons/Types/Greatshields.png",       "Greatshields",       weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Greatshield).ToList()),
            new ("Images/ItemIcons/Types/SpecialShields.png",     "Special / DLC",      weapons.Where(w => (w as Weapon).WeaponType == WeaponType.SpecialAndDLC).ToList()),
            new ("Images/ItemIcons/Types/BossWeapons.png",        "Boss Weapons",       weapons.Where(w => w is BossWeapon).ToList()),
        };
        // TODO
        _ammunition = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Arrows.png",      "Arrows",     weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Arrow).ToList()),
            new ("Images/ItemIcons/Types/Bolts.png",       "Bolts",      weapons.Where(w => (w as Weapon).WeaponType == WeaponType.Bolt).ToList()),
        };
        var armor = ItemList.GetItems(typeof(Armor)).Where(a => (a as Armor).BaseID != 900000);
        _armor = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Armor.png",      "Head Pieces", armor.Where(a => (a as Armor).ArmorPieceType == ArmorPieceType.Helm)      .OrderBy(i => i.Name).ToList()),
            new ("Images/ItemIcons/Types/Armor.png",      "Chestplates", armor.Where(a => (a as Armor).ArmorPieceType == ArmorPieceType.Chestplate).OrderBy(i => i.Name).ToList()),
            new ("Images/ItemIcons/Types/Armor.png",      "Gauntlets",   armor.Where(a => (a as Armor).ArmorPieceType == ArmorPieceType.Gauntlets) .OrderBy(i => i.Name).ToList()),
            new ("Images/ItemIcons/Types/Armor.png",      "Legs",        armor.Where(a => (a as Armor).ArmorPieceType == ArmorPieceType.Leggins)   .OrderBy(i => i.Name).ToList()),
        };
        _rings = new List<ItemGroup>
        {
            new ("Images/ItemIcons/Types/Rings.png",      "Rings",      ItemList.GetItems(typeof(Ring)).OrderBy(i => i.Name).ToList()),
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

    private void LoadTree(InventoryImageContainer inventoryImageContainer, bool loadTree = true)
    {
        List<Item> inventoryItemList = new List<Item>();
        
        if (inventoryImageContainer.ImagePath.Contains("Consumable", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = new List<Item>();
            inventoryItemList.AddRange(SelectedSlot.Inventory.GetItemOfType(typeof(CommonItem)));
            
            if (loadTree) FillTree(_consumables);
            
        } else if (inventoryImageContainer.ImagePath.Contains("UpgradeMaterial", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(UpgradeMaterial));
            
            if (loadTree) FillTree(_upgradeMaterials);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("KeyItems", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(KeyItem));
            
            if (loadTree) FillTree(_keyItems);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Spells", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Spell));
            
            if (loadTree) FillTree(_spells);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Weapon", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Weapon)).Where(w => w.ID < 2000000 && w.Type != ItemType.Fists).ToList();
            
            if (loadTree) FillTree(_weapons);
            
        } 
        else if (inventoryImageContainer.ImagePath.Contains("Ammunition", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Weapon)).Where(w => (w as Weapon).WeaponType is WeaponType.Arrow or WeaponType.Bolt).ToList();
            
            if (loadTree) FillTree(_ammunition);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Armor", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Armor)).Where(a => a.Type is not (ItemType.Helm or ItemType.Chest or ItemType.Gauntlets or ItemType.Leggings)).ToList();

            if (loadTree) FillTree(_armor);
            
        }
        else if (inventoryImageContainer.ImagePath.Contains("Rings", StringComparison.InvariantCultureIgnoreCase))
        {
            inventoryItemList = SelectedSlot.Inventory.GetItemOfType(typeof(Ring));

            if (loadTree) FillTree(_rings);
            
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



    public bool AddItem(Item item)
    {
        var addItemView = new AddItemView(SelectedSlot.Inventory, item);
        var dialogResult = addItemView.ShowDialog();
        
        if (dialogResult != true) return false;
        
        LoadTree(SelectedInventoryTab, false);
        return true;
    }

    public bool ChangeItemAmount(Item item)
    {
        var addItemView = new ChangeItemAmountView(item);
        var dialogResult = addItemView.ShowDialog();
        
        if (dialogResult != true) return false;
        
        LoadTree(SelectedInventoryTab, false);
        return true;
    }

    public bool DeleteItem(Item item)
    {
        bool result = SelectedSlot.Inventory.RemoveItem(item);
        LoadTree(SelectedInventoryTab);
        return result;
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