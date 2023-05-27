using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using DSR.SavefileStructure;
using DSR.SlotDetails;
using GUI.Helper;

namespace GUI.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private SaveFile _saveFile;
    private ObservableCollection<SaveSlotDetails> _saveSlotDetails;
    private ObservableCollection<WeaponTypeGroup> _weaponTypeGroups;
    private SaveSlotDetails _selectedSlot;
    private InventoryImageContainer _selectedInventoryTab;

    public MainViewModel()
    {
        _saveSlotDetails = new ObservableCollection<SaveSlotDetails>();
        _weaponTypeGroups = new ObservableCollection<WeaponTypeGroup>();
    }

    public void ImportSavefile(string path)
    {
        _saveFile = new SaveFile(File.ReadAllBytes(path));
        foreach (var slot in _saveFile.SaveSlots)
        {
            _saveSlotDetails.Add(slot.Details);
        }
    }

    public void ExportSavefile(string path)
    {
        _saveFile.WriteToFile(path);
    }

    public void SetupItemGroups()
    {
        /*_weaponTypeGroups.Add(new WeaponTypeGroup("Images/ItemIcons/Weapons/Types/StraightSwords.png", "Straight Swords", new []
        {
            new WeaponGroup("Longsword", SpecificWeaponType.Longsword),
        }));*/
    }

    public void SetDefaultInventoryItem(InventoryImageContainer inventoryImageContainer)
    {
        _selectedInventoryTab = inventoryImageContainer;
        _selectedInventoryTab.Selected = true;
    }

    public ObservableCollection<SaveSlotDetails> SaveSlotDetails => _saveSlotDetails;
    
    public ObservableCollection<WeaponTypeGroup> WeaponTypeGroups => _weaponTypeGroups;

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
            
            NotifyPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}