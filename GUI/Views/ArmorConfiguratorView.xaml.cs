using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DSR.SlotDetails;
using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using GUI.ViewModels;

namespace GUI.Views;

public partial class ArmorConfiguratorView : Window
{
    private ArmorConfiguratorViewModel _vm;
    
    public ArmorConfiguratorView(Inventory inventory, Armor armor, bool newItem)
    {
        InitializeComponent();

        _vm = new ArmorConfiguratorViewModel(inventory, armor, newItem);
        MainGrid.DataContext = _vm;

        SetAvailableLevels();

        foreach (var item in CBLevel.ItemsSource)
        {
            if ((item as CBLevelItem).Level != armor.Level) continue;

            CBLevel.SelectedItem = item;
            break;
        }
    }

    private void SetAvailableLevels()
    {
        var upgradeType = _vm.Armor.ArmorUpgradeType;
        
        var list = new List<CBLevelItem>
        {
            new (0),
        };

        var u5 = new List<CBLevelItem>
        {
            new (1),
            new (2),
            new (3),
            new (4),
            new (5),
        };
        
        var u10 = new List<CBLevelItem>
        {
            new (6),
            new (7),
            new (8),
            new (9),
            new (10),
        };

        if (upgradeType == ArmorUpgradeType.Regular)
        {
            list.AddRange(u5);
            list.AddRange(u10);
        } 
        else if (upgradeType == ArmorUpgradeType.Twinkling)
        {
            list.AddRange(u5);
        }

        CBLevel.ItemsSource = list;
    }

    private void Btn_Confirm_OnClick(object sender, RoutedEventArgs e)
    {
        if (!_vm.NewItem) DialogResult = true;
        else DialogResult = _vm.AddArmor();
        Close();
    }

    private void Btn_Close_OnClick(object sender, RoutedEventArgs e)
    {
        _vm.ResetChanges();
        DialogResult = false;
        Close();
    }

    private void CBLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CBLevel.SelectedItem is not CBLevelItem cbLevelItem) return;
        _vm.Armor.Level = cbLevelItem.Level;
    }
    



    #region Helper Classes

    private class CBLevelItem
    {
        public CBLevelItem(uint level)
        {
            Level = level;
        }
        
        public uint Level { get; private set; }
    }
    
    #endregion
}