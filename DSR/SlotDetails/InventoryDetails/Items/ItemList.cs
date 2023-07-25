using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails.InventoryDetails.Items;

public class ItemList
{
    private static readonly List<Item> _items = new()
    {
        // Key Items       64
        new KeyItem(ItemType.PeculiarDoll,                                      64,     384,    0x00FD30),
        // Embers    8xx
        new KeyItem(ItemType.LargeEmber,                                        64,     800,    0x00FAC0),
        new KeyItem(ItemType.VeryLargeEmber,                                    64,     801,    0x00FAE0),
        new KeyItem(ItemType.CrystalEmber,                                      64,     802,    0x00FB00),
        new KeyItem(ItemType.LargeMagicEmber,                                   64,     806,    0x00FB60),
        new KeyItem(ItemType.EnchantedEmber,                                    64,     807,    0x00FB80),
        new KeyItem(ItemType.DivineEmber,                                       64,     808,    0x00FBA0),
        new KeyItem(ItemType.LargeDivineEmber,                                  64,     809,    0x00FBC0),
        new KeyItem(ItemType.DarkEmber,                                         64,     810,    0x00FBE0),
        new KeyItem(ItemType.LargeFlameEmber,                                   64,     812,    0x00FB20),
        new KeyItem(ItemType.ChaosFlameEmber,                                   64,     813,    0x00FB40),
        // Keys     2xxx
        new KeyItem(ItemType.BasementKey,                                       64,     2001,   0x00FE40),
        new KeyItem(ItemType.CrestOfArtorias,                                   64,     2002,   0x00FD60),
        new KeyItem(ItemType.CageKey,                                           64,     2003,   0x00FF20),
        new KeyItem(ItemType.ArchiveTowerCellKey,                               64,     2004,   0x00FF40),
        new KeyItem(ItemType.ArchiveTowerGiantDoorKey,                          64,     2005,   0x00FFA0),
        new KeyItem(ItemType.ArchiveTowerGiantCellKey,                          64,     2006,   0x00FF80),
        new KeyItem(ItemType.BlighttownKey,                                     64,     2007,   0x00FEC0),
        new KeyItem(ItemType.KeyToNewLondoRuins,                                64,     2008,   0x00FEE0),
        new KeyItem(ItemType.AnnexKey,                                          64,     2009,   0x00FFC0),
        new KeyItem(ItemType.DungeonCellKey,                                    64,     2010,   0x00FD80),
        new KeyItem(ItemType.BigPilgrimsKey,                                    64,     2011,   0x00FDE0),
        new KeyItem(ItemType.UndeadAsylumF2EastKey,                             64,     2012,   0x00FDA0),
        new KeyItem(ItemType.KeyToTheSeal,                                      64,     2013,   0x00FF00),
        new KeyItem(ItemType.KeyToDepths,                                       64,     2014,   0x00FE60),
        new KeyItem(ItemType.LiftChamberKey,                                    64,     2015,   0x000000), // Unoptainable
        new KeyItem(ItemType.UndeadAsylumF2WestKey,                             64,     2016,   0x00FDC0),
        new KeyItem(ItemType.MysteryKey,                                        64,     2017,   0x00FE20),
        new KeyItem(ItemType.SewerChamberKey,                                   64,     2018,   0x00FEA0),
        new KeyItem(ItemType.WatchtowerBasementKey,                             64,     2019,   0x00FE80),
        new KeyItem(ItemType.ArchivePrisonExtraKey,                             64,     2020,   0x00FF60),
        new KeyItem(ItemType.ResidenceKey,                                      64,     2021,   0x00FE00),
        new KeyItem(ItemType.MasterKey,                                         64,     2100,   0x00FD40),
        // Lord Souls /-vessel   25xx
        new KeyItem(ItemType.LordSoulGravelordNito,                             64,     2500,   0x00FA40),
        new KeyItem(ItemType.LordSoulBedOfChaos,                                64,     2501,   0x00FA60),
        new KeyItem(ItemType.BequeathedLordSoulShardFourKings,                  64,     2502,   0x00FA80),
        new KeyItem(ItemType.BequeathedLordSoulShardSeathTheScaleless,          64,     2503,   0x00FAA0),
        new KeyItem(ItemType.Lordvessel,                                        64,     2510,   0x00FA20),
        // Bonfire Upgrades     26xx
        new KeyItem(ItemType.WeaponSmithbox,                                    64,     2600,   0x00FCC0),
        new KeyItem(ItemType.ArmorSmithbox,                                     64,     2601,   0x00FCE0),
        new KeyItem(ItemType.Repairbox,                                         64,     2602,   0x00FCA0),
        new KeyItem(ItemType.RiteOfKindling,                                    64,     2607,   0x00FD20),
        new KeyItem(ItemType.BottomlessBox,                                     64,     2608,   0x00FD00),




        // Armor        16      XX0000 = Helm, XX1000 Chest, XX2000 Gauntlets, XX3000 Leggings

        // Empty Slots
        new Armor(ItemType.Helm, 16, 900000, 0, 0, ArmorUpgradeType.Unoptainable),
        new Armor(ItemType.Chest, 16, 901000, 0, 0, ArmorUpgradeType.Unoptainable),
        new Armor(ItemType.Gauntlets, 16, 902000, 0, 0, ArmorUpgradeType.Unoptainable),
        new Armor(ItemType.Leggings, 16, 903000, 0, 0, ArmorUpgradeType.Unoptainable),

        new Armor(ItemType.CatarinaHelm,                16,     10000,  0x01C200,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.CatarinaArmor,               16,     11000,  0x01C840,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.CatarinaGauntlets,           16,     12000,  0x01CE80,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.CatarinaLeggings,            16,     13000,  0x01D4C0,       400,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.PaladinHelm,                 16,     20000,  0x04DBC0,       500,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.PaladinArmor,                16,     21000,  0x04E200,       500,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.PaladinGauntlets,            16,     22000,  0x04E840,       500,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.PaladinLeggings,             16,     23000,  0x04EE80,       500,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.DarkMask,                    16,     40000,  0x0490C0,       300,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.DarkArmor,                   16,     41000,  0x049700,       300,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.DarkGauntlets,               16,     42000,  0x049D40,       300,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.DarkLeggings,                16,     43000,  0x04A380,       300,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.BrigandHood,                 16,     50000,  0x009C40,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BrigandArmor,                16,     51000,  0x00A280,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BrigandGauntlets,            16,     52000,  0x00A8C0,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BrigandTrousers,             16,     53000,  0x00AF00,       200,    ArmorUpgradeType.Regular),

        new Armor(ItemType.ShadowMask,                  16,     60000,  0x02F440,       200,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.ShadowGarb,                  16,     61000,  0x02FA80,       200,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.ShadowGauntlets,             16,     62000,  0x0300C0,       200,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.ShadowLeggings,              16,     63000,  0x030700,       200,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.BlackIronHelm,               16,     70000,  0x019000,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackIronArmor,              16,     71000,  0x019640,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackIronGauntlets,          16,     72000,  0x019C80,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackIronLeggings,           16,     73000,  0x01A2C0,       600,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.SmoughsHelm,                16,     80000,  0x042CC0,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.SmoughsArmor,               16,     81000,  0x043300,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.SmoughsGauntlets,           16,     82000,  0x043940,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.SmoughsLeggings,            16,     83000,  0x043F80,       700,    ArmorUpgradeType.None),

        new Armor(ItemType.SixEyedHelmOfTheChannelers,  16,     90000,  0x03D540,       300,    ArmorUpgradeType.None),
        new Armor(ItemType.RobeOfTheChannelers,         16,     91000,  0x03DB80,       300,    ArmorUpgradeType.None),
        new Armor(ItemType.GauntletsOfTheChannelers,    16,     92000,  0x03E1C0,       300,    ArmorUpgradeType.None),
        new Armor(ItemType.WaistclothOfTheChannelers,   16,     93000,  0x03E800,       300,    ArmorUpgradeType.None),

        new Armor(ItemType.HelmOfFavor,                 16,     100000, 0x04C2C0,       500,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.EmbracedArmorOfFavor,        16,     101000, 0x04C900,       500,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.GauntletsOfFavor,            16,     102000, 0x04CF40,       500,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.LeggingsOfFavor,             16,     103000, 0x04D580,       500,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.HelmOfTheWise,               16,     110000, 0x01A900,       500,    ArmorUpgradeType.None),
        new Armor(ItemType.ArmorOfTheGlorious,          16,     111000, 0x01AF40,       500,    ArmorUpgradeType.None),
        new Armor(ItemType.GauntletsOfTheVanquisher,    16,     112000, 0x01B580,       500,    ArmorUpgradeType.None),
        new Armor(ItemType.BootsOfTheExplorer,          16,     113000, 0x01BBC0,       500,    ArmorUpgradeType.None),

        new Armor(ItemType.StoneHelm,                   16,     120000, 0x04F4C0,       800,    ArmorUpgradeType.None),
        new Armor(ItemType.StoneArmor,                  16,     121000, 0x04FB00,       800,    ArmorUpgradeType.None),
        new Armor(ItemType.StoneGauntlets,              16,     122000, 0x050140,       800,    ArmorUpgradeType.None),
        new Armor(ItemType.StoneLeggings,               16,     123000, 0x050780,       800,    ArmorUpgradeType.None),

        new Armor(ItemType.CrystallineHelm,             16,     130000, 0x01DB00,       150,    ArmorUpgradeType.None),
        new Armor(ItemType.CrystallineArmor,            16,     131000, 0x01E140,       150,    ArmorUpgradeType.None),
        new Armor(ItemType.CrystallineGauntlets,        16,     132000, 0x01E780,       150,    ArmorUpgradeType.None),
        new Armor(ItemType.CrystallineLeggings,         16,     133000, 0x01EDC0,       150,    ArmorUpgradeType.None),

        new Armor(ItemType.MaskOfTheSealer,             16,     140000, 0x022C40,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.CrimsonRobe,                 16,     141000, 0x023280,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.CrimsonGloves,               16,     142000, 0x0238C0,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.CrimsonWaistcloth,           16,     143000, 0x023F00,       400,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.MaskOfVelka,                 16,     150000, 0x029040,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackClericRobe,             16,     151000, 0x029680,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackManchette,              16,     152000, 0x029CC0,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackTights,                 16,     153000, 0x01A2C0,       400,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.IronHelm,                    16,     160000, 0x017700,       350,    ArmorUpgradeType.Regular),
        new Armor(ItemType.ArmorOfTheSun,               16,     161000, 0x017D40,       350,    ArmorUpgradeType.Regular),
        new Armor(ItemType.IronBracelet,                16,     162000, 0x018380,       350,    ArmorUpgradeType.Regular),
        new Armor(ItemType.IronLeggings,                16,     163000, 0x02A300,       350,    ArmorUpgradeType.Regular),

        new Armor(ItemType.ChainHelm,                   16,     170000, 0x001F40,       300,    ArmorUpgradeType.Regular),
        new Armor(ItemType.ChainArmor,                  16,     171000, 0x014B40,       300,    ArmorUpgradeType.Regular),
        new Armor(ItemType.LeatherGauntlets,            16,     172000, 0x002BC0,       300,    ArmorUpgradeType.Regular),
        new Armor(ItemType.ChainLeggings,               16,     173000, 0x003200,       300,    ArmorUpgradeType.Regular),

        new Armor(ItemType.ClericHelm,                  16,     180000, 0x014500,       500,    ArmorUpgradeType.Regular),
        new Armor(ItemType.ClericArmor,                 16,     181000, 0x002580,       500,    ArmorUpgradeType.Regular),
        new Armor(ItemType.ClericGauntlets,             16,     182000, 0x015180,       500,    ArmorUpgradeType.Regular),
        new Armor(ItemType.ClericLeggings,              16,     183000, 0x0157C0,       500,    ArmorUpgradeType.Regular),

        new Armor(ItemType.SunlightMaggot,              16,     190000, 0x055F00,       80,     ArmorUpgradeType.None),

        new Armor(ItemType.HelmOfThorns,                16,     200000, 0x04A9C0,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.ArmorOfThorns,               16,     201000, 0x04B000,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.GauntletsOfThorns,           16,     202000, 0x04B640,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.LeggingsOfThorns,            16,     203000, 0x04BC80,       250,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.StandardHelm,                16,     210000, 0x000640,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HardLeatherArmor,            16,     211000, 0x000C80,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HardLeatherGauntlets,        16,     212000, 0x0012C0,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HardLeatherBoots,            16,     213000, 0x001900,       250,    ArmorUpgradeType.Regular),

        new Armor(ItemType.SorcererHat,                 16,     220000, 0x00C800,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.SorcererCloak,               16,     221000, 0x00CE40,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.SorcererGauntlets,           16,     222000, 0x00D480,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.SorcererBoots,               16,     223000, 0x00DAC0,       200,    ArmorUpgradeType.Regular),

        new Armor(ItemType.TatteredClothHood,           16,     230000, 0x011300,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.TatteredClothRobe,           16,     231000, 0x011940,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.TatteredClothManchette,      16,     232000, 0x011F80,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HeavyBoots,                  16,     233000, 0x0125C0,       400,    ArmorUpgradeType.Regular),

        new Armor(ItemType.PharisHat,                 16,     240000, 0x020D00,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.LeatherArmor,                16,     241000, 0x00B540,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.LeatherGloves,               16,     242000, 0x00BB80,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.LeatherBoots,                16,     243000, 0x00C1C0,       250,    ArmorUpgradeType.Regular),

        new Armor(ItemType.PaintingGuardianHood,        16,     250000, 0x03EE40,       150,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.PaintingGuardianRobe,        16,     251000, 0x03F480,       150,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.PaintingGuardianGloves,      16,     252000, 0x03FAC0,       150,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.PaintingGuardianWaistcloth,  16,     253000, 0x040100,       150,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.OrnsteinsHelm,              16,     270000, 0x0445C0,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.OrnsteinsArmor,             16,     271000, 0x044C00,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.OrnsteinsGauntlets,         16,     272000, 0x045240,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.OrnsteinsLeggings,          16,     273000, 0x045880,       700,    ArmorUpgradeType.None),

        new Armor(ItemType.EasternHelm,                 16,     280000, 0x02DB40,       450,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.EasternArmor,                16,     281000, 0x02E180,       450,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.EasternGauntlets,            16,     282000, 0x02E7C0,       450,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.EasternLeggings,             16,     283000, 0x02EE00,       450,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.XanthousCrown,               16,     290000, 0x0526C0,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.XanthousOvercoat,            16,     291000, 0x052D00,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.XanthousGloves,              16,     292000, 0x053340,       400,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.XanthousWaistcloth,          16,     293000, 0x053980,       400,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.ThiefMask,                   16,     300000, 0x008340,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BlackLeatherArmor,           16,     301000, 0x008980,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BlackLeatherGloves,          16,     302000, 0x008FC0,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BlackLeatherBoots,           16,     303000, 0x009600,       250,    ArmorUpgradeType.Regular),

        new Armor(ItemType.PriestsHat,                 16,     310000, 0x012C00,       350,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HolyRobe,                    16,     311000, 0x013240,       350,    ArmorUpgradeType.Regular),
        new Armor(ItemType.TravelingGlovesCleric,     16,     312000, 0x013880,       350,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HolyTrousers,                16,     313000, 0x013EC0,       350,    ArmorUpgradeType.Regular),

        new Armor(ItemType.BlackKnightHelm,             16,     320000, 0x03A340,       550,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackKnightArmor,            16,     321000, 0x03A980,       550,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackKnightGauntlets,        16,     322000, 0x03AFC0,       550,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BlackKnightLeggings,         16,     323000, 0x03B600,       550,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.CrownOfDusk,                 16,     330000, 0x024B80,       150,    ArmorUpgradeType.None),
        new Armor(ItemType.AntiquatedDress,             16,     331000, 0x0251C0,       150,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.AntiquatedGloves,            16,     332000, 0x025800,       150,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.AntiquatedSkirt,             16,     333000, 0x025E40,       150,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.WitchHat,                    16,     340000, 0x024540,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.WitchCloak,                  16,     341000, 0x026480,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.WitchGloves,                 16,     342000, 0x026AC0,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.WitchSkirt,                  16,     343000, 0x027100,       250,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.EliteKnightHelm,             16,     350000, 0x005140,       450,    ArmorUpgradeType.Regular),
        new Armor(ItemType.EliteKnightArmor,            16,     351000, 0x005780,       450,    ArmorUpgradeType.Regular),
        new Armor(ItemType.EliteKnightGauntlets,        16,     352000, 0x005DC0,       450,    ArmorUpgradeType.Regular),
        new Armor(ItemType.EliteKnightLeggings,         16,     353000, 0x006400,       450,    ArmorUpgradeType.Regular),

        new Armor(ItemType.WandererHood,                16,     360000, 0x006A40,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.WandererCoat,                16,     361000, 0x007080,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.WandererManchette,           16,     362000, 0x0076C0,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.WandererBoots,               16,     363000, 0x007D00,       400,    ArmorUpgradeType.Regular),

        new Armor(ItemType.MageSmithHat,               16,     370000, 0x000000,       200,    ArmorUpgradeType.Unoptainable),  // Unoptainable
        new Armor(ItemType.MageSmithCoat,              16,     371000, 0x000000,       200,    ArmorUpgradeType.Unoptainable),  // Unoptainable
        new Armor(ItemType.MageSmithGauntlets,         16,     372000, 0x000000,       200,    ArmorUpgradeType.Unoptainable),  // Unoptainable
        new Armor(ItemType.MageSmithBoots,             16,     373000, 0x000000,       200,    ArmorUpgradeType.Unoptainable),  // Unoptainable

        new Armor(ItemType.BigHat,                      16,     380000, 0x021340,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.SageRobe,                    16,     381000, 0x021980,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.TravelingGlovesBigHat,     16,     382000, 0x021FC0,       250,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.TravelingBoots,              16,     383000, 0x022600,       250,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.KnightHelm,                  16,     390000, 0x003840,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.KnightArmor,                 16,     391000, 0x003E80,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.KnightGauntlets,             16,     392000, 0x03AFC0,       400,    ArmorUpgradeType.Regular),
        new Armor(ItemType.KnightLeggings,              16,     393000, 0x004B00,       400,    ArmorUpgradeType.Regular),

        new Armor(ItemType.DingyHood,                   16,     400000, 0x02C240,       150,    ArmorUpgradeType.Regular),
        new Armor(ItemType.DingyRobe,                   16,     401000, 0x02C880,       150,    ArmorUpgradeType.Regular),
        new Armor(ItemType.DingyGloves,                 16,     402000, 0x02CEC0,       150,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BloodStainedSkirt,          16,     403000, 0x02D500,       150,    ArmorUpgradeType.Regular),

        new Armor(ItemType.MaidenHood,                  16,     410000, 0x02A940,       150,    ArmorUpgradeType.Regular),
        new Armor(ItemType.MaidenBody,                  16,     411000, 0x02AF80,       150,    ArmorUpgradeType.Regular),
        new Armor(ItemType.MaidenGloves,                16,     412000, 0x02B5C0,       150,    ArmorUpgradeType.Regular),
        new Armor(ItemType.MaidenSkirt,                 16,     413000, 0x02BC00,       150,    ArmorUpgradeType.Regular),

        new Armor(ItemType.SilverKnightHelm,            16,     420000, 0x038A40,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.SilverKnightArmor,           16,     421000, 0x039080,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.SilverKnightGauntlets,       16,     422000, 0x0396C0,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.SilverKnightLeggings,        16,     423000, 0x039D00,       600,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.HavelsHelm,                 16,     440000, 0x050DC0,       900,    ArmorUpgradeType.None),
        new Armor(ItemType.HavelsArmor,                16,     441000, 0x051400,       900,    ArmorUpgradeType.None),
        new Armor(ItemType.HavelsGauntlets,            16,     442000, 0x051A40,       900,    ArmorUpgradeType.None),
        new Armor(ItemType.HavelsLeggings,             16,     443000, 0x052080,       900,    ArmorUpgradeType.None),

        new Armor(ItemType.BrassHelm,                   16,     450000, 0x01F400,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BrassArmor,                  16,     451000, 0x01FA40,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BrassGauntlets,              16,     452000, 0x020080,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.BrassLeggings,               16,     453000, 0x0206C0,       600,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.GoldHemmedBlackHood,         16,     460000, 0x027740,       400,    ArmorUpgradeType.None),
        new Armor(ItemType.GoldHemmedBlackCloak,        16,     461000, 0x027D80,       400,    ArmorUpgradeType.None),
        new Armor(ItemType.GoldHemmedBlackGloves,       16,     462000, 0x0283C0,       400,    ArmorUpgradeType.None),
        new Armor(ItemType.GoldHemmedBlackSkirt,        16,     463000, 0x028A00,       400,    ArmorUpgradeType.None),

        new Armor(ItemType.GolemHelm,                   16,     470000, 0x0413C0,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.GolemArmor,                  16,     471000, 0x041A00,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.GolemGauntlets,              16,     472000, 0x042040,       700,    ArmorUpgradeType.None),
        new Armor(ItemType.GolemLeggings,               16,     473000, 0x042680,       700,    ArmorUpgradeType.None),

        new Armor(ItemType.HollowSoldierHelm,           16,     480000, 0x032640,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HollowSoldierArmor,          16,     481000, 0x032C80,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HollowSoldierWaistcloth,     16,     483000, 0x033900,       200,    ArmorUpgradeType.Regular),

        new Armor(ItemType.SteelHelm,                   16,     490000, 0x035840,       500,    ArmorUpgradeType.Regular),
        new Armor(ItemType.SteelArmor,                  16,     491000, 0x035E80,       500,    ArmorUpgradeType.Regular),
        new Armor(ItemType.SteelGauntlets,              16,     492000, 0x0364C0,       500,    ArmorUpgradeType.Regular),
        new Armor(ItemType.SteelLeggings,               16,     493000, 0x036B00,       500,    ArmorUpgradeType.Regular),

        new Armor(ItemType.HollowThiefsHood,           16,     500000, 0x037140,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HollowThiefsLeatherArmor,   16,     501000, 0x037780,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HollowThiefsTights,         16,     503000, 0x038400,       250,    ArmorUpgradeType.Regular),

        new Armor(ItemType.BalderHelm,                  16,     510000, 0x033F40,       450,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BalderArmor,                 16,     511000, 0x034580,       450,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BalderGauntlets,             16,     512000, 0x034BC0,       450,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BalderLeggings,              16,     513000, 0x035200,       450,    ArmorUpgradeType.Regular),

        new Armor(ItemType.HollowWarriorHelm,           16,     520000, 0x030D40,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HollowWarriorArmor,          16,     521000, 0x031380,       250,    ArmorUpgradeType.Regular),
        new Armor(ItemType.HollowWarriorWaistcloth,     16,     523000, 0x032000,       250,    ArmorUpgradeType.Regular),

        new Armor(ItemType.GiantHelm,                   16,     530000, 0x03BC40,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.GiantArmor,                  16,     531000, 0x03C280,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.GiantGauntlets,              16,     532000, 0x03C8C0,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.GiantLeggings,               16,     533000, 0x03CF00,       600,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.CrownOfTheDarkSun,           16,     540000, 0x045EC0,       300,    ArmorUpgradeType.None),
        new Armor(ItemType.MoonlightRobe,               16,     541000, 0x046500,       80,     ArmorUpgradeType.None),
        new Armor(ItemType.MoonlightGloves,             16,     542000, 0x046B40,       80,     ArmorUpgradeType.None),
        new Armor(ItemType.MoonlightWaistcloth,         16,     543000, 0x047180,       80,     ArmorUpgradeType.None),

        new Armor(ItemType.CrownOfTheGreatLord,         16,     550000, 0x0477C0,       800,    ArmorUpgradeType.None),
        new Armor(ItemType.RobeOfTheGreatLord,          16,     551000, 0x047E00,       400,    ArmorUpgradeType.None),
        new Armor(ItemType.BraceletOfTheGreatLord,      16,     552000, 0x048440,       400,    ArmorUpgradeType.None),
        new Armor(ItemType.AnkletOfTheGreatLord,        16,     553000, 0x048A80,       400,    ArmorUpgradeType.None),

        new Armor(ItemType.Sack,                        16,     560000, 0x0558C0,       150,    ArmorUpgradeType.Regular),

        new Armor(ItemType.SymbolOfAvarice,             16,     570000, 0x056540,       300,    ArmorUpgradeType.None),
        new Armor(ItemType.RoyalHelm,                   16,     580000, 0x055280,       500,    ArmorUpgradeType.Regular),
        new Armor(ItemType.MaskOfTheFather,             16,     590000, 0x053FC0,       200,    ArmorUpgradeType.None),
        new Armor(ItemType.MaskOfTheMother,             16,     600000, 0x054600,       200,    ArmorUpgradeType.None),
        new Armor(ItemType.MaskOfTheChild,              16,     610000, 0x054C40,       200,    ArmorUpgradeType.None),
        new Armor(ItemType.FangBoarHelm,                16,     620000, 0x040740,       600,    ArmorUpgradeType.Twinkling),
        new Armor(ItemType.GargoyleHelm,                16,     630000, 0x040D80,       500,    ArmorUpgradeType.Twinkling),

        new Armor(ItemType.BlackSorcererHat,            16,     640000, 0x00E100,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BlackSorcererCloak,          16,     641000, 0x00E740,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BlackSorcererGauntlets,      16,     642000, 0x00ED80,       200,    ArmorUpgradeType.Regular),
        new Armor(ItemType.BlackSorcererBoots,          16,     643000, 0x00F3C0,       200,    ArmorUpgradeType.Regular),

        new Armor(ItemType.EliteClericHelm,            16,     650000, 0x000000,       500,    ArmorUpgradeType.Unoptainable),  // Unoptainable
        new Armor(ItemType.EliteClericArmor,           16,     651000, 0x000000,       500,    ArmorUpgradeType.Unoptainable),  // Unoptainable
        new Armor(ItemType.EliteClericGauntlets,       16,     652000, 0x000000,       500,    ArmorUpgradeType.Unoptainable),  // Unoptainable
        new Armor(ItemType.EliteClericLeggings,        16,     653000, 0x000000,       500,    ArmorUpgradeType.Unoptainable),  // Unoptainable



        // Weapons      0       XXXNXX Infusion, XXXXNN Level
        // Empty Slots
        new Weapon(ItemType.Fists, 0, 900000, 0x2AB98000, 5, WeaponUpgradeType.Unoptainable),
        
        // Daggers             01XXXXX
        new Weapon(ItemType.Dagger,                                             0,      100000, 0x000640,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.ParryingDagger,                                     0,      101000, 0x0044C0,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.GhostBlade,                                         0,      102000, 0x00C1C0,       100,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.BanditsKnife,                                       0,      103000, 0x008340,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.PriscillasDagger,                                   0,      104000, 0x010040,       100,    WeaponUpgradeType.Scales),
        
        // Straight Swords     02XXXXX
        new Weapon(ItemType.Shortsword,                                         0,      200000, 0x027740,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Longsword,                                          0,      201000, 0x02B5C0,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Broadsword,                                         0,      202000, 0x02F440,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.BrokenStraightSword,                                0,      203000, 0x0526C0,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.BalderSideSword,                                    0,      204000, 0x0332C0,       120,    WeaponUpgradeType.Full),
        new Weapon(ItemType.CrystalStraightSword,                               0,      205000, 0x046B40,       60,     WeaponUpgradeType.None),
        new Weapon(ItemType.SunlightStraightSword,                              0,      206000, 0x037140,       240,    WeaponUpgradeType.Full),
        new Weapon(ItemType.BarbedStraightSword,                                0,      207000, 0x042CC0,       160,    WeaponUpgradeType.Full),
        new Weapon(ItemType.SilverKnightStraightSword,                          0,      208000, 0x04A9C0,       300,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.AstorasStraightSword,                               0,      209000, 0x04B000,       160,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.DarkSword,                                          0,      210000, 0x03EE40,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DrakeSword,                                         0,      211000, 0x04EE80,       360,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.StraightSwordHilt,                                  0,      212000, 0x056540,       200,    WeaponUpgradeType.Full),
        
        // Greatswords         03XXXXX
        new Weapon(ItemType.BastardSword,                                       0,      300000, 0x075940,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Claymore,                                           0,      301000, 0x0797C0,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.ManserpentGreatsword,                               0,      302000, 0x07D640,       300,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Flamberge,                                          0,      303000, 0x0814C0,       160,    WeaponUpgradeType.Full),
        new Weapon(ItemType.CrystalGreatsword,                                  0,      304000, 0x085340,       60,     WeaponUpgradeType.None),
        new Weapon(ItemType.StoneGreatsword,                                    0,      306000, 0x08D040,       800,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.GreatswordOfArtoriasBrokenStraightSword,            0,      307000, 0x0526C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasStraightSwordHilt,              0,      307100, 0x056540,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightGreatsword,                                0,      309000, 0x0A08C0,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.BlackKnightSword,                                   0,      310000, 0x0891C0,       300,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.GreatswordOfArtoriasCursedDagger,                   0,      311000, 0x000640,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedParryingDagger,           0,      311100, 0x0044C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedBanditsKnife,             0,      311200, 0x008340,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedShortSword,               0,      311300, 0x027740,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedLongSword,                0,      311400, 0x02B5C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedBroadSword,               0,      311500, 0x02F440,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedBalderSideSword,          0,      311600, 0x0332C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedSunlightStraightSword,    0,      311700, 0x037140,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedBarbedStraightSword,      0,      311800, 0x042CC0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedDarkSword,                0,      312000, 0x03EE40,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedBastardSword,             0,      312100, 0x075940,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedClaymore,                 0,      312200, 0x0797C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedManserpentGreatsword,     0,      312300, 0x07D640,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedFlamberge,                0,      312400, 0x0814C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedZweihander,               0,      312500, 0x0C79C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedGreatsword,               0,      312600, 0x0C3B40,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatswordOfArtoriasCursedDemonGreatMachete,        0,      312700, 0x0CB840,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordDagger,                          0,      314000, 0x000640,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordParryingDagger,                  0,      314100, 0x0044C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordBanditsKnife,                    0,      314200, 0x008340,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordShortSword,                      0,      314300, 0x027740,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordLongSword,                       0,      314400, 0x02B5C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordBroadSword,                      0,      314500, 0x02F440,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordBalderSideSword,                 0,      314600, 0x0332C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordSunlightStraightSword,           0,      314700, 0x037140,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordBarbedStraightSword,             0,      314800, 0x042CC0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordDarkSword,                       0,      315000, 0x03EE40,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordBastardSword,                    0,      315100, 0x075940,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordClaymore,                        0,      315200, 0x0797C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordManserpentGreatsword,            0,      315300, 0x07D640,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordFlamberge,                       0,      315400, 0x0814C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordZweihander,                      0,      315500, 0x0C79C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordGreatsword,                      0,      315600, 0x0C3B40,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GreatLordGreatswordDemonGreatMachete,               0,      315700, 0x0CB840,       400,    WeaponUpgradeType.Scales),
        
        // Ultra Greatswords   035XXXX
        new Weapon(ItemType.Zweihander,                                         0,      350000, 0x0C79C0,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Greatsword,                                         0,      351000, 0x0C3B40,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DemonGreatMachete,                                  0,      352000, 0x0CB840,       600,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DragonGreatsword,                                   0,      354000, 0x0D3540,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.BlackKnightGreatsword,                              0,      355000, 0x0CF6C0,       300,    WeaponUpgradeType.Twinkling),
        
        // Curved Swords       04XXXXX
        new Weapon(ItemType.Scimitar,                                           0,      400000, 0x0EAC40,       160,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Falchion,                                           0,      401000, 0x0F0A00,       160,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Shotel,                                             0,      402000, 0x0F2940,       120,    WeaponUpgradeType.Full),
        new Weapon(ItemType.JaggedGhostBlade,                                   0,      403000, 0x0FA640,       100,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.PaintingGuardianSword,                              0,      405000, 0x0F67C0,       100,    WeaponUpgradeType.Full),
        new Weapon(ItemType.QuelaagsFuryswordScimitar,                          0,      406000, 0x0EAC40,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.QuelaagsFuryswordFalchion,                          0,      406100, 0x0F0A00,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.QuelaagsFuryswordShotel,                            0,      406200, 0x0F2940,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.QuelaagsFuryswordPaintingGuardianSword,             0,      406300, 0x0F67C0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.QuelaagsFuryswordServer,                            0,      406400, 0x115BC0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.QuelaagsFuryswordMurakumo,                          0,      406500, 0x111D40,       600,    WeaponUpgradeType.Scales),
        
        // Curved Greatswords  045XXXX
        new Weapon(ItemType.Server,                                             0,      450000, 0x115BC0,       140,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Murakumo,                                           0,      451000, 0x111D40,       180,    WeaponUpgradeType.Full),
        new Weapon(ItemType.GravelordSword,                                     0,      453000, 0x119A40,       600,    WeaponUpgradeType.Scales),
        
        // Katanas             05XXXXX
        new Weapon(ItemType.Uchigatana,                                         0,      500000, 0x138E40,       80,     WeaponUpgradeType.Full),
        new Weapon(ItemType.WashingPole,                                        0,      501000, 0x140B40,       60,     WeaponUpgradeType.Full),
        new Weapon(ItemType.Iaito,                                              0,      502000, 0x13CCC0,       80,     WeaponUpgradeType.Full),
        new Weapon(ItemType.ChaosBladeUchigatana,                               0,      503000, 0x138E40,       120,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.ChaosBladeWashingPole,                              0,      503100, 0x140B40,       120,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.ChaosBladeIaito,                                    0,      503200, 0x13CCC0,       120,    WeaponUpgradeType.Scales),
        
        // Piercing Swords     06XXXXX
        new Weapon(ItemType.MailBreaker,                                        0,      600000, 0x15FF40,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Rapier,                                             0,      601000, 0x163DC0,       150,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Estoc,                                              0,      602000, 0x167C40,       150,    WeaponUpgradeType.Full),
        new Weapon(ItemType.VelkasRapier,                                       0,      603000, 0x16F940,       130,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.RicardsRapier,                                      0,      604000, 0x16BAC0,       100,    WeaponUpgradeType.Full),
        
        // Axes                07XXXXX
        new Weapon(ItemType.HandAxe,                                            0,      700000, 0x187040,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.BattleAxe,                                          0,      701000, 0x18AEC0,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.CrescentAxe,                                        0,      702000, 0x196A40,       180,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.ButcherKnife,                                       0,      703000, 0x18ED40,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.GolemAxeHandAxe,                                    0,      704000, 0x187040,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GolemAxeBattleAxe,                                  0,      704100, 0x18AEC0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GolemAxeButcherKnife,                               0,      704300, 0x18ED40,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GolemAxeGargoyleTailAxe,                            0,      704400, 0x192BC0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GolemAxeDemonsGreataxe,                             0,      704600, 0x1B1FC0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.GargoyleTailAxe,                                    0,      705000, 0x192BC0,       150,    WeaponUpgradeType.Full),
        
        // GreatAxes           075XXXX
        new Weapon(ItemType.Greataxe,                                           0,      750000, 0x1AE140,       230,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DemonsGreataxe,                                     0,      751000, 0x1B1FC0,       600,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DragonKingGreataxe,                                 0,      752000, 0x1B9CC0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.BlackKnightGreataxe,                                0,      753000, 0x1B5E40,       300,    WeaponUpgradeType.Twinkling),
        
        // Hammers             08XXXXX
        new Weapon(ItemType.Club,                                               0,      800000, 0x1D3F80,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Mace,                                               0,      801000, 0x1DCF40,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.MorningStar,                                        0,      802000, 0x1E0DC0,       180,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Warpick,                                            0,      803000, 0x1E4C40,       220,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Pickaxe,                                            0,      804000, 0x1E8AC0,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.ReinforcedClub,                                     0,      809000, 0x1D5240,       100,    WeaponUpgradeType.Full),
        new Weapon(ItemType.BlacksmithHammer,                                   0,      810000, 0x1EC940,       250,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.BlacksmithGiantHammer,                              0,      811000, 0x1D90C0,       250,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.HammerOfVamos,                                      0,      812000, 0x1F07C0,       250,    WeaponUpgradeType.Twinkling),
        
        // GreatHammers        085XXXX
        new Weapon(ItemType.GreatClub,                                          0,      850000, 0x2001C0,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Grant,                                              0,      851000, 0x207EC0,       600,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.DemonsGreatHammer,                                  0,      852000, 0x204040,       600,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DragonTooth,                                        0,      854000, 0x20BD40,       999,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.LargeClub,                                          0,      855000, 0x1FC340,       250,    WeaponUpgradeType.Full),
        new Weapon(ItemType.SmoughsHammerClub,                                  0,      856000, 0x1D3F80,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerMace,                                  0,      856100, 0x1DCF40,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerMorningStar,                           0,      856200, 0x1E0DC0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerWarpick,                               0,      856300, 0x1E4C40,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerPickaxe,                               0,      856400, 0x1E8AC0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerReinforcedClub,                        0,      856500, 0x1D5240,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerBlacksmithHammer,                      0,      856600, 0x1EC940,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerGreatClub,                             0,      856900, 0x2001C0,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerDemonsGreatHammer,                     0,      857000, 0x204040,       600,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.SmoughsHammerLargeClub,                             0,      857100, 0x1FC340,       600,    WeaponUpgradeType.Scales),
        
        // Fist Weapons        09XXXXX
        new Weapon(ItemType.Caestus,                                            0,      901000, 0x2ABFC0,       300,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Claw,                                               0,      902000, 0x2AFE40,       150,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DragonBoneFistCaestus,                              0,      903000, 0x2ABFC0,       999,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonBoneFistClaw,                                 0,      903100, 0x2AFE40,       999,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DarkHand,                                           0,      904000, 0x2B7B40,       999,    WeaponUpgradeType.None),
        
        // Spears              10XXXXX
        new Weapon(ItemType.Spear,                                              0,      1000000,        0x223440,       180,    WeaponUpgradeType.Full),
        new Weapon(ItemType.WingedSpear,                                        0,      1001000,        0x2272C0,       140,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Partizan,                                           0,      1002000,        0x22B140,       160,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DemonsSpear,                                        0,      1003000,        0x236CC0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.ChannelersTrident,                                  0,      1004000,        0x232E40,       240,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.SilverKnightSpear,                                  0,      1006000,        0x23AB40,       300,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.Pike,                                               0,      1050000,        0x3B9840,       180,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DragonslayerSpearMailBreaker,                       0,      1051000,        0x15FF40,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonslayerSpearRapier,                            0,      1051100,        0x163DC0,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonslayerSpearEstoc,                             0,      1051200,        0x167C40,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonslayerSpearRicardsRapier,                     0,      1051900,        0x16BAC0,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonslayerSpearSpear,                             0,      1051300,        0x223440,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonslayerSpearWingedSpear,                       0,      1051400,        0x2272C0,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonslayerSpearPartizan,                          0,      1051500,        0x22B140,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DragonslayerSpearPike,                              0,      1051800,        0x3B9840,       300,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornMailBreaker,                  0,      1052000,        0x15FF40,       160,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornRapier,                       0,      1052100,        0x163DC0,       160,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornEstoc,                        0,      1052200,        0x167C40,       160,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornRicardsRapier,                0,      1052900,        0x16BAC0,       160,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornSpear,                        0,      1052300,        0x223440,       160,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornWingedSpear,                  0,      1052400,        0x2272C0,       160,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornPartizan,                     0,      1052500,        0x22B140,       160,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.MoonlightButterflyHornPike,                         0,      1052800,        0x3B9840,       160,    WeaponUpgradeType.Scales),
        
        // Halberds            11XXXXX
        new Weapon(ItemType.Halberd,                                            0,      1100000,        0x24A540,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.GiantsHalberd,                                      0,      1101000,        0x259F40,       300,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.TitaniteCatchPole,                                  0,      1102000,        0x25DDC0,       600,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.GargoylesHalberd,                                   0,      1103000,        0x2560C0,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.BlackKnightHalberd,                                 0,      1105000,        0x261C40,       300,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.Lucerne,                                            0,      1106000,        0x24E3C0,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.Scythe,                                             0,      1107000,        0x252240,       150,    WeaponUpgradeType.Full),
        new Weapon(ItemType.GreatScythe,                                        0,      1150000,        0x271640,       130,    WeaponUpgradeType.Full),
        new Weapon(ItemType.LifehuntScytheHalberd,                              0,      1151000,        0x24A540,       100,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.LifehuntScytheGargoylesHalberd,                     0,      1151400,        0x2560C0,       100,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.LifehuntScytheLucerne,                              0,      1151100,        0x24E3C0,       100,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.LifehuntScytheScythe,                               0,      1151205,        0x252240,       100,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.LifehuntScytheGreatScythe,                          0,      1151500,        0x271640,       100,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.LifehuntScytheWhip,                                 0,      1151600,        0x298740,       100,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.LifehuntScytheNotchedWhip,                          0,      1151700,        0x29C5C0,       100,    WeaponUpgradeType.Scales),
        
        // Bows                12XXXXX
        new Weapon(ItemType.ShortBow,                                           0,      1200000,        0x2BF840,       100,    WeaponUpgradeType.Full),
        new Weapon(ItemType.LongBow,                                            0,      1201000,        0x2C7540,       100,    WeaponUpgradeType.Full),
        new Weapon(ItemType.BlackBowOfPharis,                                   0,      1202000,        0x2CB3C0,       100,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DragonslayerGreatbow,                               0,      1203000,        0x2CF240,       100,    WeaponUpgradeType.Twinkling),
        new Weapon(ItemType.CompositeBow,                                       0,      1204000,        0x2C36C0,       100,    WeaponUpgradeType.Full),
        new Weapon(ItemType.DarkmoonBowShortBow,                                0,      1205000,        0x2BF840,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DarkmoonBowLongBow,                                 0,      1205200,        0x2C7540,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DarkmoonBowBlackBowOfPharis,                        0,      1205300,        0x2CB3C0,       400,    WeaponUpgradeType.Scales),
        new Weapon(ItemType.DarkmoonBowCompositeBow,                            0,      1205100,        0x2C36C0,       400,    WeaponUpgradeType.Scales),
        
        // Crossbow            125XXXX
        new Weapon(ItemType.LightCrossbow,                                      0,      1250000,        0x2E6940,       150,    WeaponUpgradeType.FullCrossbow),
        new Weapon(ItemType.HeavyCrossbow,                                      0,      1251000,        0x2EA7C0,       150,    WeaponUpgradeType.FullCrossbow),
        new Weapon(ItemType.Avelyn,                                             0,      1252000,        0x2F24C0,       150,    WeaponUpgradeType.FullCrossbow),
        new Weapon(ItemType.SniperCrossbow,                                     0,      1253000,        0x2EE640,       150,    WeaponUpgradeType.FullCrossbow),
        
        // Catalysts           130XXXX
        new Weapon(ItemType.SorcerersCatalyst,                                  0,      1300000,        0x30DA40,       90,     WeaponUpgradeType.None),
        new Weapon(ItemType.BeatricesCatalyst,                                  0,      1301000,        0x30E080,       90,     WeaponUpgradeType.None),
        new Weapon(ItemType.TinBanishmentCatalyst,                              0,      1302000,        0x30FFC0,       160,    WeaponUpgradeType.None),
        new Weapon(ItemType.LogansCatalyst,                                     0,      1303000,        0x30E6C0,       90,     WeaponUpgradeType.None),
        new Weapon(ItemType.TinDarkmoonCatalystSorcerersCatalyst,               0,      1304000,        0x30DA40,       60,     WeaponUpgradeType.None),
        new Weapon(ItemType.TinDarkmoonCatalystBeatricesCatalyst,               0,      1304100,        0x30E080,       60,     WeaponUpgradeType.None),
        new Weapon(ItemType.TinDarkmoonCatalystTinBanishmentCatalyst,           0,      1304200,        0x30FFC0,       60,     WeaponUpgradeType.None),
        new Weapon(ItemType.TinDarkmoonCatalystLogansCatalyst,                  0,      1304300,        0x30E6C0,       60,     WeaponUpgradeType.None),
        new Weapon(ItemType.TinDarkmoonCatalystOolacileIvoryCatalyst,           0,      1304400,        0x30ED00,       60,     WeaponUpgradeType.None),
        new Weapon(ItemType.OolacileIvoryCatalyst,                              0,      1305000,        0x30ED00,       30,     WeaponUpgradeType.None),
        new Weapon(ItemType.TinCrystallizationCatalyst,                         0,      1306000,        0x310600,       90,     WeaponUpgradeType.None),
        new Weapon(ItemType.DemonsCatalyst,                                     0,      1307000,        0x30F340,       300,    WeaponUpgradeType.None),
        new Weapon(ItemType.IzalithCatalyst,                                    0,      1308000,        0x30F980,       300,    WeaponUpgradeType.None),
        // Pyromancy Flames    133XXXX
        new Weapon(ItemType.PyromancyFlame,                                     0,      1330000,        0x315740,       30,     WeaponUpgradeType.Souls10),
        new Weapon(ItemType.PyromancyFlameAscended,                             0,      1332000,        0x315740,       30,     WeaponUpgradeType.Souls5),
        // Talismans           136XXXX
        new Weapon(ItemType.Talisman,                                           0,      1360000,        0x31E0C0,       50,     WeaponUpgradeType.None),
        new Weapon(ItemType.CanvasTalisman,                                     0,      1361000,        0x31E700,       50,     WeaponUpgradeType.None),
        new Weapon(ItemType.ThorolundTalisman,                                  0,      1362000,        0x31ED40,       50,     WeaponUpgradeType.None),
        new Weapon(ItemType.IvoryTalisman,                                      0,      1363000,        0x31F380,       50,     WeaponUpgradeType.None),
        new Weapon(ItemType.SunlightTalisman,                                   0,      1365000,        0x320000,       50,     WeaponUpgradeType.None),
        new Weapon(ItemType.DarkmoonTalisman,                                   0,      1366000,        0x320640,       50,     WeaponUpgradeType.None),
        new Weapon(ItemType.VelkasTalisman,                                     0,      1367000,        0x320C80,       50,     WeaponUpgradeType.None),
        
        new Weapon(ItemType.SkullLantern,                                       0,      1396000,        0x3212C0,       50,     WeaponUpgradeType.None),
        
        // Whips               16XXXXX
        new Weapon(ItemType.Whip,                                               0,      1600000,        0x298740,       200,    WeaponUpgradeType.Full),
        new Weapon(ItemType.NotchedWhip,                                        0,      1601000,        0x29C5C0,       200,    WeaponUpgradeType.Full),
        
        
        // Shields
        // Small Shields    14XXXXX
        new Weapon(ItemType.EastWestShield,                                     0,      1400000,        0x382D40,       160,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.WoodenShield,                                       0,      1401000,        0x386BC0,       160,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.LargeLeatherShield,                                 0,      1402000,        0x38AA40,       200,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.SmallLeatherShield,                                 0,      1403000,        0x3483C0,       200,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.TargetShield,                                       0,      1404000,        0x353F40,       150,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.Buckler,                                            0,      1405000,        0x3500C0,       140,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.CrackedRoundShield,                                 0,      1406000,        0x341340,       60,     WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.LeatherShield,                                      0,      1408000,        0x34C240,       200,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.PlankShield,                                        0,      1409000,        0x344540,       120,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.CaduceusRoundShield,                                0,      1410000,        0x3389C0,       180,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.CrystalRingShieldEastWestShield,                    0,      1411000,        0x382D40,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldWoodenShield,                      0,      1411100,        0x386BC0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldLargeLeatherShield,                0,      1411300,        0x38AA40,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldSmallLeatherShield,                0,      1411400,        0x3483C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldTargetShield,                      0,      1411600,        0x353F40,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldBuckler,                           0,      1411700,        0x3500C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldCrackedRoundShield,                0,      1411800,        0x341340,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldLeatherShield,                     0,      1411500,        0x34C240,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldPlankShield,                       0,      1411200,        0x344540,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldCaduceusRoundShield,               0,      1411900,        0x3389C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldHeaterShield,                      0,      1412000,        0x38E8C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldKnightShield,                      0,      1412100,        0x39E2C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldTowerKiteShield,                   0,      1412200,        0x392740,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldGrassCrestShield,                  0,      1412300,        0x3A9E40,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldHollowSoldierShield,               0,      1412400,        0x39A440,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldBalderShield,                      0,      1412500,        0x3A2DC0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldWarriorsRoundShield,               0,      1412600,        0x334B40,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldIronRoundShield,                   0,      1412700,        0x3AE940,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldSpiderShield,                      0,      1412800,        0x3A5FC0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldSpikedShield,                      0,      1412900,        0x3B9840,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldSunlightShield,                    0,      1413100,        0x3B1B40,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldPierceShield,                      0,      1413000,        0x3B59C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldRedandWhiteRoundShield,            0,      1413200,        0x33EDC0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldCaduceusKiteShield,                0,      1413300,        0x3965C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldGargoylesShield,                   0,      1413400,        0x3BD6C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldEagleShield,                       0,      1413500,        0x3F8040,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldTowerShield,                       0,      1413600,        0x3FBEC0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldGiantShield,                       0,      1413700,        0x4009C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldBonewheelShield,                   0,      1413800,        0x403BC0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldEffigyShield,                      0,      1413900,        0x33C840,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldSanctus,                           0,      1414000,        0x3A0840,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldBloodshield,                       0,      1414100,        0x3AC3C0,       120,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.CrystalRingShieldBlackIronGreatshield,              0,      1414200,        0x3FE440,       120,    WeaponUpgradeType.ShieldScales),
        
        // Standard Shields    145XXXX
        new Weapon(ItemType.HeaterShield,                                       0,      1450000,        0x38E8C0,       250,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.KnightShield,                                       0,      1451000,        0x39E2C0,       200,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.TowerKiteShield,                                    0,      1452000,        0x392740,       250,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.GrassCrestShield,                                   0,      1453000,        0x3A9E40,       200,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.HollowSoldierShield,                                0,      1454000,        0x39A440,       250,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.BalderShield,                                       0,      1455000,        0x3A2DC0,       220,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.CrestShield,                                        0,      1456000,        0x3C53C0,       300,    WeaponUpgradeType.ShieldTwinkling),
        new Weapon(ItemType.DragonCrestShield,                                  0,      1457000,        0x3C5A00,       300,    WeaponUpgradeType.ShieldTwinkling),
        new Weapon(ItemType.WarriorsRoundShield,                                0,      1460000,        0x334B40,       180,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.IronRoundShield,                                    0,      1461000,        0x3AE940,       280,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.SpiderShield,                                       0,      1462000,        0x3A5FC0,       230,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.SpikedShield,                                       0,      1470000,        0x3B9840,       160,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.CrystalShield,                                      0,      1471000,        0x3C1540,       250,    WeaponUpgradeType.None),
        new Weapon(ItemType.SunlightShield,                                     0,      1472000,        0x3B1B40,       280,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.SilverKnightShield,                                 0,      1473000,        0x3C9240,       250,    WeaponUpgradeType.ShieldTwinkling),
        new Weapon(ItemType.BlackKnightShield,                                  0,      1474000,        0x3C9880,       250,    WeaponUpgradeType.ShieldTwinkling),
        new Weapon(ItemType.PierceShield,                                       0,      1475000,        0x3B59C0,       180,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.RedandWhiteRoundShield,                             0,      1476000,        0x33EDC0,       180,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.CaduceusKiteShield,                                 0,      1477000,        0x3965C0,       250,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.GargoylesShield,                                    0,      1478000,        0x3BD6C0,       300,    WeaponUpgradeType.ShieldFull),
        
        // Greatshields       15XXXXX
        new Weapon(ItemType.EagleShield,                                        0,      1500000,        0x3F8040,       300,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.TowerShield,                                        0,      1501000,        0x3FBEC0,       300,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.GiantShield,                                        0,      1502000,        0x4009C0,       300,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.StoneGreatshield,                                   0,      1503000,        0x407A40,       400,    WeaponUpgradeType.ShieldTwinkling),
        new Weapon(ItemType.HavelsGreatshield,                                  0,      1505000,        0x40B8C0,       500,    WeaponUpgradeType.ShieldTwinkling),
        new Weapon(ItemType.BonewheelShield,                                    0,      1506000,        0x403BC0,       200,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.GreatshieldOfArtoriasEastWestShield,                0,      1507000,        0x382D40,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasWoodenShield,                  0,      1507100,        0x386BC0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasLargeLeatherShield,            0,      1507300,        0x38AA40,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasSmallLeatherShield,            0,      1507400,        0x3483C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasTargetShield,                  0,      1507600,        0x353F40,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasBuckler,                       0,      1507700,        0x3500C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasCrackedRoundShield,            0,      1507800,        0x341340,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasLeatherShield,                 0,      1507500,        0x34C240,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasPlankShield,                   0,      1507200,        0x344540,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasCaduceusRoundShield,           0,      1507900,        0x3389C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasHeaterShield,                  0,      1508000,        0x38E8C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasKnightShield,                  0,      1508100,        0x39E2C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasTowerKiteShield,               0,      1508200,        0x392740,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasGrassCrestShield,              0,      1508300,        0x3A9E40,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasHollowSoldierShield,           0,      1508400,        0x39A440,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasBalderShield,                  0,      1508500,        0x3A2DC0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasWarriorsRoundShield,           0,      1508600,        0x334B40,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasIronRoundShield,               0,      1508700,        0x3AE940,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasSpiderShield,                  0,      1508800,        0x3A5FC0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasSpikedShield,                  0,      1508900,        0x3B9840,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasSunlightShield,                0,      1509100,        0x3B1B40,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasPierceShield,                  0,      1509000,        0x3B59C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasRedandWhiteRoundShield,        0,      1509200,        0x33EDC0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasCaduceusKiteShield,            0,      1509300,        0x3965C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasGargoylesShield,               0,      1509400,        0x3BD6C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasEagleShield,                   0,      1509500,        0x3F8040,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasTowerShield,                   0,      1509600,        0x3FBEC0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasGiantShield,                   0,      1509700,        0x4009C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasBonewheelShield,               0,      1509800,        0x403BC0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasEffigyShield,                  0,      1509900,        0x33C840,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasSanctus,                       0,      1510000,        0x3A0840,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasBloodshield,                   0,      1510100,        0x3AC3C0,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.GreatshieldOfArtoriasBlackIronGreatshield,          0,      1510200,        0x3FE440,       600,    WeaponUpgradeType.ShieldScales),
        new Weapon(ItemType.EffigyShield,                                       0,      9000000,        0x33C840,       180,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.Sanctus,                                            0,      9001000,        0x3A0840,       410,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.Bloodshield,                                        0,      9002000,        0x3AC3C0,       240,    WeaponUpgradeType.ShieldFull),
        new Weapon(ItemType.BlackIronGreatshield,                               0,      9003000,        0x3FE440,       230,    WeaponUpgradeType.ShieldFull),

        // DLC Dagger          90XXXXX

        // Ammunition
        // Arrows              20XXXXX
        new Weapon(ItemType.StandardArrow,      0,      2000000,        0x7A1E80,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.LargeArrow,         0,      2001000,        0x7A24C0,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.FeatherArrow,       0,      2002000,        0x7A2B00,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.FireArrow,          0,      2003000,        0x7A3140,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.PoisonArrow,        0,      2004000,        0x7A3780,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.MoonlightArrow,     0,      2005000,        0x7A3DC0,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.WoodenArrow,        0,      2006000,        0x7A1840,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.DragonslayerArrow,  0,      2007000,        0x7A4400,       0,      WeaponUpgradeType.None),
        
        // Bolts               21XXXXX
        new Weapon(ItemType.StandardBolt,       0,      2100000,        0x928880,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.HeavyBolt,          0,      2101000,        0x928EC0,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.SniperBolt,         0,      2102000,        0x929500,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.WoodBolt,           0,      2103000,        0x928240,       0,      WeaponUpgradeType.None),
        new Weapon(ItemType.LightningBolt,      0,      2104000,        0x929B40,       0,      WeaponUpgradeType.None),

        // Rings        32      
        new Ring(ItemType.HavelsRing,                   32,     100,    0x000030),
        new Ring(ItemType.RedTearstoneRing,             32,     101,    0x0000C0),
        new Ring(ItemType.DarkmoonBladeCovenantRing,    32,     102,    0x000170),
        new Ring(ItemType.CatCovenantRing,              32,     103,    0x000250),
        new Ring(ItemType.CloranthyRing,                32,     104,    0x000020),
        new Ring(ItemType.FlameStoneplateRing,          32,     105,    0x000060),
        new Ring(ItemType.ThunderStoneplateRing,        32,     106,    0x000070),
        new Ring(ItemType.SpellStoneplateRing,          32,     107,    0x000050),
        new Ring(ItemType.SpeckledStoneplateRing,       32,     108,    0x000080),
        new Ring(ItemType.BloodbiteRing,                32,     109,    0x000090),
        new Ring(ItemType.PoisonbiteRing,               32,     110,    0x0000A0),
        new Ring(ItemType.TinyBeingsRing,               32,     111,    0x000010),
        new Ring(ItemType.CursebiteRing,                32,     113,    0x0000B0),
        new Ring(ItemType.WhiteSeanceRing,              32,     114,    0x000140),
        new Ring(ItemType.BellowingDragoncrestRing,     32,     115,    0x000100),
        new Ring(ItemType.DuskCrownRing,                32,     116,    0x000130),
        new Ring(ItemType.HornetRing,                   32,     117,    0x0001C0),
        new Ring(ItemType.HawkRing,                     32,     119,    0x0001B0),
        new Ring(ItemType.RingOfSteelProtection,        32,     120,    0x000040),
        new Ring(ItemType.CovetousGoldSerpentRing,      32,     121,    0x000200),
        new Ring(ItemType.CovetousSilverSerpentRing,    32,     122,    0x000210),
        new Ring(ItemType.SlumberingDragoncrestRing,    32,     123,    0x000120),
        new Ring(ItemType.RingOfFog,                    32,     124,    0x000260),
        new Ring(ItemType.RustedIronRing,               32,     125,    0x0001F0),
        new Ring(ItemType.RingOfSacrifice,              32,     126,    0x0000E0),
        new Ring(ItemType.RareRingOfSacrifice,          32,     127,    0x0000F0),
        new Ring(ItemType.DarkWoodGrainRing,            32,     128,    0x0001E0),
        new Ring(ItemType.RingOfTheSunPrincess,         32,     130,    0x000180),
        new Ring(ItemType.OldWitchsRing,                32,     137,    0x000240),
        new Ring(ItemType.CovenantOfArtorias,           32,     138,    0x000220),
        new Ring(ItemType.OrangeCharredRing,            32,     139,    0x000230),
        new Ring(ItemType.LingeringDragoncrestRing,     32,     141,    0x000110),
        new Ring(ItemType.RingOfTheEvilEye,             32,     142,    0x000280),
        new Ring(ItemType.RingOfFavorandProtection,     32,     143,    0x000270),
        new Ring(ItemType.LeoRing,                      32,     144,    0x000190),
        new Ring(ItemType.EastWoodGrainRing,            32,     145,    0x0001D0),
        new Ring(ItemType.WolfRing,                     32,     146,    0x0001A0),
        new Ring(ItemType.BlueTearstoneRing,            32,     147,    0x0000D0),
        new Ring(ItemType.RingOfTheSunsFirstborn,       32,     148,    0x000160),
        new Ring(ItemType.DarkmoonSeanceRing,           32,     149,    0x000150),


        // Items
        new SpecialItem(ItemType.BlackSeparationCrystal, 64, 103, 0x1F000),
        new CommonItem(ItemType.EyeOfDeath, 64, 109, 0x1E000),
        new CommonItem(ItemType.CrackedRedEyeOrb, 64, 111, 0x16000),
        new SpecialItem(ItemType.Darksign, 64, 117, 0x6E000),
        new EstusFlask(),
        new CommonItem(ItemType.DivineBlessing, 64, 240, 0x2B000),
        new CommonItem(ItemType.LloydsTalisman, 64, 296, 0x35000),
        new CommonItem(ItemType.TransientCurse, 64, 312, 0x37000),
        new CommonItem(ItemType.HomewardBone, 64, 330, 0x38000),
        new CommonItem(ItemType.SouvenirOfReprisal, 64, 374, 0x18000),
        new CommonItem(ItemType.SunlightMedal, 64, 375, 0x13000),
        // Souls 4XX
        new CommonSoul(ItemType.SoulOfALostUndead, 64, 400, 0x41000),
        new CommonSoul(ItemType.LargeSoulOfANamelessSoldier, 64, 403, 0x44000),

        new CommonItem(ItemType.Humanity, 64, 500, 0x65000),

        // Upgrade Materials 1XXX
        new UpgradeMaterial(ItemType.TitaniteShard, 64, 1000, 0x3E9000),
        new UpgradeMaterial(ItemType.TitaniteChunk, 64, 1030, 0x3EB000),
        new UpgradeMaterial(ItemType.TwinklingTitanite, 64, 1130, 0x3F4000),

        // Spells   3XXX
        new Spell(ItemType.SoulArrow, 64, 3000, 0xBB9000),
        new Spell(ItemType.HeavySoulArrow, 64, 3020, 0xBBB000),
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
            if (item.Type == type)
            {
                if (item is Weapon weapon) return new Weapon(weapon);
                if (item is Armor armor)   return new Armor(armor);
                if (item is EstusFlask estus) return new EstusFlask(estus);
                if (item is KeyItem keyItem) return new KeyItem(keyItem);
                if (item is Ring ring) return new Ring(ring);
                if (item is SpecialItem specialItem) return new SpecialItem(specialItem);
                if (item is Spell spell) return new Spell(spell);
                if (item is UpgradeMaterial upgradeMaterial) return new UpgradeMaterial(upgradeMaterial);
                if (item is CommonSoul commonSoul) return new CommonSoul(commonSoul);
                if (item is CommonItem commonItem) return new CommonItem(commonItem);
                return new Item(item);
            }
        }

        return null;
    }

    public static List<Item> GetItems(Type type, bool explicitType = false)
    {
        var list = new List<Item>();

        if (!explicitType)
        {
            foreach (var item in _items)
            {
                if (type.IsInstanceOfType(item)) list.Add(item);
            }
        }
        else
        {
            foreach (var item in _items)
            {
                if (item.GetType() == type) list.Add(item);
            }
        }

        if (type != typeof(Armor)) list.Sort((i1, i2) => (int)(i1.Sorting - i2.Sorting));

        return list;
    }
}