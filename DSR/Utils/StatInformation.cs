namespace DSR.Utils;

public class StatInformation
{
    private int _offset;
    private int _length;

    public StatInformation(int offset, int length)
    {
        _offset = offset;
        _length = length;
    }

    public int Offset => _offset;

    public int Length => _length;
}