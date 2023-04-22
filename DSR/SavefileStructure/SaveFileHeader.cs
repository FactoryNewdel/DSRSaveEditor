namespace DSR.SavefileStructure;

public class SaveFileHeader
{
    private UInt32 _bnd4; // "BND4" | 0x34444E42
    private UInt32 _magic1;
    private UInt32 _magic2;
    private UInt32 _slotCount;
    private UInt32 _const0;
    private UInt32 _const1;
    private UInt32 _const2;
    private UInt32 _const3;
    private UInt32 _slotHeaderSize;
    private UInt32 _const4;
    private UInt32 _size;
    private UInt32 _const5;
    private UInt32 _const6;
    private byte[] _padding;

    public SaveFileHeader(byte[] data)
    {
        _bnd4 = BitConverter.ToUInt32(new[] { data[0], data[1], data[2], data[3] });
        if (_bnd4 != 0x34444E42) throw new Exception("Invalid BND");
        
        _magic1 = BitConverter.ToUInt32(new[] { data[4], data[5], data[6], data[7] });
        if (_magic1 != 0) throw new Exception("Invalid Magic1");
        _magic2 = BitConverter.ToUInt32(new[] { data[8], data[9], data[10], data[11] });
        if (_magic2 != 0x10000) throw new Exception("Invalid Magic2");
        
        _slotCount = BitConverter.ToUInt32(new[] { data[12], data[13], data[14], data[15] });
        if (_slotCount != 11) throw new Exception("Invalid Slot Count");
        
        _const0 = BitConverter.ToUInt32(new[] { data[16], data[17], data[18], data[19] });
        if (_const0 != 0x40) throw new Exception("Invalid Const0");
        _const1 = BitConverter.ToUInt32(new[] { data[20], data[21], data[22], data[23] });
        if (_const1 != 0) throw new Exception("Invalid Const1");
        _const2 = BitConverter.ToUInt32(new[] { data[24], data[25], data[26], data[27] });
        if (_const2 != 0) throw new Exception("Invalid Const2");
        _const3 = BitConverter.ToUInt32(new[] { data[28], data[29], data[30], data[31] });
        if (_const3 != 0) throw new Exception("Invalid Const3");
        
        _slotHeaderSize = BitConverter.ToUInt32(new[] { data[32], data[33], data[34], data[35] });
        if (_slotHeaderSize != 0x20) throw new Exception("Invalid SlotHeaderSize");
        
        _const4 = BitConverter.ToUInt32(new[] { data[36], data[37], data[38], data[39] });
        if (_const4 != 0) throw new Exception("Invalid Const4");
        
        _size = BitConverter.ToUInt32(new[] { data[40], data[41], data[42], data[43] });
        if (_size != 0x2C0) throw new Exception("Invalid Size");
        
        _const5 = BitConverter.ToUInt32(new[] { data[44], data[45], data[46], data[47] });
        if (_const5 != 0) throw new Exception("Invalid Const5");
        _const6 = BitConverter.ToUInt32(new[] { data[48], data[49], data[50], data[51] });
        if (_const6 != 0x2001) throw new Exception("Invalid Const6");

        _padding = new byte[12];
        for (var i = 0; i < 12; i++)
        {
            var b = data[52 + i];
            _padding[i] = b;
            if (b != 0) throw new Exception("Invalid padding byte");
        }
    }

    public int Length => 64;
}