using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DSR.SlotDetails;
using DSR.SlotDetails.Character;
using DSR.SlotDetails.InventoryDetails.Items;
using DSR.Utils;
using GUI.Helper;
using GUI.ViewModels;
using Microsoft.Win32;

namespace GUI
{
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;
        private InventoryImageContainer _defaultInventoryTab;
        private UInt32 _hpMaxBackup;
        private UInt32 _staminaMaxBackup;

        public MainWindow()
        {
            InitializeComponent();

            _mainViewModel = new MainViewModel();

            Slots.ItemsSource = _mainViewModel.SaveSlotDetails;
            TabCharacterStats.DataContext = _mainViewModel;

            _defaultInventoryTab =              new InventoryImageContainer("Images/InventoryIcons/InventoryTab_Consumables_Unselected.png",      "Images/InventoryIcons/InventoryTab_Consumables_Selected.png");
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
            dialog.Filter = "Dark Souls Remastered Savefile (*.sl2)|*.sl2";
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
            catch (Exception ex)
            {
                MessageBox.Show($"Import failed!\nSavefile might be invalid\nError: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

            try
            {
                _mainViewModel.ExportSavefile(dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save file could not be exported!\nError: {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Save file has been exported!");
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

            if (_mainViewModel.SelectedInventoryTab != null) _mainViewModel.SelectedInventoryTab.Selected = false;

            _mainViewModel.SetDefaultInventoryItem(_defaultInventoryTab);

            Btn_Stats_Discard(null, null);
            _hpMaxBackup = _mainViewModel.SelectedSlot.CharacterStats.HPTotalUnmodified;
            _staminaMaxBackup = _mainViewModel.SelectedSlot.CharacterStats.StaminaTotalUnmodified;
        }

        private void Btn_HP_Discard(object sender, RoutedEventArgs e)
        {
            SliderHPMax.Value = _hpMaxBackup;
        }

        private void Btn_Stamina_Discard(object sender, RoutedEventArgs e)
        {
            SliderStaminaMax.Value = _staminaMaxBackup;
        }

        private void Btn_Stats_Discard(object sender, RoutedEventArgs e)
        {
            TbVit.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Vitality;
            TbAtt.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Attunement;
            TbEnd.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Endurance;
            TbStr.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Strength;
            TbDex.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Dexterity;
            TbRes.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Resistance;
            TbInt.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Intelligence;
            TbFth.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Faith;
            TbHumanity.Text = "" + _mainViewModel.SelectedSlot.CharacterStats.Humanity;
        }

        private void Btn_Stats_Save(object sender, RoutedEventArgs e)
        {
            uint vit;
            if (!uint.TryParse(TbVit.Text, out vit)) vit = 1;
            uint att;
            if (!uint.TryParse(TbAtt.Text, out att)) att = 1;
            uint end;
            if (!uint.TryParse(TbEnd.Text, out end)) end = 1;
            uint str;
            if (!uint.TryParse(TbStr.Text, out str)) str = 1;
            uint dex;
            if (!uint.TryParse(TbDex.Text, out dex)) dex = 1;
            uint res;
            if (!uint.TryParse(TbRes.Text, out res)) res = 1;
            uint intell;
            if (!uint.TryParse(TbInt.Text, out intell)) intell = 1;
            uint fth;
            if (!uint.TryParse(TbFth.Text, out fth)) fth = 1;
            uint humanity;
            if (!uint.TryParse(TbHumanity.Text, out humanity)) humanity = 1;

            if (vit < _mainViewModel.SelectedSlot.CharacterStats.VitalityMin)
            {
                vit = _mainViewModel.SelectedSlot.CharacterStats.VitalityMin;
                TbVit.Text = "" + vit;
            }

            if (att < _mainViewModel.SelectedSlot.CharacterStats.AttunementMin)
            {
                att = _mainViewModel.SelectedSlot.CharacterStats.AttunementMin;
                TbAtt.Text = "" + att;
            }

            if (end < _mainViewModel.SelectedSlot.CharacterStats.EnduranceMin)
            {
                end = _mainViewModel.SelectedSlot.CharacterStats.EnduranceMin;
                TbEnd.Text = "" + end;
            }

            if (str < _mainViewModel.SelectedSlot.CharacterStats.StrengthMin)
            {
                str = _mainViewModel.SelectedSlot.CharacterStats.StrengthMin;
                TbStr.Text = "" + str;
            }

            if (dex < _mainViewModel.SelectedSlot.CharacterStats.DexterityMin)
            {
                dex = _mainViewModel.SelectedSlot.CharacterStats.DexterityMin;
                TbDex.Text = "" + dex;
            }

            if (res < _mainViewModel.SelectedSlot.CharacterStats.ResistanceMin)
            {
                res = _mainViewModel.SelectedSlot.CharacterStats.ResistanceMin;
                TbRes.Text = "" + res;
            }

            if (intell < _mainViewModel.SelectedSlot.CharacterStats.IntelligenceMin)
            {
                intell = _mainViewModel.SelectedSlot.CharacterStats.IntelligenceMin;
                TbInt.Text = "" + intell;
            }

            if (fth < _mainViewModel.SelectedSlot.CharacterStats.FaithMin)
            {
                fth = _mainViewModel.SelectedSlot.CharacterStats.FaithMin;
                TbFth.Text = "" + fth;
            }

            _mainViewModel.SelectedSlot.CharacterStats.Vitality = vit;
            _mainViewModel.SelectedSlot.CharacterStats.Attunement = att;
            _mainViewModel.SelectedSlot.CharacterStats.Endurance = end;
            _mainViewModel.SelectedSlot.CharacterStats.Strength = str;
            _mainViewModel.SelectedSlot.CharacterStats.Dexterity = dex;
            _mainViewModel.SelectedSlot.CharacterStats.Resistance = res;
            _mainViewModel.SelectedSlot.CharacterStats.Intelligence = intell;
            _mainViewModel.SelectedSlot.CharacterStats.Faith = fth;
            _mainViewModel.SelectedSlot.CharacterStats.Humanity = humanity;

            _mainViewModel.SelectedSlot.CharacterStats.Level = _mainViewModel.SelectedSlot.CharacterStats.LevelMin
                + vit - _mainViewModel.SelectedSlot.CharacterStats.VitalityMin
                + att - _mainViewModel.SelectedSlot.CharacterStats.AttunementMin
                + end - _mainViewModel.SelectedSlot.CharacterStats.EnduranceMin
                + str - _mainViewModel.SelectedSlot.CharacterStats.StrengthMin
                + dex - _mainViewModel.SelectedSlot.CharacterStats.DexterityMin
                + res - _mainViewModel.SelectedSlot.CharacterStats.ResistanceMin
                + intell - _mainViewModel.SelectedSlot.CharacterStats.IntelligenceMin
                + fth - _mainViewModel.SelectedSlot.CharacterStats.FaithMin;
        }

        private void Image_MouseDown_Spell(object sender, MouseButtonEventArgs e)
        {
            _mainViewModel.SelectedSlot.Equipment.ChangeSpell();
        }

        private void Image_MouseDown_Left(object sender, MouseButtonEventArgs e)
        {
            _mainViewModel.SelectedSlot.Equipment.ChangeLeft();
        }

        private void Image_MouseDown_Right(object sender, MouseButtonEventArgs e)
        {
            _mainViewModel.SelectedSlot.Equipment.ChangeRight();
        }

        private void Image_MouseDown_Consumable(object sender, MouseButtonEventArgs e)
        {
            _mainViewModel.SelectedSlot.Equipment.ChangeConsumable();
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

        private void ListViewItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is not ListViewItem listViewItem) return;
            if (listViewItem.DataContext is not Item item) return;

            ListViewItem_Interact(item);
        }

        private void ListViewItem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is not ListViewItem listViewItem) return;
            if (listViewItem.DataContext is not Item item) return;

            if (e.Key == Key.Return) ListViewItem_Interact(item);
            else if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (listViewInventory.SelectedItems.Count == 1)
                {
                    ListViewItem_Delete(item);
                    return;
                }

                var items = new List<Item>();

                foreach (var selected in listViewInventory.SelectedItems)
                {
                    if (selected is not Item selectedItem) continue;
                    items.Add(selectedItem);
                }

                ListViewItem_Delete(items);
            }
        }

        private void ListViewItem_Interact(Item item)
        {
            _mainViewModel.ChangeItemAmount(item);
        }


        private void ListViewItem_DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.DataContext is not Item item) return;

            ListViewItem_Delete(item);
        }

        private void ListViewItem_Delete(Item item)
        {
            ListViewItem_Delete(new List<Item> { item });
        }

        private void ListViewItem_Delete(List<Item> items)
        {
            if (items.Count == 0) return;
            if (items.Count == 1)
            {
                var item = items[0];
                if (MessageBox.Show($"Are you sure you want to delete {item.Name}?", "Warning", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

                if (_mainViewModel.DeleteItem(item)) MessageBox.Show($"{item.Name} has been removed from the inventory!");
                else MessageBox.Show($"{item.Name} could not be removed from the inventory", "Error");

                return;
            }

            var sb = new StringBuilder();

            foreach (var item in items)
            {
                sb.Append(item.Name).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            if (MessageBox.Show($"Are you sure you want to delete those items?\n{sb}", "Warning", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;

            sb.Clear();
            var sbDeleted = new StringBuilder();
            var sbError = new StringBuilder();
            foreach (var item in items)
            {
                if (_mainViewModel.DeleteItem(item)) sbDeleted.Append(item.Name).Append(", ");
                else sbError.Append(item.Name).Append(", ");
            }

            if (sbDeleted.Length != 0)
            {
                sbDeleted.Remove(sbDeleted.Length - 2, 2);
                sb.AppendLine("Successfully deleted those items:").AppendLine(sbDeleted.ToString());
            }

            if (sbError.Length != 0)
            {
                sbError.Remove(sbError.Length - 2, 2);
                sb.AppendLine("Could not delete those items:").AppendLine(sbError.ToString());
            }

            MessageBox.Show(sb.ToString(), "Info");
        }


        private void TreeItem_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeItem_Interact(sender);
        }

        private void TreeItem_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return) return;
            TreeItem_Interact(sender);
        }

        private void TreeItem_Interact(object sender)
        {
            if (sender is not TreeViewItem treeViewItem) return;
            if (treeViewItem.DataContext is not Item item) return;

            if (_mainViewModel.AddItem(item)) MessageBox.Show($"Added {item.Name} x{item.Amount} to inventory!");
        }

        #endregion

        private static readonly Regex _regexNumber = new Regex("[0-9]+");

        private void Textbox_PreviewNumberOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !_regexNumber.IsMatch(e.Text);
        }

        private void Textbox_TextChanged_NumberOnly_Stats(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            var text = textbox.Text;
            var min = !textbox.Name.Equals(TbHumanity?.Name) ? 1 : 0;

            if (text.Length == 0) return;
            
            if (!uint.TryParse(text, out var num))
            {
                var changes = e.Changes.ToList();
                try
                {
                    for (var i = changes.Count - 1; i >= 0; i--)
                    {
                        var change = changes[i];
                        text = text.Remove(change.Offset, change.AddedLength);
                    }

                    if (text.Length == 0) text = $"{min}";
                }
                catch (Exception)
                {
                    text = $"{min}";
                }

                textbox.Text = text;

                e.Handled = true;
                return;
            }

            if (num > 99)
            {
                e.Handled = true;
                textbox.Text = "99";
                return;
            }

            if (num < min)
            {
                e.Handled = true;
                textbox.Text = $"{min}";
                return;
            }
        }
    }
}