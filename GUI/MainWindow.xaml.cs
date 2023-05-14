using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using DSR.Utils;
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
        
        public MainWindow()
        {
            InitializeComponent();
            
            _mainViewModel = new MainViewModel();

            Slots.ItemsSource = _mainViewModel.SaveSlotDetails;
        }

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
    }
}