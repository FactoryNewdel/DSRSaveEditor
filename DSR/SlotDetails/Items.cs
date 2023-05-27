using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails;

public class Items
{
    private static readonly List<Item> _items = new()
    {
        // Keys       64      2XXX
        new Item(ItemType.CrestOfArtorias,        64, 2002, 0xFD6000, 0),
        new Item(ItemType.DungeonCellKey,         64, 2010, 0xFD8000, 0),
        new Item(ItemType.BigPilgrimsKey,         64, 2011, 0xFDE000, 0),
        new Item(ItemType.UndeadAsylumF2EastKey,  64, 2012, 0xFDA000, 0),
        new Item(ItemType.MasterKey,              64, 2100, 0xFD5000, 0),
        new Item(ItemType.WeaponSmithBox,         64, 2600, 0xFCC000, 0),
        new Item(ItemType.ArmorSmithBox,          64, 2601, 0xFCE000, 0),
        new Item(ItemType.RepairBox,              64, 2602, 0xFCA000, 0),

        // Armor        16      XX0000 = Helm, XX1000 Chest, XX2000 Gauntlets, XX3000 Leggings
        // Empty Slots
        new Item(ItemType.Helm    ,    16, 900000, 0, 0),
        new Item(ItemType.Chest,    16, 901000, 0, 0),
        new Item(ItemType.Gauntlets  ,    16, 902000, 0, 0),
        new Item(ItemType.Leggings     ,    16, 903000, 0, 0),
        
        new Item(ItemType.StandardHelm,     16, 210000, 0x64000, 250),
        new Item(ItemType.StandardArmor, 16, 211000, 0xC8000, 250),
        new Item(ItemType.StandardGauntlets,   16, 212000, 0x12C000, 250),
        new Item(ItemType.StandardLeggings,      16, 213000, 0x190000, 250),
        
        new Item(ItemType.KnightHelm,     16, 390000, 0x384000, 400),
        new Item(ItemType.KnightArmor, 16, 391000, 0x3E8000, 400),
        new Item(ItemType.KnightGauntlets,   16, 392000, 0x44C000, 400),
        new Item(ItemType.KnightLeggings,      16, 393000, 0x4B0000, 400),
        
        // Weapons      0       XXXNXX Infusion, XXXXNN Level
        // Empty Slots
        new Item(ItemType.Fists,    0, 900000, 0x2AB98000, 5),

        // Daggers          02XXXXX
        // Straight Swords
        new Item(ItemType.Longsword        , 0, 201000, 0x2B5C000, 200),
        new Item(ItemType.Broadsword       , 0, 202000, 0x2F44000, 200),
        new Item(ItemType.StraightSwordHilt, 0, 212000, 0x5654000, 200),
        // Greatswords      03XXXXX
        new Item(ItemType.BastardSword     , 0, 300000, 0x7594000, 200),
        new Item(ItemType.Greatsword       , 0, 351000, 0xC3B4000, 200),
        // Piercing Swords  06XXXXX
        new Item(ItemType.Estoc            , 0, 602000, 0x167C4000, 150),
        // Axes             07XXXXX
        new Item(ItemType.BattleAxe        , 0, 701000, 0x18AEC000, 250),
        // Hammers          08XXXXX
        new Item(ItemType.MorningStar      , 0, 802000, 0x1E0DC000, 180),
        new Item(ItemType.Warpick          , 0, 803000, 0x1E4C4000, 220),
        // Fist Weapons     09XXXXX
        new Item(ItemType.Caestus          , 0, 901000, 0x2ABFC000, 300),
        // Spears           10XXXXX
        new Item(ItemType.WingedSpear      , 0, 1001000, 0x2272C000, 140),
        new Item(ItemType.Pike             , 0, 1050000, 0x232E4000, 180),
        
        // Talismans        13XXXXX
        new Item(ItemType.Talisman          , 0, 1360000, 0x321F4000, 50),
        
        // Shields
        // Standard Shields 14XXXXX
        new Item(ItemType.LargeLeatherShield, 0, 1402000, 0x38AA4000, 200),
        new Item(ItemType.HeaterShield      , 0, 1450000, 0x38E8C000, 250),
        new Item(ItemType.TowerKiteShield   , 0, 1452000, 0x39274000, 250),
        new Item(ItemType.CaduceusKiteShield, 0, 1477000, 0x3965C000, 250),

        // Ammunition
        // Arrows           20XXXXX
        new Item(ItemType.StandardArrow, 0, 2000000, 0x7A1E8000, 0),
        new Item(ItemType.LargeArrow, 0, 2001000, 0x7A24C000, 0),
        new Item(ItemType.WoodenArrow, 0, 2006000, 0x7A184000, 0),
        // Bolts            21XXXXX
        new Item(ItemType.StandardBolt    , 0, 2100000, 0x7B570000, 0),
        new Item(ItemType.HeavyBolt    , 0, 2101000, 0x7B5D4000, 0),
        new Item(ItemType.WoodBolt, 0, 2103000, 0x7B50C000, 0),
        
        // Rings        32      
        new Item(ItemType.HavelsRing, 32, 100, 0x3000, 0),

        // Items
        new Item(ItemType.BlackSeparationCrystal, 64, 103, 0x1F000, 0),
        new Item(ItemType.CrackedRedEyeOrb      , 64, 111, 0x16000, 0),
        new Item(ItemType.Darksign              , 64, 117, 0x6E000, 0),
        new Item(ItemType.FullEstusFlask        , 64, 201, 0x2000, 0),
        new Item(ItemType.DivineBlessing        , 64, 240, 0x2B000, 0),
        new Item(ItemType.LLoydsTalisman        , 64, 296, 0x35000, 0),
        new Item(ItemType.TransientCurse        , 64, 312, 0x37000, 0),
        new Item(ItemType.HomewardBone          , 64, 330, 0x38000, 0),
        // Souls 4XX
        new Item(ItemType.SoulOfALostUndead          , 64, 400, 0x41000, 0),
        new Item(ItemType.LargeSoulOfANamelessSoldier, 64, 403, 0x44000, 0),
        
        new Item(ItemType.Humanity              , 64, 500, 0x65000, 0),
        
        // Upgrade Materials 1XXX
        new Item(ItemType.TitaniteShard         , 64, 1000, 0x3E9000, 0),
        new Item(ItemType.TitaniteChunk         , 64, 1030, 0x3EB000, 0),
        new Item(ItemType.TwinklingTitanite     , 64, 1130, 0x3F4000, 0),
        
        // Spells   3XXX
        new Item(ItemType.SoulArrow             , 64, 3000, 0xBB9000, 0),
        new Item(ItemType.HeavySoulArrow        , 64, 3020, 0xBBB000, 0),
        
        
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
    
    
}