using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DSR.SlotDetails;
using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using GUI.ViewModels;

namespace GUI.Views;

public partial class EstusConfiguratorView : Window
{
    private EstusConfiguratorViewModel _vm;
    
    public EstusConfiguratorView(EstusFlask estus)
    {
        InitializeComponent();

        _vm = new EstusConfiguratorViewModel(estus);
        MainGrid.DataContext = _vm;
        
        SetAvailableAmount();
        SetAvailableStrength();

        foreach (var item in CBAmount.ItemsSource)
        {
            var diff = (int)(item as CBAmountItem).Amount - (int)estus.Amount;
            if (diff < 0 || diff > 5) continue;

            CBAmount.SelectedItem = item;
            break;
        }
        
        foreach (var item in CBStrength.ItemsSource)
        {
            if ((item as CBStrengthItem).Strength != estus.Strength) continue;

            CBStrength.SelectedItem = item;
            break;
        }
    }

    private void SetAvailableAmount()
    {
        CBAmount.ItemsSource = new List<CBAmountItem>
        {
            new (0),
            new (5),
            new (10),
            new (15),
            new (20),
        };
    }
    
    private void SetAvailableStrength()
    {
        CBStrength.ItemsSource = new List<CBStrengthItem>
        {
            new (0),
            new (1),
            new (2),
            new (3),
            new (4),
            new (5),
            new (6),
            new (7),
        };
    }

    private void Btn_Confirm_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void Btn_Close_OnClick(object sender, RoutedEventArgs e)
    {
        _vm.ResetChanges();
        DialogResult = false;
        Close();
    }

    private void CBAmount_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CBAmount.SelectedItem is not CBAmountItem cbAmountItem) return;
        _vm.Estus.Amount = cbAmountItem.Amount;
        _vm.Estus.Empty = _vm.Estus.Amount == 0;
    }
    
    private void CBStrength_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CBStrength.SelectedItem is not CBStrengthItem cbLevelItem) return;
        _vm.Estus.Strength = cbLevelItem.Strength;
    }
    



    #region Helper Classes

    private class CBAmountItem
    {
        public CBAmountItem(uint amount)
        {
            Amount = amount;
        }
        
        public uint Amount { get; private set; }
    }
    
    private class CBStrengthItem
    {
        public CBStrengthItem(uint strength)
        {
            Strength = strength;
        }
        
        public uint Strength { get; private set; }
    }
    
    #endregion
}