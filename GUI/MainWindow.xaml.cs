using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DSR.SlotDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using DSR.Utils;
using GUI.Helper;
using GUI.ViewModels;
using Microsoft.Win32;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;
        private InventoryImageContainer _defaultInventoryTab;
        
        public MainWindow()
        {
            InitializeComponent();

            _mainViewModel = new MainViewModel();

            Slots.ItemsSource = _mainViewModel.SaveSlotDetails;
            TabCharacterStats.DataContext = _mainViewModel;

            _defaultInventoryTab = new InventoryImageContainer("Images/InventoryIcons/InventoryTab_Consumables_Unselected.png", "Images/InventoryIcons/InventoryTab_Consumables_Selected.png");
            ImageConsumables.DataContext = _defaultInventoryTab;
            ImageUpgradeMaterials.DataContext = new InventoryImageContainer("Images/InventoryIcons/InventoryTab_UpgradeMaterials_Unselected.png", "Images/InventoryIcons/InventoryTab_UpgradeMaterials_Selected.png");
            ImageKeyItems.DataContext =         new InventoryImageContainer("Images/InventoryIcons/InventoryTab_KeyItems_Unselected.png",         "Images/InventoryIcons/InventoryTab_KeyItems_Selected.png");
            ImageSpells.DataContext =           new InventoryImageContainer("Images/InventoryIcons/InventoryTab_Spells_Unselected.png",           "Images/InventoryIcons/InventoryTab_Spells_Selected.png");
            ImageWeapons.DataContext =          new InventoryImageContainer("Images/InventoryIcons/InventoryTab_Weapons_Unselected.png",          "Images/InventoryIcons/InventoryTab_Weapons_Selected.png");
            ImageAmmunition.DataContext =       new InventoryImageContainer("Images/InventoryIcons/InventoryTab_Ammunition_Unselected.png",       "Images/InventoryIcons/InventoryTab_Ammunition_Selected.png");
            ImageArmor.DataContext =            new InventoryImageContainer("Images/InventoryIcons/InventoryTab_Armor_Unselected.png",            "Images/InventoryIcons/InventoryTab_Armor_Selected.png");
            ImageRings.DataContext =            new InventoryImageContainer("Images/InventoryIcons/InventoryTab_Rings_Unselected.png",            "Images/InventoryIcons/InventoryTab_Rings_Selected.png");

            listViewInventory.ItemsSource = _mainViewModel.SelectedInventoryItems;
            treeItems.ItemsSource = _mainViewModel.SelectedTree;
        }

        #region MainTab
        
        private void Import_Clicked(object sender, RoutedEventArgs e)
        {
            DetailComparer.Init(0x5FFFC);
            
            var dialog = new OpenFileDialog();
            dialog.Filter = "Dark Souls Remastered Savefile (DRAKS0005.sl2)|DRAKS0005.sl2";
            if (dialog.ShowDialog() != true) return;
            if (!File.Exists(dialog.FileName))
            {
                MessageBox.Show($"File does not exist {dialog.FileName}");
                return;
            }

            try
            {
                _mainViewModel.ImportSavefile(dialog.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Import failed!\nSavefile might be invalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            (Tabs.Items[1] as TabItem).IsEnabled = true;
            Tabs.SelectedIndex = 1;
        }
        
        private void Export_Clicked(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Dark Souls Savefile (.sl2)|*.sl2";
            if (dialog.ShowDialog() != true) return;
            
            if (File.Exists(dialog.FileName) && MessageBox.Show($"File already exists!\nDo you want to replace it", "Replace", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes) return;

            _mainViewModel.ExportSavefile(dialog.FileName);
        }
        
        #endregion
        
        #region SlotTab

        private void Slot_DoubleClick(object sender, RoutedEventArgs e)
        {
            var lbItem = sender as ListBoxItem;
            if (lbItem?.DataContext == null) return;
            
            var slot = lbItem.DataContext as SaveSlotDetails;
            if (slot == null) return;
            
            _mainViewModel.SelectedSlot = slot;
            
            (Tabs.Items[2] as TabItem).IsEnabled = true;
            Tabs.SelectedIndex = 2;
            (Tabs.Items[3] as TabItem).IsEnabled = true;
            
            _mainViewModel.SetDefaultInventoryItem(_defaultInventoryTab);
        }
        
        #endregion
        
        #region InventoryTab

        private void InventoryImage_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Image image) return;
            if (image.DataContext is not InventoryImageContainer inventoryImageContainer) return;
            if (inventoryImageContainer.Selected) return;

            _mainViewModel.SelectedInventoryTab = inventoryImageContainer;
        }

        private void TreeItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ContentControl cc) return;
            if (cc.DataContext is not Item item) return;
            
            _mainViewModel.AddItem(item);
            Keyboard.ClearFocus();
        }
        
        private void TreeItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return) return;
            if (sender is not TreeViewItem treeViewItem) return;
            if (treeViewItem.DataContext is not Item item) return;
            
            Keyboard.ClearFocus();
            _mainViewModel.AddItem(item);
            Keyboard.ClearFocus();
        }


        #endregion

        private static readonly Regex _regexNumber = new Regex("[0-9]+");
        private void Textbox_PreviewNumberOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !_regexNumber.IsMatch(e.Text);
        }
    }
}