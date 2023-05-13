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
    
    
    
    public static StatInformation HPCurrent => new (96, 4);
    
    public static StatInformation HPTotalUnmodified => new (100, 4);
    
    public static StatInformation HPTotalModified => new (104, 4);

    

    public static StatInformation StaminaCurrent => new (96, 4);
    
    public static StatInformation StaminaTotalUnmodified => new (100, 4);
    
    public static StatInformation StaminaTotalModified => new (104, 4);



    public static StatInformation Playtime => new (8, 4);
    
    
    
    public static StatInformation WorldPrimary => new (6, 1);
        
    public static StatInformation WorldSecondary => new (7, 1);
}