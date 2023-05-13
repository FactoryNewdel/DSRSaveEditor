namespace DSR.Utils;

public class DetailComparer
{
    private static byte[] _known;

    public static void Init(int size)
    {
        _known = new byte[size];
    }
    
    public static void Add(StatInformation info)
    {
        for (int i = 0, offset = info.Offset; i < info.Length; i++)
        {
            _known[i + offset] = 0xFF;
        }
    }
    
    public static byte[] KnownBytes => _known;
}