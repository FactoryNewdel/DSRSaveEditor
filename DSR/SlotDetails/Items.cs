using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails;

public class Items
{
    private static readonly List<Item> _items = new()
    {
        // Keys
        new Item(ItemType.CrestOfArtorias,        64, 2002, 0xFD6000, 0),
        new Item(ItemType.DungeonCellKey,         64, 2010, 0xFD8000, 0),
        new Item(ItemType.BigPilgrimsKey,         64, 2011, 0xFDE000, 0),
        new Item(ItemType.UndeadAsylumF2EastKey,  64, 2012, 0xFDA000, 0),
        new Item(ItemType.MasterKey,              64, 2100, 0xFD5000, 0),
        new Item(ItemType.WeaponSmithBox,         64, 2600, 0xFCC000, 0),
        new Item(ItemType.ArmorSmithBox,          64, 2601, 0xFCE000, 0),
        new Item(ItemType.RepairBox,              64, 2602, 0xFCA000, 0),

        // Armor
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
        
        // Weapons
        // Empty Slots
        new Item(ItemType.Fists,    0, 900000, 0x2AB98000, 5),

        // Daggers
        // Straight Swords
        new Item(ItemType.Longsword        , 0, 201000, 0x2B5C000, 200),
        new Item(ItemType.Broadsword       , 0, 202000, 0x2F44000, 200),
        new Item(ItemType.StraightSwordHilt, 0, 212000, 0x5654000, 200),
        // Greatswords
        new Item(ItemType.BastardSword     , 0, 300000, 0x7594000, 200),
        new Item(ItemType.Greatsword       , 0, 351000, 0xC3B4000, 200),
        // Piercing Swords
        new Item(ItemType.Estoc            , 0, 602000, 0x167C4000, 150),
        // Axes
        new Item(ItemType.BattleAxe        , 0, 701000, 0x18AEC000, 250),
        // Hammers
        new Item(ItemType.MorningStar      , 0, 802000, 0x1E0DC000, 180),
        new Item(ItemType.Warpick          , 0, 803000, 0x1E4C4000, 220),
        // 
        new Item(ItemType.Caestus          , 0, 901000, 0x2ABFC000, 300),
        // Spears
        new Item(ItemType.WingedSpear      , 0, 1001000, 0x2272C000, 140),
        new Item(ItemType.Pike             , 0, 1050000, 0x232E4000, 180),
        
        // Talismans
        new Item(ItemType.Talisman          , 0, 1360000, 0x321F4000, 50),
        
        // Shields
        // Standard Shields
        new Item(ItemType.LargeLeatherShield, 0, 1402000, 0x38AA4000, 200),
        new Item(ItemType.HeaterShield      , 0, 1450000, 0x38E8C000, 250),
        new Item(ItemType.TowerKiteShield   , 0, 1452000, 0x39274000, 250),
        new Item(ItemType.CaduceusKiteShield, 0, 1477000, 0x3965C000, 250),

        // Ammunition
        // Arrows
        new Item(ItemType.StandardArrow, 0, 2000000, 0x7A1E8000, 0),
        new Item(ItemType.LargeArrow, 0, 2001000, 0x7A24C000, 0),
        new Item(ItemType.WoodenArrow, 0, 2006000, 0x7A184000, 0),
        // Bolts
        new Item(ItemType.StandardBolt    , 0, 2100000, 0x7B570000, 0),
        new Item(ItemType.HeavyBolt    , 0, 2101000, 0x7B5D4000, 0),
        new Item(ItemType.WoodBolt, 0, 2103000, 0x7B50C000, 0),
        
        // Items
        new Item(ItemType.BlackSeparationCrystal, 64, 103, 0x1F000, 0),
        new Item(ItemType.CrackedRedEyeOrb      , 64, 111, 0x16000, 0),
        new Item(ItemType.Darksign              , 64, 117, 0x6E000, 0),
        new Item(ItemType.FullEstusFlask        , 64, 201, 0x2000, 0),
        new Item(ItemType.DivineBlessing        , 64, 240, 0x2B000, 0),
        new Item(ItemType.LLoydsTalisman        , 64, 296, 0x35000, 0),
        new Item(ItemType.HomewardBone          , 64, 330, 0x38000, 0),
        new Item(ItemType.SoulOfALostUndead          , 64, 400, 0x41000, 0),
        new Item(ItemType.LargeSoulOfANamelessSoldier, 64, 403, 0x44000, 0),
        new Item(ItemType.Humanity              , 64, 500, 0x65000, 0),
        new Item(ItemType.TitaniteShard         , 64, 1000, 0x3E9000, 0),
        new Item(ItemType.TitaniteChunk         , 64, 1030, 0x3EB000, 0),
        new Item(ItemType.TwinklingTitanite     , 64, 1130, 0x3F4000, 0),
        
    };

    public static Item? GetItem(UInt32 idSpace, UInt32 id)
    {
        foreach (var item in _items)
        {
            if (item.IdSpace == idSpace && item.ID == id) return item;
        }

        return null;
    }
    
    public static Item? GetItem(ItemType type)
    {
        foreach (var item in _items)
        {
            if (item.Type == type) return item;
        }

        return null;
    }
    
    
}