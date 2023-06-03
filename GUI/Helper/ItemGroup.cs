using System.Collections.Generic;
using DSR.SlotDetails.InventoryDetails.Items;

namespace GUI.Helper;

public class ItemGroup
{
    private string _imagePath;
    private string _title;
    private List<Item> _items;

    public ItemGroup(string imagePath, string title, List<Item> items)
    {
        _imagePath = imagePath;
        _title = title;
        _items = items;
    }

    public string ImagePath => _imagePath;

    public string Title => _title;

    public List<Item> Items => _items;
}