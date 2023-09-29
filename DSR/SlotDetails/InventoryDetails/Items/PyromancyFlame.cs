namespace DSR.SlotDetails.InventoryDetails.Items;

public class PyromancyFlame : Weapon
{
    private bool _ascended = false;
    
    public PyromancyFlame(uint id, uint index) : base(0, 1330000, 1, 0x3195C0, index, true, 30, 0)
    {
        Level = (id - (id / 10000 * 10000)) / 100;
        if (Level > 20)
        {
            Infusion = Infusion.Ascended;
            _ascended = true;
            Level -= 20;
        }
    }

    public PyromancyFlame() : base(ItemType.PyromancyFlame, 0, 1330000, 0x3195C0, 30, WeaponUpgradeType.Souls)
    {
        Level = 0;
        _ascended = false;
    }

    public PyromancyFlame(PyromancyFlame pyromancyFlame) : base(pyromancyFlame)
    {
        Level = pyromancyFlame.Level;
        _ascended = pyromancyFlame._ascended;
        Infusion = pyromancyFlame.Infusion;
    }

    public override uint FullID => (uint)(ID + (_ascended ? 2000 : 0) + Level * 100);

    public bool Ascended
    {
        get => _ascended;
        set => _ascended = value;
    }
}