using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DSR.SlotDetails;
using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using GUI.ViewModels;

namespace GUI.Views;

public partial class WeaponConfiguratorView : Window
{
    private WeaponConfiguratorViewModel _vm;
    
    public WeaponConfiguratorView(Inventory inventory, Weapon weapon, bool newItem)
    {
        InitializeComponent();

        _vm = new WeaponConfiguratorViewModel(inventory, weapon, newItem);
        MainGrid.DataContext = _vm;

        SetAvailableInfusions();
        SetAvailableLevels();
        
        foreach (var item in CBInfusion.ItemsSource)
        {
            if ((item as CBInfusionItem).Infusion != weapon.Infusion) continue;

            CBInfusion.SelectedItem = item;
            break;
        }
        
        foreach (var item in CBLevel.ItemsSource)
        {
            if ((item as CBLevelItem).Level != weapon.Level) continue;

            CBLevel.SelectedItem = item;
            break;
        }
    }


    private void SetAvailableInfusions()
    {
        var upgradeType = _vm.Weapon.WeaponUpgradeType;
        
        var list = new List<CBInfusionItem>
        {
            new (Infusion.None),
        };

        var all = new List<CBInfusionItem>
        {
            new(Infusion.Crystal),
            new(Infusion.Lightning),
            new(Infusion.Raw),
            new(Infusion.Magic),
            new(Infusion.Enchanted),
            new(Infusion.Divine),
            new(Infusion.Occult),
            new(Infusion.Fire),
            new(Infusion.Chaos),
        };
        
        var allCrossbowAndShield = new List<CBInfusionItem>
        {
            new(Infusion.Crystal),
            new(Infusion.Lightning),
            new(Infusion.Magic),
            new(Infusion.Divine),
            new(Infusion.Fire),
        };
        
        
        if (upgradeType == WeaponUpgradeType.Full)
        {
            list.AddRange(all);
        } else if (upgradeType == WeaponUpgradeType.FullCrossbow)
        {
            list.AddRange(allCrossbowAndShield);
        } else if (upgradeType == WeaponUpgradeType.ShieldFull)
        {
            list.AddRange(allCrossbowAndShield);
        }

        CBInfusion.ItemsSource = list;
    }
    
    private void SetAvailableLevels()
    {
        var upgradeType = _vm.Weapon.WeaponUpgradeType;
        var infusion = _vm.Weapon.Infusion;
        
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
        
        var u15 = new List<CBLevelItem>
        {
            new (11),
            new (12),
            new (13),
            new (14),
            new (15),
        };

        if (upgradeType == WeaponUpgradeType.Full)
        {
            list.AddRange(u5);
            
            if (infusion is (Infusion.None or Infusion.Magic or Infusion.Divine or Infusion.Fire)) list.AddRange(u10);
            if (infusion == Infusion.None) list.AddRange(u15);
        } 
        else if (upgradeType is (WeaponUpgradeType.Demon or WeaponUpgradeType.Twinkling or WeaponUpgradeType.Scales))
        {
            list.AddRange(u5);
        } 
        else if (upgradeType is (WeaponUpgradeType.FullCrossbow or WeaponUpgradeType.ShieldFull))
        {
            list.AddRange(u5);
            
            if (infusion is (Infusion.None or Infusion.Magic or Infusion.Divine or Infusion.Fire)) list.AddRange(u10);
            if (infusion == Infusion.None) list.AddRange(u15);
        }
        else if (upgradeType is (WeaponUpgradeType.ShieldDemon or WeaponUpgradeType.ShieldScales or WeaponUpgradeType.ShieldTwinkling))
        {
            list.AddRange(u5);
        }

        CBLevel.ItemsSource = list;
    }

    private void Btn_Confirm_OnClick(object sender, RoutedEventArgs e)
    {
        if (!_vm.NewItem) DialogResult = true;
        else DialogResult = _vm.AddWeapon();
        Close();
    }

    private void Btn_Close_OnClick(object sender, RoutedEventArgs e)
    {
        _vm.ResetChanges();
        DialogResult = false;
        Close();
    }

    private void CBInfusion_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CBInfusion.SelectedItem is not CBInfusionItem cbInfusionItem) return;
        if (_vm.Weapon.Infusion == cbInfusionItem.Infusion) return;
        
        _vm.Weapon.Infusion = cbInfusionItem.Infusion;
        _vm.Weapon.Level = 0;
        SetAvailableLevels();
    }

    private void CBLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CBLevel.SelectedItem is not CBLevelItem cbLevelItem) return;
        _vm.Weapon.Level = cbLevelItem.Level;
    }





    #region Helper Classes
    
    private class CBInfusionItem
    {
        public CBInfusionItem(Infusion infusion)
        {
            Infusion = infusion;
            InfusionName = infusion.ToString();
        }
        
        public Infusion Infusion { get; private set; }
        
        public string InfusionName { get; private set; }
    }
    
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