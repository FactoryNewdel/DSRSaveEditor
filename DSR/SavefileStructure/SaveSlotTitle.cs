using System.Text;

namespace DSR.SavefileStructure;

public class SaveSlotTitle
{
    private byte[] _prefixBytes;
    private string _prefix;
    private byte[] _indexBytes;
    private string _index;
    private byte[] _terminatorBytes;
    private string _terminator;

    private static string _validPrefix = new StringBuilder("U").Append((char)0).Append('S').Append((char)0).Append('E').Append((char)0).Append('R').Append((char)0).Append('_').Append((char)0).Append('D').Append((char)0).Append('A').Append((char)0).Append('T').Append((char)0).Append('A').Append((char)0).ToString();

    public SaveSlotTitle(byte[] data)
    {
        _prefixBytes = new[] { data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10], data[11], data[12], data[13], data[14], data[15], data[16], data[17] };
        _prefix = Encoding.Default.GetString(_prefixBytes);
        if (!_prefix.Equals(_validPrefix)) throw new Exception($"Invalid prefix: {_prefix}");

        _indexBytes = new[] { data[18], data[19], data[20], data[21], data[22], data[23] };
        _index = Encoding.Default.GetString(_indexBytes);
        if (!_index.StartsWith(new StringBuilder("0").Append((char)0).ToString())) throw new Exception("Invalid Index");

        _terminatorBytes = new []{ data[24], data[25] };
        _terminator = Encoding.Default.GetString(_terminatorBytes);
        if (!_terminator.Equals(new StringBuilder().Append((char)0).Append((char)0).ToString())) throw new Exception("Invalid Terminator");
    }
    
    public byte[] ToBytes()
    {
        var bytes = new byte[26];

        Array.Copy(_prefixBytes    , 0, bytes,   0,  18);
        Array.Copy(_indexBytes     , 0, bytes,  18,   6);
        Array.Copy(_terminatorBytes, 0, bytes,  24,   2);

        return bytes;
    }

    public string Prefix => _prefix;

    public string Index => _index;

    public string Terminator => _terminator;
}