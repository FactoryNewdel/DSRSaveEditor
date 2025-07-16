using DSR.Utils;

namespace DSR.SlotDetailsDefinition;

public class CharacterStatsDefinition
{
    public static StatInformation Level => new (220, 4);
    
    public static StatInformation Name => new (244, -1);
    
    
    public static StatInformation Vitality => new (140, 4);
    
    public static StatInformation Attunement => new (148, 4);
    
    public static StatInformation Endurance => new (156, 4);
    
    public static StatInformation Strength => new (164, 4);
    
    public static StatInformation Dexterity => new (172, 4);
    
    public static StatInformation Intelligence => new (180, 4);
    
    public static StatInformation Faith => new (188, 4);
    
    public static StatInformation Resistance => new (212, 4);
    
    
    
    public static StatInformation Humanity => new (208, 4);
    
    public static StatInformation CurrentSouls => new (224, 4);
    
    public static StatInformation TotalSouls => new (228, 4);

    
    
    public static StatInformation Deaths => new (127428, 4);

    

    public static StatInformation HPCurrent => new (96, 4);
    
    public static StatInformation HPTotalUnmodified => new (100, 4);
    
    public static StatInformation HPTotalModified => new (104, 4);

    public static StatInformation FPCurrent => new (108, 4);
    
    public static StatInformation FPUnmodified => new (112, 4);
    
    public static StatInformation FPTotalModified => new (116, 4);
    
    public static StatInformation StaminaCurrent => new (124, 4);
    
    public static StatInformation StaminaTotalUnmodified => new (128, 4);
    
    public static StatInformation StaminaTotalModified => new (132, 4);



    public static StatInformation Playtime => new (8, 4);
    
    
    
    public static StatInformation WorldPrimary => new (7, 1);
        
    public static StatInformation WorldSecondary => new (6, 1);
    
    
    // true = male
    public static StatInformation Gender => new (278, 1);
    
    /*
     * 0 -> Warrior
     * 1 -> Knight
     * 2 -> Wanderer
     * 3 -> Thief
     * 4 -> Bandit
     * 5 -> Hunter
     * 6 -> Sorcerer
     * 7 -> Pyromancer
     * 8 -> Cleric
     * 9 -> Deprived
     */
    public static StatInformation StarterClass => new (282, 1);
    
    /*
     * 0 -> Average
     * 1 -> Slim
     * 2 -> Very Slim
     * 3 -> Large
     * 4 -> Very Large
     * 5 -> Large Upper Body
     * 6 -> Large Lower Body
     * 7 -> Top-heavy
     * 8 -> Tiny head
     * 9 -> 
     */
    public static StatInformation Physique => new (283, 1);
    
    /*
     * 0 -> None
     * 1 -> Goddess's Blessing
     * 2 -> Black Firebomb
     * 3 -> Twin Humanities
     * 4 -> Binoculars
     * 5 -> Pendant
     * 6 -> Master Key
     * 7 -> Tiny Being's Ring
     * 8 -> Old Witch's Ring
     * 9 -> 
     */
    public static StatInformation StartingGift => new (284, 1);
    
    public static StatInformation CharacterCustomizationBlock => new (58400, 100);
    
    
    // Bit3
    public static StatInformation GameExitedProperly => new (131360, 1);


}