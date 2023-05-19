namespace DSR.Utils;

public class DetailComparer
{
    private static byte[] _known;

    public static void Init(int size)
    {
        _known = new byte[size];
    }
    
    public static void Add(int offset, int length)
    {
        for (int i = 0; i < length; i++)
        {
            _known[i + offset] = 0xFF;
        }
    }

    public static void Add(StatInformation info)
    {
        Add(info.Offset, info.Length);
    }
    
    public static byte[] KnownBytes => _known;
}