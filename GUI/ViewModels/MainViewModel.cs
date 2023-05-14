using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using DSR.SavefileStructure;
using DSR.SlotDetails;

namespace GUI.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private SaveFile _saveFile;
    private ObservableCollection<SaveSlotDetails> _saveSlotDetails;

    public MainViewModel()
    {
        _saveSlotDetails = new ObservableCollection<SaveSlotDetails>();
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


    public ObservableCollection<SaveSlotDetails> SaveSlotDetails => _saveSlotDetails;

    

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}