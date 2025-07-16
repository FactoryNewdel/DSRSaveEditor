using DSR.Utils;

namespace DSR.SlotDetails;

public class Progress
{
    private byte[] _data;

    private int _sectionOffset;
    private byte[][] _sections;

    public Progress(byte[] bytes)
    {
        _data = bytes;
        
        _sectionOffset = BitConverter.ToInt32(_data, 60);
        _sections = GetSections(_sectionOffset);

        var length = 0;

        foreach (var section in _sections)
        {
            length += section.Length;
        }

        DetailComparer.Add(_sectionOffset, length);

        for (int i = 0; i < _sections[8].Length - 19; i += 20)
        {
            //Console.WriteLine(i + " -> ID: " + BitConverter.ToUInt32(_sections[8], i + 8) + " | " + BitConverter.ToString(BitConverter.GetBytes(BitConverter.ToUInt32(_sections[8], i + 8))) + ", Strength: " + _sections[8][i + 12]);
        }
    }

    private byte[][] GetSections(int startOffset)
    {
        var output = new byte[16][];

        var sectionOffset = startOffset;

        var length0 = BitConverter.ToInt32(_data, sectionOffset);
        output[0] = _data.Skip(sectionOffset + 4).Take(length0).ToArray();
        sectionOffset += 4 + length0;
        
        var length1 = BitConverter.ToInt32(_data, sectionOffset);
        output[1] = _data.Skip(sectionOffset + 4).Take(length1).ToArray();
        sectionOffset += 4 + length1;
        
        // Offset 0 Length 4 -> x
        // Offset 4 Length 4 -> y
        // Offset 8 Length 4 -> z
        // Offset 20 Length 4 -> yaw
        var length2 = 88;
        output[2] = _data.Skip(sectionOffset).Take(length2).ToArray();
        sectionOffset += length2;
        
        var length3 = BitConverter.ToInt32(_data, sectionOffset);
        output[3] = _data.Skip(sectionOffset + 4).Take(length3).ToArray();
        sectionOffset += 4 + length3 + 4;
        
        var length4 = BitConverter.ToInt32(_data, sectionOffset);
        output[4] = _data.Skip(sectionOffset + 4).Take(length4).ToArray();
        sectionOffset += 4 + length4 + 4;
        
        var length5 = BitConverter.ToInt32(_data, sectionOffset);
        output[5] = _data.Skip(sectionOffset + 4).Take(length5).ToArray();
        sectionOffset += 4 + length5 + 4;
        
        var length6 = BitConverter.ToInt32(_data, sectionOffset);
        output[6] = _data.Skip(sectionOffset + 4).Take(length6).ToArray();
        sectionOffset += 4 + length6 + 4;
        
        var length7 = BitConverter.ToInt32(_data, sectionOffset);
        output[7] = _data.Skip(sectionOffset + 4).Take(length7).ToArray();
        sectionOffset += 4 + length7 + 4;
        
        var length8 = BitConverter.ToInt32(_data, sectionOffset);
        output[8] = _data.Skip(sectionOffset + 4).Take(length8).ToArray();
        sectionOffset += 4 + length8 + 4;
        
        var length9 = BitConverter.ToInt32(_data, sectionOffset);
        output[9] = _data.Skip(sectionOffset + 4).Take(length9).ToArray();
        sectionOffset += 4 + length9 + 4;
        
        var length10 = BitConverter.ToInt32(_data, sectionOffset);
        output[10] = _data.Skip(sectionOffset + 4).Take(length10).ToArray();
        sectionOffset += 4 + length10 + 4;
        
        var length11 = BitConverter.ToInt32(_data, sectionOffset);
        output[11] = _data.Skip(sectionOffset + 4).Take(length11).ToArray();
        sectionOffset += 4 + length11 + 4;
        
        var length12 = BitConverter.ToInt32(_data, sectionOffset);
        output[12] = _data.Skip(sectionOffset + 4).Take(length12).ToArray();
        sectionOffset += 4 + length12 + 4;
        
        var length13 = BitConverter.ToInt32(_data, sectionOffset);
        output[13] = _data.Skip(sectionOffset + 4).Take(length13).ToArray();
        sectionOffset += 4 + length13 + 4;
        
        var length14 = BitConverter.ToInt32(_data, sectionOffset);
        output[14] = _data.Skip(sectionOffset + 4).Take(length14).ToArray();
        sectionOffset += 4 + length14 + 4;
        
        var length15 = BitConverter.ToInt32(_data, sectionOffset);
        output[15] = _data.Skip(sectionOffset + 4).Take(length15).ToArray();
        
        return output;
    }

    public int SectionOffset => _sectionOffset;
    
    public byte[][] Sections => _sections;
}