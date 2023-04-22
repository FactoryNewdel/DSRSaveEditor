using System.Text;

namespace DSR.SavefileStructure;

public class SaveSlotTitle
{
    private string _prefix;
    private string _index;
    private string _terminator;

    private static string _validPrefix = new StringBuilder("U").Append((char)0).Append('S').Append((char)0).Append('E').Append((char)0).Append('R').Append((char)0).Append('_').Append((char)0).Append('D').Append((char)0).Append('A').Append((char)0).Append('T').Append((char)0).Append('A').Append((char)0).ToString();

    public SaveSlotTitle(byte[] data)
    {
        _prefix = Encoding.Default.GetString(new []{ data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10], data[11], data[12], data[13], data[14], data[15], data[16], data[17] });
        if (!_prefix.Equals(_validPrefix)) throw new Exception($"Invalid prefix: {_prefix}");
        _index = Encoding.Default.GetString(new []{ data[18], data[19], data[20], data[21], data[22], data[23] });
        if (!_index.StartsWith(new StringBuilder("0").Append((char)0).ToString())) throw new Exception("Invalid Index");
        _terminator = Encoding.Default.GetString(new []{ data[24], data[25] });
        if (!_terminator.Equals(new StringBuilder().Append((char)0).Append((char)0).ToString())) throw new Exception("Invalid Terminator");
    }

    public string Prefix => _prefix;

    public string Index => _index;

    public string Terminator => _terminator;
}