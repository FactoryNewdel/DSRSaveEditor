namespace DSR.SlotDetailsDefinition;

public class Location
{
    private static readonly Dictionary<byte, Dictionary<byte, string>> _locations = new ()
    {
        {10, new Dictionary<byte, string>
        {
            { 0, "Depths" },
            { 1, "Undead Parish" },
            { 2, "Firelink Shrine" },
        }},
        {11, new Dictionary<byte, string>
        {
            { 0, "Painted World" },
        }},
        {12, new Dictionary<byte, string>
        {
            { 0, "Darkroot Garden" },
            { 1, "Oolacile" },
        }},
        {13, new Dictionary<byte, string>
        {
            { 0, "Catacombs" },
            { 1, "Tomb of the Giants" },
            { 2, "Ash Lake" },
        }},
        {14, new Dictionary<byte, string>
        {
            { 0, "15 FPS Town" },
            { 1, "Demon Ruins" },
        }},
        {15, new Dictionary<byte, string>
        {
            { 0, "Takeshi's Castle" },
            { 1, "Anal Rodeo" },
        }},
        {16, new Dictionary<byte, string>
        {
            { 0, "Ghost Town" },
        }},
        {17, new Dictionary<byte, string>
        {
            { 0, "Duke's Archive" },
        }},
        {18, new Dictionary<byte, string>
        {
            { 0, "Kiln of the First Flame" },
            { 1, "Undead Asylum" },
        }},
    };

    public static string GetLocation(byte worldPrimary, byte worldSecondary)
    {
        if (_locations.ContainsKey(worldPrimary))
        {
            ;
        }
        if (!_locations.TryGetValue(worldPrimary, out var dict)) return "";
        if (!dict.TryGetValue(worldSecondary, out var name)) return "";
        return name;
    }
}