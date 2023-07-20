using System.Text.RegularExpressions;
using System.Windows;
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
        if (!uint.TryParse(TBAmount.Text, out var amount)) return;
        
        DialogResult = _vm.AddItem(amount);
        Close();
    }
    
    public void Btn_Close_OnClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
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

        var num = uint.Parse(TBAmount.Text + e.Text);
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