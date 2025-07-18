﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using GUI.ViewModels;

namespace GUI.Views;

public partial class AddItemView : Window
{
    private AddItemViewModel _vm;
    private Item? _itemInInventory;
    
    public AddItemView(Inventory inventory, Item item)
    {
        InitializeComponent();

        inventory.TryGetItem(item.Type, out _itemInInventory);
        _vm = new AddItemViewModel(inventory, item);
        MainGrid.DataContext = _vm;
        TBAmount.Focus();
    }

    public void Btn_Confirm_OnClick(object sender, RoutedEventArgs e)
    {
        Confirm();
    }

    public void Btn_Close_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    public void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Return) return;
        
        e.Handled = true;
        Confirm();
    }

    private void Confirm()
    {
        if (!uint.TryParse(TBAmount.Text, out var amount)) return;

        DialogResult = _vm.AddItem(amount);
        Close();
    }
    
    private static readonly Regex _regexNumber = new Regex("[0-9]+");
    private void Textbox_PreviewNumberOnly(object sender, TextCompositionEventArgs e)
    {
        if (!_regexNumber.IsMatch(e.Text))
        {
            e.Handled = true;
            return;
        }

        if (!uint.TryParse(TBAmount.Text + e.Text, out var num))
        {
            e.Handled = true;
            return;
        }
        
        if (_itemInInventory == null) {
            if (num > _vm.Item.MaxAmount)
            {
                TBAmount.Text = "" + _vm.Item.MaxAmount;
                e.Handled = true;
                return;
            }
        } else if (num > _vm.Item.MaxAmount - _itemInInventory.Amount)
        {
            TBAmount.Text = "" + (_vm.Item.MaxAmount - _itemInInventory.Amount);
            e.Handled = true;
            return;
        }

        e.Handled = false;
    }
}