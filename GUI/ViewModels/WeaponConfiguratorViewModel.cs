using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;

namespace GUI.ViewModels;

public class WeaponConfiguratorViewModel
{
    private Inventory _inventory;
    private Weapon _weapon;
    private Weapon _originalWeapon;
    private bool _newItem;
    
    public WeaponConfiguratorViewModel(Inventory inventory, Weapon weapon, bool newItem)
    {
        _inventory = inventory;
        _weapon = weapon;
        _originalWeapon = new Weapon(weapon);
        _newItem = newItem;
    }

    public bool AddWeapon()
    {
        return _inventory.AddItem(_weapon);
    }

    public void ResetChanges()
    {
        _weapon.Infusion = _originalWeapon.Infusion;
        _weapon.Level = _originalWeapon.Level;
    }

    public Inventory Inventory => _inventory;

    public Weapon Weapon => _weapon;

    public bool NewItem => _newItem;
}