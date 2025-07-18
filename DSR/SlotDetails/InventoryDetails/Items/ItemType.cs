﻿using DSR.SlotDetailsDefinition;

namespace DSR.SlotDetails.InventoryDetails.Items;

public enum ItemType
{
    UNKNOWN,

    // Key Items
    PeculiarDoll,
    LargeEmber,
    VeryLargeEmber,
    CrystalEmber,
    LargeMagicEmber,
    EnchantedEmber,
    DivineEmber,
    LargeDivineEmber,
    DarkEmber,
    LargeFlameEmber,
    ChaosFlameEmber,
    BasementKey,
    CrestOfArtorias,
    CageKey,
    ArchiveTowerCellKey,
    ArchiveTowerGiantDoorKey,
    ArchiveTowerGiantCellKey,
    BlighttownKey,
    KeyToNewLondoRuins,
    AnnexKey,
    DungeonCellKey,
    BigPilgrimsKey,
    UndeadAsylumF2EastKey,
    KeyToTheSeal,
    KeyToDepths,
    LiftChamberKey, // Unoptainable
    UndeadAsylumF2WestKey,
    MysteryKey,
    SewerChamberKey,
    WatchtowerBasementKey,
    ArchivePrisonExtraKey,
    ResidenceKey,
    CrestKey,
    MasterKey,

    LordSoulGravelordNito,
    LordSoulBedOfChaos,
    LordSoulFourKings,
    LordSoulSeathTheScaleless,
    Lordvessel,
    BrokenPendant,
    
    WeaponSmithbox,
    ArmorSmithbox,
    Repairbox,
    RiteOfKindling,
    BottomlessBox,


    // Armor
    // Empty Slots
    Helm,
    Chest,
    Gauntlets,
    Leggings,

    CatarinaHelm,
    CatarinaArmor,
    CatarinaGauntlets,
    CatarinaLeggings,

    PaladinHelm,
    PaladinArmor,
    PaladinGauntlets,
    PaladinLeggings,

    DarkMask,
    DarkArmor,
    DarkGauntlets,
    DarkLeggings,

    BrigandHood,
    BrigandArmor,
    BrigandGauntlets,
    BrigandTrousers,

    ShadowMask,
    ShadowGarb,
    ShadowGauntlets,
    ShadowLeggings,

    BlackIronHelm,
    BlackIronArmor,
    BlackIronGauntlets,
    BlackIronLeggings,

    SmoughsHelm,
    SmoughsArmor,
    SmoughsGauntlets,
    SmoughsLeggings,

    SixEyedHelmOfTheChannelers,
    RobeOfTheChannelers,
    GauntletsOfTheChannelers,
    WaistclothOfTheChannelers,

    HelmOfFavor,
    EmbracedArmorOfFavor,
    GauntletsOfFavor,
    LeggingsOfFavor,

    HelmOfTheWise,
    ArmorOfTheGlorious,
    GauntletsOfTheVanquisher,
    BootsOfTheExplorer,

    StoneHelm,
    StoneArmor,
    StoneGauntlets,
    StoneLeggings,

    CrystallineHelm,
    CrystallineArmor,
    CrystallineGauntlets,
    CrystallineLeggings,

    MaskOfTheSealer,
    CrimsonRobe,
    CrimsonGloves,
    CrimsonWaistcloth,

    MaskOfVelka,
    BlackClericRobe,
    BlackManchette,
    BlackTights,

    IronHelm,
    ArmorOfTheSun,
    IronBracelet,
    IronLeggings,

    ChainHelm,
    ChainArmor,
    LeatherGauntlets,
    ChainLeggings,

    ClericHelm,
    ClericArmor,
    ClericGauntlets,
    ClericLeggings,

    SunlightMaggot,

    HelmOfThorns,
    ArmorOfThorns,
    GauntletsOfThorns,
    LeggingsOfThorns,

    StandardHelm,
    HardLeatherArmor,
    HardLeatherGauntlets,
    HardLeatherBoots,

    SorcererHat,
    SorcererCloak,
    SorcererGauntlets,
    SorcererBoots,

    TatteredClothHood,
    TatteredClothRobe,
    TatteredClothManchette,
    HeavyBoots,

    PharisHat,
    LeatherArmor,
    LeatherGloves,
    LeatherBoots,

    PaintingGuardianHood,
    PaintingGuardianRobe,
    PaintingGuardianGloves,
    PaintingGuardianWaistcloth,

    OrnsteinsHelm,
    OrnsteinsArmor,
    OrnsteinsGauntlets,
    OrnsteinsLeggings,

    EasternHelm,
    EasternArmor,
    EasternGauntlets,
    EasternLeggings,

    XanthousCrown,
    XanthousOvercoat,
    XanthousGloves,
    XanthousWaistcloth,

    ThiefMask,
    BlackLeatherArmor,
    BlackLeatherGloves,
    BlackLeatherBoots,

    PriestsHat,
    HolyRobe,
    TravelingGlovesHolySet,
    HolyTrousers,

    BlackKnightHelm,
    BlackKnightArmor,
    BlackKnightGauntlets,
    BlackKnightLeggings,

    CrownOfDusk,
    AntiquatedDress,
    AntiquatedGloves,
    AntiquatedSkirt,

    WitchHat,
    WitchCloak,
    WitchGloves,
    WitchSkirt,

    EliteKnightHelm,
    EliteKnightArmor,
    EliteKnightGauntlets,
    EliteKnightLeggings,

    WandererHood,
    WandererCoat,
    WandererManchette,
    WandererBoots,

    MageSmithHat,       // Unoptainable
    MageSmithCoat,      // Unoptainable
    MageSmithGauntlets, // Unoptainable
    MageSmithBoots,     // Unoptainable

    BigHat,
    SageRobe,
    TravelingGlovesBigHatSet,
    TravelingBoots,

    KnightHelm,
    KnightArmor,
    KnightGauntlets,
    KnightLeggings,

    DingyHood,
    DingyRobe,
    DingyGloves,
    BloodStainedSkirt,

    MaidenHood,
    MaidenRobe,
    MaidenGloves,
    MaidenSkirt,

    SilverKnightHelm,
    SilverKnightArmor,
    SilverKnightGauntlets,
    SilverKnightLeggings,

    HavelsHelm,
    HavelsArmor,
    HavelsGauntlets,
    HavelsLeggings,

    BrassHelm,
    BrassArmor,
    BrassGauntlets,
    BrassLeggings,

    GoldHemmedBlackHood,
    GoldHemmedBlackCloak,
    GoldHemmedBlackGloves,
    GoldHemmedBlackSkirt,

    GolemHelm,
    GolemArmor,
    GolemGauntlets,
    GolemLeggings,

    HollowSoldierHelm,
    HollowSoldierArmor,
    HollowSoldierWaistcloth,

    SteelHelm,
    SteelArmor,
    SteelGauntlets,
    SteelLeggings,

    HollowThiefsHood,
    HollowThiefsLeatherArmor,
    HollowThiefsTights,

    BalderHelm,
    BalderArmor,
    BalderGauntlets,
    BalderLeggings,

    HollowWarriorHelm,
    HollowWarriorArmor,
    HollowWarriorWaistcloth,

    GiantHelm,
    GiantArmor,
    GiantGauntlets,
    GiantLeggings,

    CrownOfTheDarkSun,
    MoonlightRobe,
    MoonlightGloves,
    MoonlightWaistcloth,

    CrownOfTheGreatLord,
    RobeOfTheGreatLord,
    BraceletOfTheGreatLord,
    AnkletOfTheGreatLord,

    Sack,
    SymbolOfAvarice,
    RoyalHelm,
    MaskOfTheFather,
    MaskOfTheMother,
    MaskOfTheChild,
    FangBoarHelm,
    GargoyleHelm,

    BlackSorcererHat,
    BlackSorcererCloak,
    BlackSorcererGauntlets,
    BlackSorcererBoots,

    EliteClericHelm,        // Unoptainable
    EliteClericArmor,       // Unoptainable
    EliteClericGauntlets,   // Unoptainable
    EliteClericLeggings,    // Unoptainable
    
    HelmOfArtorias,
    ArmorOfArtorias,
    GauntletsOfArtorias,
    LeggingsOfArtorias,
    
    PorcelainMask,
    LordsBladeRobe,
    LordsBladeGloves,
    LordsBladeWaistcloth,
    
    GoughsHelm,
    GoughsChest,
    GoughsGloves,
    GoughsLeggings,
    
    GuardianHelm,
    GuardianArmor,
    GuardianGauntlets,
    GuardianLeggings,
    
    SnickeringTopHat,
    ChestersLongCoat,
    ChestersGloves,
    ChestersTrousers,
    
    BloatedHead,
    BloatedSorcererHead,


    // Weapons
    // Empty Slot
    Fists,

    // Daggers
    Dagger,
    ParryingDagger,
    GhostBlade,
    BanditsKnife,
    PriscillasDagger,

    // Straight Swords
    Shortsword,
    Longsword,
    Broadsword,
    BrokenStraightSword,
    BalderSideSword,
    CrystalStraightSword,
    SunlightStraightSword,
    BarbedStraightSword,
    SilverKnightStraightSword,
    AstorasStraightSword,
    Darksword,
    DrakeSword,
    StraightSwordHilt,

    // Greatswords
    BastardSword,
    Claymore,
    ManserpentGreatsword,
    Flamberge,
    CrystalGreatsword,
    StoneGreatsword,

    // TODO
    GreatswordOfArtorias,
    MoonlightGreatsword,
    BlackKnightSword,

    // TODO
    GreatswordOfArtoriasCursed,
    GreatLordGreatsword,

    // Ultra Greatswords
    Zweihander,
    Greatsword,
    DemonGreatMachete,
    DragonGreatsword,
    BlackKnightGreatsword,

    // Curved Swords
    Scimitar,
    Falchion,
    Shotel,
    JaggedGhostBlade,
    PaintingGuardianSword,
    QuelaagsFurysword,

    // Curved Greatswords
    Server,
    Murakumo,
    GravelordSword,

    // Katanas
    Uchigatana,
    WashingPole,
    Iaito,
    ChaosBlade,

    // Piercing Swords
    MailBreaker,
    Rapier,
    Estoc,
    VelkasRapier,
    RicardsRapier,

    // Axes
    HandAxe,
    BattleAxe,
    CrescentAxe,
    ButcherKnife,
    GolemAxe,
    GargoyleTailAxe,

    // Greataxes
    Greataxe,
    DemonsGreataxe,
    DragonKingGreataxe,
    BlackKnightGreataxe,

    // Hammers
    Club,
    Mace,
    MorningStar,
    Warpick,
    Pickaxe,
    ReinforcedClub,
    BlacksmithHammer,
    BlacksmithGiantHammer,
    HammerOfVamos,

    // Great Hammers
    GreatClub,
    Grant,
    DemonsGreatHammer,
    DragonTooth,
    LargeClub,
    SmoughsHammer,

    // Fist Weapons
    Caestus,
    Claw,
    DragonBoneFist,
    DarkHand,

    // Spears
    Spear,
    WingedSpear,
    Partizan,
    DemonsSpear,
    ChannelersTrident,
    SilverKnightSpear,
    Pike,
    DragonslayerSpear,
    MoonlightButterflyHorn,

    // Halberds
    Halberd,
    GiantsHalberd,
    TitaniteCatchPole,
    GargoylesHalberd,
    BlackKnightHalberd,
    Lucerne,
    Scythe,
    GreatScythe,
    LifehuntScythe,

    // Bows
    Shortbow,
    Longbow,
    BlackBowOfPharis,
    DragonslayerGreatbow,
    CompositeBow,
    DarkmoonBow,

    // Crossbows
    LightCrossbow,
    HeavyCrossbow,
    Avelyn,
    SniperCrossbow,

    // Catalysts
    SorcerersCatalyst,
    BeatricesCatalyst,
    TinBanishmentCatalyst,
    LogansCatalyst,
    TinDarkmoonCatalyst,
    OolacileIvoryCatalyst,
    TinCrystallizationCatalyst,
    DemonsCatalyst,
    IzalithCatalyst,

    // Pyromancy Flames
    PyromancyFlame,
    PyromancyFlameAscended,

    // Talismans
    Talisman,
    CanvasTalisman,
    ThorolundTalisman,
    IvoryTalisman,
    SunlightTalisman,
    DarkmoonTalisman,
    VelkasTalisman,

    SkullLantern,

    // Whips
    Whip,
    NotchedWhip,


    // Shields
    // Standard Shields
    EastWestShield,
    WoodenShield,
    LargeLeatherShield,
    SmallLeatherShield,
    TargetShield,
    Buckler,
    CrackedRoundShield,
    LeatherShield,
    PlankShield,
    CaduceusRoundShield,
    CrystalRingShield,

    // Standard Shields
    HeaterShield,
    KnightShield,
    TowerKiteShield,
    GrassCrestShield,
    HollowSoldierShield,
    BalderShield,
    CrestShield,
    DragonCrestShield,
    WarriorsRoundShield,
    IronRoundShield,
    SpiderShield,
    SpikedShield,
    CrystalShield,
    SunlightShield,
    SilverKnightShield,
    BlackKnightShield,
    PierceShield,
    RedAndWhiteRoundShield,
    CaduceusKiteShield,
    GargoylesShield,
    
    // Greatshields
    EagleShield,
    TowerShield,
    GiantShield,
    StoneGreatshield,
    HavelsGreatshield,
    BonewheelShield,
    GreatshieldOfArtorias,
    EffigyShield,
    Sanctus,
    Bloodshield,
    BlackIronGreatshield,
    
    // DLC Weapon
    AbyssGreatsword,
    StoneGreataxe,
    FourProngedPlow,
    OolacileCatalyst,
    GuardianTail,
    GoldTracer,
    DarkSilverTracer,
    CleansingGreatshield,
    ManusCatalyst,
    ObsidianGreatsword,
    GoughsGreatbow,

    // Ammunition
    // Arrows
    StandardArrow,
    LargeArrow,
    FeatherArrow,
    FireArrow,
    PoisonArrow,
    MoonlightArrow,
    WoodenArrow,
    DragonslayerArrow,
    
    GoughsGreatArrow,
    
    // Bolts
    StandardBolt,
    HeavyBolt,
    SniperBolt,
    WoodBolt,
    LightningBolt,

    
    // Rings
    HavelsRing,
    RedTearstoneRing,
    DarkmoonBladeCovenantRing,
    CatCovenantRing,
    CloranthyRing,
    FlameStoneplateRing,
    ThunderStoneplateRing,
    SpellStoneplateRing,
    SpeckledStoneplateRing,
    BloodbiteRing,
    PoisonbiteRing,
    TinyBeingsRing,
    CursebiteRing,
    WhiteSeanceRing,
    BellowingDragoncrestRing,
    DuskCrownRing,
    HornetRing,
    HawkRing,
    RingOfSteelProtection,
    CovetousGoldSerpentRing,
    CovetousSilverSerpentRing,
    SlumberingDragoncrestRing,
    RingOfFog,
    RustedIronRing,
    RingOfSacrifice,
    RareRingOfSacrifice,
    DarkWoodGrainRing,
    RingOfTheSunPrincess,
    OldWitchsRing,
    CovenantOfArtorias,
    OrangeCharredRing,
    LingeringDragoncrestRing,
    RingOfTheEvilEye,
    RingOfFavorAndProtection,
    LeoRing,
    EastWoodGrainRing,
    WolfRing,
    BlueTearstoneRing,
    RingOfTheSunsFirstborn,
    DarkmoonSeanceRing,
    
    CalamityRing,


    // Items
    WhiteSignSoapstone,
    RedSignSoapstone,
    RedEyeOrb,
    BlackSeparationCrystal,
    OrangeGuidanceSoapstone,
    BookOfTheGuilty,
    EyeOfDeath,
    CrackedRedEyeOrb,
    ServantRoster,
    BlueEyeOrb,
    DragonEye,
    BlackEyeOrb,
    BlackEyeOrbShiva,       // Unoptainable
    Darksign,
    EstusFlask,
    DivineBlessing,
    GreenBlossom,
    BloodredMossClump,
    PurpleMossClump,
    BloomingPurpleMossClump,
    PurgingStone,
    EggVermifuge,
    RepairPowder,
    ThrowingKnife,
    PoisonThrowingKnife,
    Firebomb,
    DungPie,
    AlluringSkull,
    LloydsTalisman,
    BlackFirebomb,
    CharcoalPineResin,
    GoldPineResin,
    TransientCurse,
    RottenPineResin,
    HomewardBone,
    PrismStone,
    Binoculars,
    Indictment,
    SouvenirOfReprisal,
    SunlightMedal,
    Pendant,
    DragonHeadStone,
    DragonTorsoStone,
    Rubbish,
    CopperCoin,
    SilverCoin,
    GoldCoin,
    DriedFinger,
    
    PurpleCowardsCrystal,
    SilverPendant,
    ElizabethsMushroom,
    HelloCarving,
    ThankYouCarving,
    VeryGoodCarving,
    ImSorryCarving,
    HelpMeCarving,
    
    FireKeeperSoulAnastaciaOfAstora,
    FireKeeperSoulDarkmoonKnightess,
    FireKeeperSoulQuelaagsSister,
    FireKeeperSoulNewLondoRuins,
    FireKeeperSoulBlighttown,
    FireKeeperSoulTheDukesArchives,
    FireKeeperSoulUndeadParish,
    SoulOfALostUndead,
    LargeSoulOfALostUndead,
    SoulOfANamelessSoldier,
    LargeSoulOfANamelessSoldier,
    SoulOfAProudKnight,
    LargeSoulOfAProudKnight,
    SoulOfABraveWarrior,
    LargeSoulOfABraveWarrior,
    SoulOfAHero,
    SoulOfAGreatHero,
    Humanity,
    TwinHumanities,
    SoulOfQuelaag,
    SoulOfSif,
    SoulOfGwyn,
    CoreOfAnIronGolem,
    SoulOfOrnstein,
    SoulOfTheMoonlightButterfly,
    SoulOfSmough,
    SoulOfPriscilla,
    SoulOfGwyndolin,
    
    // DLC
    GuardiansSoul,
    SoulOfArtorias,
    SoulOfManus,
    
    // Upgrade Materials
    TitaniteShard,
    LargeTitaniteShard,
    GreenTitaniteShard,
    TitaniteChunk,
    BlueTitaniteChunk,
    WhiteTitaniteChunk,
    RedTitaniteChunk,
    TitaniteSlab,
    BlueTitaniteSlab,
    WhiteTitaniteSlab,
    RedTitaniteSlab,
    DragonScale,
    DemonTitanite,
    TwinklingTitanite,


    // Spells
    // Sorceries
    SoulArrow,
    GreatSoulArrow,
    HeavySoulArrow,
    GreatHeavySoulArrow,
    HomingSoulmass,
    HomingCrystalSoulmass,
    SoulSpear,
    CrystalSoulSpear,
    MagicWeapon,
    GreatMagicWeapon,
    CrystalMagicWeapon,
    MagicShield,
    StrongMagicShield,
    HiddenWeapon,
    HiddenBody,
    CastLight,
    Hush,
    AuralDecoy,
    Repair,
    FallControl,
    Chameleon,
    ResistCurse,
    Remedy,
    WhiteDragonBreath,
    
    // Pyromancies
    Fireball,
    FireOrb,
    GreatFireball,
    Firestorm,
    FireTempest,
    FireSurge,
    FireWhip,
    Combustion,
    GreatCombustion,
    PoisonMist,
    ToxicMist,
    AcidSurge,
    IronFlesh,
    FlashSweat,
    UndeadRapport,
    PowerWithin,
    GreatChaosFireball,
    ChaosStorm,
    ChaosFireWhip,
    
    // Miracles
    Heal,
    GreatHeal,
    GreatHealExcerpt,
    SoothingSunlight,
    Replenishment,
    BountifulSunlight,
    GravelordSwordDance,
    GravelordGreatswordDance,
    EscapeDeath,        // Unoptainable
    Homeward,
    Force,
    WrathOfTheGods,
    EmitForce,
    SeekGuidance,
    LightningSpear,
    GreatLightningSpear,
    SunlightSpear,
    MagicBarrier,
    GreatMagicBarrier,
    KarmicJustice,
    TranquilWalkOfPeace,
    VowOfSilence,
    SunlightBlade,
    DarkmoonBlade,
    
    // DLC
    DarkOrb,
    DarkBead,
    DarkFog,
    Pursuers,
    BlackFlame,

}