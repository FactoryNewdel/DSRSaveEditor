using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace GUI.Helper;

public class InventoryImageContainer : INotifyPropertyChanged
{
    private string _imagePathUnselected;
    private string _imagePathSelected;
    private string _imagePathCurrentlyActive;
    private bool _selected;
    private SolidColorBrush _borderBrush;
    
    private static readonly SolidColorBrush BorderBrushUnselected = new (Color.FromRgb(0x66, 0x66, 0x66));
    private static readonly SolidColorBrush BorderBrushSelected = Brushes.SaddleBrown;

    public InventoryImageContainer(string imagePathUnselected, string imagePathSelected)
    {
        _imagePathUnselected = imagePathUnselected;
        _imagePathSelected = imagePathSelected;
        _imagePathCurrentlyActive = _imagePathUnselected;
        _selected = false;
        _borderBrush = BorderBrushUnselected;
    }

    public string ImagePath
    {
        get => _imagePathCurrentlyActive;
        private set
        {
            _imagePathCurrentlyActive = value ?? throw new ArgumentNullException(nameof(value));
            NotifyPropertyChanged();
        }
    }

    public SolidColorBrush BorderBrush
    {
        get => _borderBrush;
        private set
        {
            _borderBrush = value;
            NotifyPropertyChanged();
        }
    }
    


    public bool Selected
    {
        get => _selected;
        set
        {
            _selected = value;
            ImagePath = _selected ? _imagePathSelected : _imagePathUnselected;
            BorderBrush = _selected ? BorderBrushSelected : BorderBrushUnselected;
            NotifyPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}