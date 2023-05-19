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

        for (int i = 0; i < _sections[8].Length - 19; i += 20)
        {
            Console.WriteLine(i + " -> ID: " + BitConverter.ToUInt32(_sections[8], i + 8) + " | " + BitConverter.ToString(BitConverter.GetBytes(BitConverter.ToUInt32(_sections[8], i + 8))) + ", Strength: " + _sections[8][i + 12]);
        }
    }

    private byte[][] GetSections(int startOffset)
    {
        var output = new byte[10][];

        var sectionOffset = startOffset;

        var lengthFirst = BitConverter.ToInt32(_data, sectionOffset);
        output[0] = _data.Skip(sectionOffset + 4).Take(lengthFirst).ToArray();
        sectionOffset += 4 + lengthFirst;
        
        var lengthSecond = BitConverter.ToInt32(_data, sectionOffset);
        output[1] = _data.Skip(sectionOffset + 4).Take(lengthSecond).ToArray();
        sectionOffset += 4 + lengthSecond;
        
        // Offset 0 Length 4 -> x
        // Offset 4 Length 4 -> y
        // Offset 8 Length 4 -> z
        // Offset 20 Length 4 -> yaw
        var lengthThird = 88;
        output[2] = _data.Skip(sectionOffset).Take(lengthThird).ToArray();
        sectionOffset += lengthThird;
        
        var lengthFourth = BitConverter.ToInt32(_data, sectionOffset);
        output[3] = _data.Skip(sectionOffset + 4).Take(lengthFourth).ToArray();
        sectionOffset += 4 + lengthFourth + 4;
        
        var lengthFifth = BitConverter.ToInt32(_data, sectionOffset);
        output[4] = _data.Skip(sectionOffset + 4).Take(lengthFifth).ToArray();
        sectionOffset += 4 + lengthFifth + 4;
        
        var lengthSixth = BitConverter.ToInt32(_data, sectionOffset);
        output[5] = _data.Skip(sectionOffset + 4).Take(lengthSixth).ToArray();
        sectionOffset += 4 + lengthSixth + 4;
        
        var lengthSeventh = BitConverter.ToInt32(_data, sectionOffset);
        output[6] = _data.Skip(sectionOffset + 4).Take(lengthSeventh).ToArray();
        sectionOffset += 4 + lengthSeventh + 4;
        
        var lengthEight = BitConverter.ToInt32(_data, sectionOffset);
        output[7] = _data.Skip(sectionOffset + 4).Take(lengthEight).ToArray();
        sectionOffset += 4 + lengthEight + 4;
        
        var lengthNinth = BitConverter.ToInt32(_data, sectionOffset);
        output[8] = _data.Skip(sectionOffset + 4).Take(lengthNinth).ToArray();
        sectionOffset += 4 + lengthNinth + 4;
        
        var lengthTenth = BitConverter.ToInt32(_data, sectionOffset);
        output[9] = _data.Skip(sectionOffset + 4).Take(lengthTenth).ToArray();

        return output;
    }

    public int SectionOffset => _sectionOffset;
    
    public byte[][] Sections => _sections;
}