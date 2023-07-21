namespace DSR.SlotDetails.InventoryDetails.Items;

public class Weapon : Item
{
    private WeaponType _weaponType;
    private Infusion _infusion;
    private string _infusionImagePath;
    private int _level;
    
    public Weapon(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base(idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        GetWeaponDetails();
    }

    public Weapon(ItemType type, byte idSpace, uint id, uint sorting, uint durability) : base(type, idSpace, id, sorting, durability)
    {
        GetWeaponDetails();
    }

    public Weapon(Weapon weapon) : base(weapon)
    {
        _infusion = weapon._infusion;
        _level = weapon._level;
        _weaponType = weapon._weaponType;
    }

    private void GetWeaponDetails()
    {
        var id = ID;
        ID = ID / 1000 * 1000;
        _infusion = (Infusion)((id - ID) / 100);
        
        SetInfusionImagePath();
        _level = (int)(id - ID - (int)_infusion * 100);
        
        var weaponTypeNum = id / 100000;
        if (!Enum.IsDefined(typeof(WeaponType), (int)weaponTypeNum)) throw new InvalidDataException($"Invalid WeaponType: {weaponTypeNum}; ID: {id}");
        _weaponType = (WeaponType)weaponTypeNum;
        if (_weaponType == WeaponType.GreatSword && id / 10000 == 35) _weaponType = WeaponType.UltraGreatsword;
        if (_weaponType == WeaponType.CurvedSword && id / 10000 == 45) _weaponType = WeaponType.CurvedGreatsword;
        if (_weaponType == WeaponType.Axe && id / 10000 == 75) _weaponType = WeaponType.GreatAxe;
        if (_weaponType == WeaponType.Hammer && id / 10000 == 85) _weaponType = WeaponType.GreatHammer;
        if (_weaponType == WeaponType.Bow && id / 10000 == 125) _weaponType = WeaponType.Crossbow;
        
        ImagePath += $"Weapons/{_weaponType}s/{Type}.png";
    }

    private void SetInfusionImagePath()
    {
        var basePath = "Images/InfusionIcons/";
        _infusionImagePath = _infusion switch
        {
            Infusion.None      => basePath + "",
            Infusion.Crystal   => basePath + "Crystal.png",
            Infusion.Lightning => basePath + "Lightning.png",
            Infusion.Raw       => basePath + "Raw.png",
            Infusion.Magic     => basePath + "Magic.png",
            Infusion.Enchanted => basePath + "Enchanted.png",
            Infusion.Divine    => basePath + "Divine.png",
            Infusion.Occult    => basePath + "Occult.png",
            Infusion.Fire      => basePath + "Fire.png",
            Infusion.Chaos     => basePath + "Chaos.png",
        };
    }
    
    public override uint FullID => (uint)(ID + (int)_infusion * 100 + Level);

    public WeaponType WeaponType
    {
        get => _weaponType;
        set => _weaponType = value;
    }

    public Infusion Infusion
    {
        get => _infusion;
        set => _infusion = value;
    }

    public string InfusionImagePath => _infusionImagePath;

    public int Level
    {
        get => _level;
        set => _level = value;
    }
}