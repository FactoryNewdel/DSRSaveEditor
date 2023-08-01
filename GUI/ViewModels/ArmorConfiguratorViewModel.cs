using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;

namespace GUI.ViewModels;

public class ArmorConfiguratorViewModel
{
    private Inventory _inventory;
    private Armor _armor;
    private Armor _originalArmor;
    private bool _newItem;
    
    public ArmorConfiguratorViewModel(Inventory inventory, Armor armor, bool newItem)
    {
        _inventory = inventory;
        _armor = armor;
        _originalArmor = new Armor(armor);
        _newItem = newItem;
    }

    public bool AddArmor()
    {
        return _inventory.AddItem(_armor);
    }

    public void ResetChanges()
    {
        _armor.Level = _originalArmor.Level;
    }

    public Inventory Inventory => _inventory;

    public Armor Armor => _armor;

    public bool NewItem => _newItem;
}