namespace DSR.SlotDetails.InventoryDetails.Items;

public class BossWeapon : Weapon
{
    private uint _originalItemID;
    private ItemType _originalItemType;

    // Inventory
    public BossWeapon(uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base(0, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        _originalItemID = (id - (id / 10000 * 10000)) / 100;
        Infusion = Infusion.None;
        _originalItemType = GetOriginalItem();
        if (sorting != GetSortingID()) Console.WriteLine($"INVALID BOSSWEAPON SORTING for {Type} ({id}): expected {BitConverter.ToString(BitConverter.GetBytes(GetSortingID()).Reverse().ToArray())} but got {BitConverter.ToString(BitConverter.GetBytes(sorting).Reverse().ToArray())}");
    }
    
    // Inventory for items with ids reaching another id
    public BossWeapon(ItemType type, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base(type, 0, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        _originalItemID = (id - (id / 10000 * 10000)) / 100;
        Infusion = Infusion.None;
        _originalItemType = GetOriginalItem();
        if (sorting != GetSortingID()) Console.WriteLine($"INVALID BOSSWEAPON SORTING for {Type} ({id}): expected {BitConverter.ToString(BitConverter.GetBytes(GetSortingID()).Reverse().ToArray())} but got {BitConverter.ToString(BitConverter.GetBytes(sorting).Reverse().ToArray())}");
    }

    // Item List
    public BossWeapon(ItemType type, byte idSpace, uint id, uint durability, WeaponUpgradeType weaponUpgradeType) : base(type, idSpace, id, 1, durability, weaponUpgradeType)
    {
        _originalItemID = (id - (id / 10000 * 10000)) / 100;
        Infusion = Infusion.None;
        _originalItemType = GetOriginalItem();
        Sorting = GetSortingID();
    }

    public BossWeapon(BossWeapon bossWeapon) : base(bossWeapon)
    {
        _originalItemType = bossWeapon._originalItemType;
    }

    private ItemType GetOriginalItem()
    {
        if (Type == ItemType.MoonlightButterflyHorn)
        {
            switch (_originalItemID)
            {
                case 20: return ItemType.MailBreaker;
                case 21: return ItemType.Rapier;
                case 22: return ItemType.Estoc;
                case 23: return ItemType.Spear;
                case 24: return ItemType.WingedSpear;
                case 25: return ItemType.Partizan;
                case 28: return ItemType.Pike;
                case 29: return ItemType.RicardsRapier;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.MailBreaker;
            }
        }

        if (Type == ItemType.CrystalRingShield)
        {
            switch (_originalItemID)
            {
                case 10: return ItemType.EastWestShield;
                case 11: return ItemType.WoodenShield;
                case 12: return ItemType.PlankShield;
                case 13: return ItemType.LargeLeatherShield;
                case 14: return ItemType.SmallLeatherShield;
                case 15: return ItemType.LeatherShield;
                case 16: return ItemType.TargetShield;
                case 17: return ItemType.Buckler;
                case 18: return ItemType.CrackedRoundShield;
                case 19: return ItemType.CaduceusRoundShield;
                case 20: return ItemType.HeaterShield;
                case 21: return ItemType.KnightShield;
                case 22: return ItemType.TowerKiteShield;
                case 23: return ItemType.GrassCrestShield;
                case 24: return ItemType.HollowSoldierShield;
                case 25: return ItemType.BalderShield;
                case 26: return ItemType.WarriorsRoundShield;
                case 27: return ItemType.IronRoundShield;
                case 28: return ItemType.SpiderShield;
                case 29: return ItemType.SpikedShield;
                case 30: return ItemType.PierceShield;
                case 31: return ItemType.SunlightShield;
                case 32: return ItemType.RedAndWhiteRoundShield;
                case 33: return ItemType.CaduceusKiteShield;
                case 34: return ItemType.GargoylesShield;
                case 35: return ItemType.EagleShield;
                case 36: return ItemType.TowerShield;
                case 37: return ItemType.GiantShield;
                case 38: return ItemType.BonewheelShield;
                case 39: return ItemType.EffigyShield;
                case 40: return ItemType.Sanctus;
                case 41: return ItemType.Bloodshield;
                case 42: return ItemType.BlackIronGreatshield;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.EastWestShield;
            }
        }

        if (Type == ItemType.QuelaagsFurysword)
        {
            switch (_originalItemID)
            {
                case 60: return ItemType.Scimitar;
                case 61: return ItemType.Falchion;
                case 62: return ItemType.Shotel;
                case 63: return ItemType.PaintingGuardianSword;
                case 64: return ItemType.Server;
                case 65: return ItemType.Murakumo;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Scimitar;
            }
        }

        if (Type == ItemType.ChaosBlade)
        {
            switch (_originalItemID)
            {
                case 30: return ItemType.Uchigatana;
                case 31: return ItemType.WashingPole;
                case 32: return ItemType.Iaito;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Uchigatana;
            }
        }

        if (Type == ItemType.DragonBoneFist)
        {
            switch (_originalItemID)
            {
                case 30: return ItemType.Caestus;
                case 31: return ItemType.Claw;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Caestus;
            }
        }

        if (Type == ItemType.GolemAxe)
        {
            switch (_originalItemID)
            {
                case 40: return ItemType.HandAxe;
                case 41: return ItemType.BattleAxe;
                case 43: return ItemType.ButcherKnife;
                case 44: return ItemType.GargoyleTailAxe;
                case 46: return ItemType.DemonsGreataxe;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.HandAxe;
            }
        }

        if (Type == ItemType.DragonslayerSpear)
        {
            switch (_originalItemID)
            {
                case 10: return ItemType.MailBreaker;
                case 11: return ItemType.Rapier;
                case 12: return ItemType.Estoc;
                case 13: return ItemType.Spear;
                case 14: return ItemType.WingedSpear;
                case 15: return ItemType.Partizan;
                case 18: return ItemType.Pike;
                case 19: return ItemType.RicardsRapier;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.MailBreaker;
            }
        }

        if (Type == ItemType.SmoughsHammer)
        {
            switch (_originalItemID)
            {
                case 60: return ItemType.Club;
                case 61: return ItemType.Mace;
                case 62: return ItemType.MorningStar;
                case 63: return ItemType.Warpick;
                case 64: return ItemType.Pickaxe;
                case 65: return ItemType.ReinforcedClub;
                case 66: return ItemType.BlacksmithHammer;
                case 69: return ItemType.GreatClub;
                case 70: return ItemType.DemonsGreatHammer;
                case 71: return ItemType.LargeClub;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Club;
            }
        }

        if (Type == ItemType.GreatswordOfArtorias)
        {
            switch (_originalItemID)
            {
                case 70: return ItemType.BrokenStraightSword;
                case 71: return ItemType.StraightSwordHilt;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.BrokenStraightSword;
            }
        }
        
        if (Type == ItemType.GreatswordOfArtoriasCursed)
        {
            switch (_originalItemID)
            {
                case 10: return ItemType.Dagger;
                case 11: return ItemType.ParryingDagger;
                case 12: return ItemType.BanditsKnife;
                case 13: return ItemType.Shortsword;
                case 14: return ItemType.Longsword;
                case 15: return ItemType.Broadsword;
                case 16: return ItemType.BalderSideSword;
                case 17: return ItemType.SunlightStraightSword;
                case 18: return ItemType.BarbedStraightSword;
                case 20: return ItemType.Darksword;
                case 21: return ItemType.BastardSword;
                case 22: return ItemType.Claymore;
                case 23: return ItemType.ManserpentGreatsword;
                case 24: return ItemType.Flamberge;
                case 25: return ItemType.Zweihander;
                case 26: return ItemType.Greatsword;
                case 27: return ItemType.DemonGreatMachete;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Dagger;
            }
        }
        
        if (Type == ItemType.GreatshieldOfArtorias)
        {
            switch (_originalItemID)
            {
                case 70: return ItemType.EastWestShield;
                case 71: return ItemType.WoodenShield;
                case 72: return ItemType.PlankShield;
                case 73: return ItemType.LargeLeatherShield;
                case 74: return ItemType.SmallLeatherShield;
                case 75: return ItemType.LeatherShield;
                case 76: return ItemType.TargetShield;
                case 77: return ItemType.Buckler;
                case 78: return ItemType.CrackedRoundShield;
                case 79: return ItemType.CaduceusRoundShield;
                case 80: return ItemType.HeaterShield;
                case 81: return ItemType.KnightShield;
                case 82: return ItemType.TowerKiteShield;
                case 83: return ItemType.GrassCrestShield;
                case 84: return ItemType.HollowSoldierShield;
                case 85: return ItemType.BalderShield;
                case 86: return ItemType.WarriorsRoundShield;
                case 87: return ItemType.IronRoundShield;
                case 88: return ItemType.SpiderShield;
                case 89: return ItemType.SpikedShield;
                case 90: return ItemType.PierceShield;
                case 91: return ItemType.SunlightShield;
                case 92: return ItemType.RedAndWhiteRoundShield;
                case 93: return ItemType.CaduceusKiteShield;
                case 94: return ItemType.GargoylesShield;
                case 95: return ItemType.EagleShield;
                case 96: return ItemType.TowerShield;
                case 97: return ItemType.GiantShield;
                case 98: return ItemType.BonewheelShield;
                case 99: return ItemType.EffigyShield;
                case 0: return ItemType.Sanctus;
                case 1: return ItemType.Bloodshield;
                case 2: return ItemType.BlackIronGreatshield;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.EastWestShield;
            }
        }

        if (Type == ItemType.DarkmoonBow)
        {
            switch (_originalItemID)
            {
                case 50: return ItemType.Shortbow;
                case 51: return ItemType.CompositeBow;
                case 52: return ItemType.Longbow;
                case 53: return ItemType.BlackBowOfPharis;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Shortbow;
            }
        }
        
        if (Type == ItemType.TinDarkmoonCatalyst)
        {
            switch (_originalItemID)
            {
                case 40: return ItemType.SorcerersCatalyst;
                case 41: return ItemType.BeatricesCatalyst;
                case 42: return ItemType.TinBanishmentCatalyst;
                case 43: return ItemType.LogansCatalyst;
                case 44: return ItemType.OolacileCatalyst;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.SorcerersCatalyst;
            }
        }
        
        if (Type == ItemType.LifehuntScythe)
        {
            switch (_originalItemID)
            {
                case 10: return ItemType.Halberd;
                case 11: return ItemType.Lucerne;
                case 12: return ItemType.Scythe;
                case 14: return ItemType.GargoylesHalberd;
                case 15: return ItemType.GreatScythe;
                case 16: return ItemType.Whip;
                case 17: return ItemType.NotchedWhip;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Halberd;
            }
        }

        if (Type == ItemType.GreatLordGreatsword)
        {
            switch (_originalItemID)
            {
                case 40: return ItemType.Dagger;
                case 41: return ItemType.ParryingDagger;
                case 42: return ItemType.BanditsKnife;
                case 43: return ItemType.Shortsword;
                case 44: return ItemType.Longsword;
                case 45: return ItemType.Broadsword;
                case 46: return ItemType.BalderSideSword;
                case 47: return ItemType.SunlightStraightSword;
                case 48: return ItemType.BarbedStraightSword;
                case 50: return ItemType.Darksword;
                case 51: return ItemType.BastardSword;
                case 52: return ItemType.Claymore;
                case 53: return ItemType.ManserpentGreatsword;
                case 54: return ItemType.Flamberge;
                case 55: return ItemType.Zweihander;
                case 56: return ItemType.Greatsword;
                case 57: return ItemType.DemonGreatMachete;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Dagger;
            }
        }

        if (Type == ItemType.ManusCatalyst)
        {
            switch (_originalItemID)
            {
                case 70: return ItemType.SorcerersCatalyst;
                case 71: return ItemType.BeatricesCatalyst;
                case 72: return ItemType.TinBanishmentCatalyst;
                case 73: return ItemType.LogansCatalyst;
                case 74: return ItemType.OolacileCatalyst;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.SorcerersCatalyst;
            }
        }
        
        if (Type == ItemType.AbyssGreatsword)
        {
            switch (_originalItemID)
            {
                case 20: return ItemType.Dagger;
                case 21: return ItemType.ParryingDagger;
                case 22: return ItemType.BanditsKnife;
                case 23: return ItemType.Shortsword;
                case 24: return ItemType.Longsword;
                case 25: return ItemType.Broadsword;
                case 26: return ItemType.BalderSideSword;
                case 27: return ItemType.SunlightStraightSword;
                case 28: return ItemType.BarbedStraightSword;
                case 30: return ItemType.Darksword;
                case 31: return ItemType.BastardSword;
                case 32: return ItemType.Claymore;
                case 33: return ItemType.ManserpentGreatsword;
                case 34: return ItemType.Flamberge;
                case 35: return ItemType.Zweihander;
                case 36: return ItemType.Greatsword;
                case 37: return ItemType.DemonGreatMachete;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return ItemType.Dagger;
            }
        }
        
        Console.WriteLine($"INVALID Type {Type}");
        return ItemType.UNKNOWN;
    }

    private uint GetSortingID()
    {
        if (Type == ItemType.MoonlightButterflyHorn)
        {
            switch (_originalItemID)
            {
                case 20: return 0x15FF40;
                case 21: return 0x163DC0;
                case 22: return 0x167C40;
                case 23: return 0x223440;
                case 24: return 0x2272C0;
                case 25: return 0x22B140;
                case 28: return 0x232E40;
                case 29: return 0x16BAC0;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x15FF40;            

            }
        }
        
        if (Type == ItemType.CrystalRingShield)
        {
            switch (_originalItemID)
            {
                case 10: return 0x382D40;
                case 11: return 0x386BC0;
                case 12: return 0x344540;
                case 13: return 0x38AA40;
                case 14: return 0x3483C0;
                case 15: return 0x34C240;
                case 16: return 0x353F40;
                case 17: return 0x3500C0;
                case 18: return 0x341340;
                case 19: return 0x3389C0;
                case 20: return 0x38E8C0;
                case 21: return 0x39E2C0;
                case 22: return 0x392740;
                case 23: return 0x3A9E40;
                case 24: return 0x39A440;
                case 25: return 0x3A2DC0;
                case 26: return 0x334B40;
                case 27: return 0x3AE940;
                case 28: return 0x3A5FC0;
                case 29: return 0x3B9840;
                case 30: return 0x3B59C0;
                case 31: return 0x3B1B40;
                case 32: return 0x33EDC0;
                case 33: return 0x3965C0;
                case 34: return 0x3BD6C0;
                case 35: return 0x3F8040;
                case 36: return 0x3FBEC0;
                case 37: return 0x4009C0;
                case 38: return 0x403BC0;
                case 39: return 0x33C840;
                case 40: return 0x3A0840;
                case 41: return 0x3AC3C0;
                case 42: return 0x3FE440;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x382D40;            
            }
        }
        
        if (Type == ItemType.QuelaagsFurysword)
        {
            switch (_originalItemID)
            {
                case 60: return 0x0EAC40;
                case 61: return 0x0F0A00;
                case 62: return 0x0F2940;
                case 63: return 0x0F67C0;
                case 64: return 0x115BC0;
                case 65: return 0x111D40;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x0EAC40;
            }
        }
        
        if (Type == ItemType.ChaosBlade)
        {
            switch (_originalItemID)
            {
                case 30: return 0x138E40;
                case 31: return 0x140B40;
                case 32: return 0x13CCC0;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x138E40;
            }
        }
        
        if (Type == ItemType.DragonBoneFist)
        {
            switch (_originalItemID)
            {
                case 30: return 0x2ABFC0;
                case 31: return 0x2AFE40;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x2ABFC0;
            }
        }
        
        if (Type == ItemType.GolemAxe)
        {
            switch (_originalItemID)
            {
                case 40: return 0x187040;
                case 41: return 0x18AEC0;
                case 43: return 0x18ED40;
                case 44: return 0x192BC0;
                case 46: return 0x1B1FC0;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x187040;
            }
        }
        
        if (Type == ItemType.DragonslayerSpear)
        {
            switch (_originalItemID)
            {
                case 10: return 0x15FF40;
                case 11: return 0x163DC0;
                case 12: return 0x167C40;
                case 13: return 0x223440;
                case 14: return 0x2272C0;
                case 15: return 0x22B140;
                case 18: return 0x232E40;
                case 19: return 0x16BAC0;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x15FF40;
            }
        }
        
        if (Type == ItemType.SmoughsHammer)
        {
            switch (_originalItemID)
            {
                case 60: return 0x1D3F80;
                case 61: return 0x1DCF40;
                case 62: return 0x1E0DC0;
                case 63: return 0x1E4C40;
                case 64: return 0x1E8AC0;
                case 65: return 0x1D5240;
                case 66: return 0x1EC940;
                case 69: return 0x2001C0;
                case 70: return 0x204040;
                case 71: return 0x1FC340;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x1D3F80;
            }
        }
        
        if (Type == ItemType.GreatswordOfArtorias)
        {
            switch (_originalItemID)
            {
                case 70: return 0x0526C0;
                case 71: return 0x056540;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x0526C0;
            }
        }

        if (Type == ItemType.GreatswordOfArtoriasCursed)
        {
            switch (_originalItemID)
            {
                case 10: return 0x000640;
                case 11: return 0x0044C0;
                case 12: return 0x008340;
                case 13: return 0x027740;
                case 14: return 0x02B5C0;
                case 15: return 0x02F440;
                case 16: return 0x0332C0;
                case 17: return 0x037140;
                case 18: return 0x042CC0;
                case 20: return 0x03EE40;
                case 21: return 0x075940;
                case 22: return 0x0797C0;
                case 23: return 0x07D640;
                case 24: return 0x0814C0;
                case 25: return 0x0C79C0;
                case 26: return 0x0C3B40;
                case 27: return 0x0CB840;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x000640;
            }
        }
        
        if (Type == ItemType.GreatshieldOfArtorias)
        {
            switch (_originalItemID)
            {
                case 70: return 0x382D40;
                case 71: return 0x386BC0;
                case 72: return 0x344540;
                case 73: return 0x38AA40;
                case 74: return 0x3483C0;
                case 75: return 0x34C240;
                case 76: return 0x353F40;
                case 77: return 0x3500C0;
                case 78: return 0x341340;
                case 79: return 0x3389C0;
                case 80: return 0x38E8C0;
                case 81: return 0x39E2C0;
                case 82: return 0x392740;
                case 83: return 0x3A9E40;
                case 84: return 0x39A440;
                case 85: return 0x3A2DC0;
                case 86: return 0x334B40;
                case 87: return 0x3AE940;
                case 88: return 0x3A5FC0;
                case 89: return 0x3B9840;
                case 90: return 0x3B59C0;
                case 91: return 0x3B1B40;
                case 92: return 0x33EDC0;
                case 93: return 0x3965C0;
                case 94: return 0x3BD6C0;
                case 95: return 0x3F8040;
                case 96: return 0x3FBEC0;
                case 97: return 0x4009C0;
                case 98: return 0x403BC0;
                case 99: return 0x33C840;
                case 0: return 0x3A0840;
                case 1: return 0x3AC3C0;
                case 2: return 0x3FE440;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x382D40;            
            }
        }
        
        if (Type == ItemType.DarkmoonBow)
        {
            switch (_originalItemID)
            {
                case 50: return 0x2BF840;
                case 51: return 0x2C36C0;
                case 52: return 0x2C7540;
                case 53: return 0x2CB3C0;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x2BF840;
            }
        }
        
        if (Type == ItemType.TinDarkmoonCatalyst)
        {
            switch (_originalItemID)
            {
                case 40: return 0x30DA40;
                case 41: return 0x30E080;
                case 42: return 0x30FFC0;
                case 43: return 0x30E6C0;
                case 44: return 0x30ED00;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x30DA40;
            }
        }
        
        if (Type == ItemType.LifehuntScythe)
        {
            switch (_originalItemID)
            {
                case 10: return 0x24A540;
                case 11: return 0x24E3C0;
                case 12: return 0x252240;
                case 14: return 0x2560C0;
                case 15: return 0x271640;
                case 16: return 0x298740;
                case 17: return 0x29C5C0;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x24A540;
            }
        }
        
        if (Type == ItemType.GreatLordGreatsword)
        {
            switch (_originalItemID)
            {
                case 40: return 0x000640;
                case 41: return 0x0044C0;
                case 42: return 0x008340;
                case 43: return 0x027740;
                case 44: return 0x02B5C0;
                case 45: return 0x02F440;
                case 46: return 0x0332C0;
                case 47: return 0x037140;
                case 48: return 0x042CC0;
                case 50: return 0x03EE40;
                case 51: return 0x075940;
                case 52: return 0x0797C0;
                case 53: return 0x07D640;
                case 54: return 0x0814C0;
                case 55: return 0x0C79C0;
                case 56: return 0x0C3B40;
                case 57: return 0x0CB840;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x000640;
            }
        }
        
        if (Type == ItemType.ManusCatalyst)
        {
            switch (_originalItemID)
            {
                case 70: return 0x30DA40;
                case 71: return 0x30E080;
                case 72: return 0x30FFC0;
                case 73: return 0x30E6C0;
                case 74: return 0x30ED00;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x30DA40;
            }
        }

        if (Type == ItemType.AbyssGreatsword)
        {
            switch (_originalItemID)
            {
                case 20: return 0x000640;
                case 21: return 0x0044C0;
                case 22: return 0x008340;
                case 23: return 0x027740;
                case 24: return 0x02B5C0;
                case 25: return 0x02F440;
                case 26: return 0x0332C0;
                case 27: return 0x037140;
                case 28: return 0x042CC0;
                case 30: return 0x03EE40;
                case 31: return 0x075940;
                case 32: return 0x0797C0;
                case 33: return 0x07D640;
                case 34: return 0x0814C0;
                case 35: return 0x0C79C0;
                case 36: return 0x0C3B40;
                case 37: return 0x0CB840;
                default:
                    Console.WriteLine($"INVALID OriginalItem for {Type}: {_originalItemID}");
                    return 0x000640;
            }
        }

        Console.WriteLine($"INVALID Type {Type}");
        return 0;
    }

    public ItemType OriginalItemType => _originalItemType;
}