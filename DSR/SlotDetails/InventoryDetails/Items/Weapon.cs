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
        
        var weaponType = id / 100000;
        switch (weaponType)
        {
            case 1:
                _weaponType = WeaponType.Dagger;
                ImagePath += $"Weapons/Daggers/{Type}.png";
                break;
            case 2:
                _weaponType = WeaponType.StraightSword;
                ImagePath += $"Weapons/StraightSwords/{Type}.png";
                break;
            case 3:
                _weaponType = WeaponType.Greatsword;
                ImagePath += $"Weapons/Greatswords/{Type}.png";
                break;
            
            case 6:
                _weaponType = WeaponType.PiercingSword;
                ImagePath += $"Weapons/PiercingSwords/{Type}.png";
                break;
            case 7:
                _weaponType = WeaponType.Axe;
                ImagePath += $"Weapons/Axes/{Type}.png";
                break;
            case 8:
                _weaponType = WeaponType.Hammer;
                ImagePath += $"Weapons/Hammers/{Type}.png";
                break;
            case 9:
                _weaponType = WeaponType.FistWeapon;
                ImagePath += $"Weapons/FistWeapons/{Type}.png";
                break;
            case 10:
                _weaponType = WeaponType.Spear;
                ImagePath += $"Weapons/Spears/{Type}.png";
                break;
            
            case 13:
                _weaponType = WeaponType.Talisman;
                ImagePath += $"Weapons/Talismans/{Type}.png";
                break;
            case 14:
                _weaponType = WeaponType.StandardShield;
                ImagePath += $"Weapons/StandardShields/{Type}.png";
                break;
            
            case 20:
                _weaponType = WeaponType.Arrow;
                ImagePath += $"Weapons/Arrows/{Type}.png";
                break;
            case 21:
                _weaponType = WeaponType.Bolt;
                ImagePath += $"Weapons/Bolts/{Type}.png";
                break;
            
            default:
                throw new InvalidDataException($"Invalid Weapon ID: {id}");
            
        }
        _weaponType = weaponType switch
        {
            1 => WeaponType.Dagger,
            2 => WeaponType.StraightSword,
            3 => WeaponType.Greatsword,
            
            6 => WeaponType.PiercingSword,
            7 => WeaponType.Axe,
            8 => WeaponType.Hammer,
            9 => WeaponType.FistWeapon,
            10 => WeaponType.Spear,
            
            13 => WeaponType.Talisman,
            14 => WeaponType.StandardShield,
            
            20 => WeaponType.Arrow,
            21 => WeaponType.Bolt,
            _ => throw new InvalidDataException($"Invalid Weapon ID: {id}")
        };
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