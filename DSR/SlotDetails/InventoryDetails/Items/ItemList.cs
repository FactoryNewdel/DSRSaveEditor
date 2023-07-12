using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails.InventoryDetails.Items;

public class ItemList
{
    private static readonly List<Item> _items = new()
    {
        // Keys       64      2XXX
        new KeyItem(ItemType.CrestOfArtorias,        64, 2002, 0xFD6000, 0),
        new KeyItem(ItemType.DungeonCellKey,         64, 2010, 0xFD8000, 0),
        new KeyItem(ItemType.BigPilgrimsKey,         64, 2011, 0xFDE000, 0),
        new KeyItem(ItemType.UndeadAsylumF2EastKey,  64, 2012, 0xFDA000, 0),
        new KeyItem(ItemType.MasterKey,              64, 2100, 0xFD5000, 0),
        new KeyItem(ItemType.WeaponSmithBox,         64, 2600, 0xFCC000, 0),
        new KeyItem(ItemType.ArmorSmithBox,          64, 2601, 0xFCE000, 0),
        new KeyItem(ItemType.RepairBox,              64, 2602, 0xFCA000, 0),

        // Armor        16      XX0000 = Helm, XX1000 Chest, XX2000 Gauntlets, XX3000 Leggings
        // Empty Slots
        new Armor(ItemType.Helm    ,            16, 900000, 0, 0),
        new Armor(ItemType.Chest,               16, 901000, 0, 0),
        new Armor(ItemType.Gauntlets  ,         16, 902000, 0, 0),
        new Armor(ItemType.Leggings     ,       16, 903000, 0, 0),
        
        new Armor(ItemType.StandardHelm,        16, 210000, 0x64000, 250),
        new Armor(ItemType.StandardArmor,       16, 211000, 0xC8000, 250),
        new Armor(ItemType.StandardGauntlets,   16, 212000, 0x12C000, 250),
        new Armor(ItemType.StandardLeggings,    16, 213000, 0x190000, 250),
        
        new Armor(ItemType.KnightHelm,          16, 390000, 0x384000, 400),
        new Armor(ItemType.KnightArmor,         16, 391000, 0x3E8000, 400),
        new Armor(ItemType.KnightGauntlets,     16, 392000, 0x44C000, 400),
        new Armor(ItemType.KnightLeggings,      16, 393000, 0x4B0000, 400),
        
        // Weapons      0       XXXNXX Infusion, XXXXNN Level
        // Empty Slots
        new Weapon(ItemType.Fists,    0, 900000, 0x2AB98000, 5),

        // Daggers          01XXXXX
        // Straight Swords  02XXXXX
        new Weapon(ItemType.Longsword        , 0, 201000, 0x2B5C000, 200),
        new Weapon(ItemType.Broadsword       , 0, 202000, 0x2F44000, 200),
        new Weapon(ItemType.StraightSwordHilt, 0, 212000, 0x5654000, 200),
        // Greatswords      03XXXXX
        new Weapon(ItemType.BastardSword     , 0, 300000, 0x7594000, 200),
        new Weapon(ItemType.Greatsword       , 0, 351000, 0xC3B4000, 200),
        // Piercing Swords  06XXXXX
        new Weapon(ItemType.Estoc            , 0, 602000, 0x167C4000, 150),
        // Axes             07XXXXX
        new Weapon(ItemType.BattleAxe        , 0, 701000, 0x18AEC000, 250),
        // Hammers          08XXXXX
        new Weapon(ItemType.MorningStar      , 0, 802000, 0x1E0DC000, 180),
        new Weapon(ItemType.Warpick          , 0, 803000, 0x1E4C4000, 220),
        // Fist Weapons     09XXXXX
        new Weapon(ItemType.Caestus          , 0, 901000, 0x2ABFC000, 300),
        // Spears           10XXXXX
        new Weapon(ItemType.WingedSpear      , 0, 1001000, 0x2272C000, 140),
        new Weapon(ItemType.Pike             , 0, 1050000, 0x232E4000, 180),
        
        // Talismans        13XXXXX
        new Weapon(ItemType.Talisman          , 0, 1360000, 0x321F4000, 50),
        
        // Shields
        // Standard Shields 14XXXXX
        new Weapon(ItemType.LargeLeatherShield, 0, 1402000, 0x38AA4000, 200),
        new Weapon(ItemType.HeaterShield      , 0, 1450000, 0x38E8C000, 250),
        new Weapon(ItemType.TowerKiteShield   , 0, 1452000, 0x39274000, 250),
        new Weapon(ItemType.CaduceusKiteShield, 0, 1477000, 0x3965C000, 250),

        // Ammunition
        // Arrows           20XXXXX
        new Weapon(ItemType.StandardArrow, 0, 2000000, 0x7A1E8000, 0),
        new Weapon(ItemType.LargeArrow,    0, 2001000, 0x7A24C000, 0),
        new Weapon(ItemType.WoodenArrow,   0, 2006000, 0x7A184000, 0),
        // Bolts            21XXXXX
        new Weapon(ItemType.StandardBolt,  0, 2100000, 0x7B570000, 0),
        new Weapon(ItemType.HeavyBolt,     0, 2101000, 0x7B5D4000, 0),
        new Weapon(ItemType.WoodBolt,      0, 2103000, 0x7B50C000, 0),
        
        // Rings        32      
        new Ring(ItemType.HavelsRing,   32,     100,     0x3000, 0),

        // Items
        new CommonItem(ItemType.BlackSeparationCrystal, 64, 103, 0x1F000, 0),
        new CommonItem(ItemType.CrackedRedEyeOrb      , 64, 111, 0x16000, 0),
        new CommonItem(ItemType.Darksign              , 64, 117, 0x6E000, 0),
        new CommonItem(ItemType.FullEstusFlask        , 64, 201, 0x2000, 0),
        new CommonItem(ItemType.DivineBlessing        , 64, 240, 0x2B000, 0),
        new CommonItem(ItemType.LloydsTalisman        , 64, 296, 0x35000, 0),
        new CommonItem(ItemType.TransientCurse        , 64, 312, 0x37000, 0),
        new CommonItem(ItemType.HomewardBone          , 64, 330, 0x38000, 0),
        // Souls 4XX
        new CommonSoul(ItemType.SoulOfALostUndead          , 64, 400, 0x41000, 0),
        new CommonSoul(ItemType.LargeSoulOfANamelessSoldier, 64, 403, 0x44000, 0),
        
        new CommonItem(ItemType.Humanity              , 64, 500, 0x65000, 0),
        
        // Upgrade Materials 1XXX
        new UpgradeMaterial(ItemType.TitaniteShard         , 64, 1000, 0x3E9000, 0),
        new UpgradeMaterial(ItemType.TitaniteChunk         , 64, 1030, 0x3EB000, 0),
        new UpgradeMaterial(ItemType.TwinklingTitanite     , 64, 1130, 0x3F4000, 0),
        
        // Spells   3XXX
        new Spell(ItemType.SoulArrow             , 64, 3000, 0xBB9000, 0),
        new Spell(ItemType.HeavySoulArrow        , 64, 3020, 0xBBB000, 0),
        
        
    };

    public static Item? GetItem(UInt32 idSpace, UInt32 id)
    {
        foreach (var item in _items)
        {
            if (item.IdSpace == idSpace && item.ID == id) return new Item(item);
        }

        return null;
    }
    
    public static Item? GetItem(ItemType type)
    {
        foreach (var item in _items)
        {
            if (item.Type == type) return new Item(item);
        }

        return null;
    }

    public static List<Item> GetItems(Type type)
    {
        var list = new List<Item>();

        foreach (var item in _items)
        {
            if (item.GetType() == type) list.Add(item);
        }

        return list;
    }
}