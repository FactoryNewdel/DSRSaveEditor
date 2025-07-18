﻿namespace DSR.SavefileStructure;

public class SaveSlotHeader
{
    private UInt32 _const0;
    private UInt32 _const1;
    private UInt32 _slotSize;
    private UInt32 _const2;
    private UInt32 _offset;
    private UInt32 _titleOffset;
    private UInt32 _paddingSize;
    private UInt32 _const3;

    public SaveSlotHeader(byte[] data)
    {
        _const0 = BitConverter.ToUInt32(new[] { data[0], data[1], data[2], data[3] });
        if (_const0 != 0x50) throw new Exception("Invalid Const0");
        _const1 = BitConverter.ToUInt32(new[] { data[4], data[5], data[6], data[7] });
        if (_const1 != 0xFFFFFFFF) throw new Exception("Invalid Const1");
        
        _slotSize = BitConverter.ToUInt32(new[] { data[8], data[9], data[10], data[11] });
        if (_slotSize != 0x60030) throw new Exception("Invalid SlotSize");
        
        _const2 = BitConverter.ToUInt32(new[] { data[12], data[13], data[14], data[15] });
        if (_const2 != 0) throw new Exception("Invalid Const2");
        
        _offset = BitConverter.ToUInt32(new[] { data[16], data[17], data[18], data[19] });
        _titleOffset = BitConverter.ToUInt32(new[] { data[20], data[21], data[22], data[23] });
        
        _paddingSize = BitConverter.ToUInt32(new[] { data[24], data[25], data[26], data[27] });
        if (_paddingSize != 0) throw new Exception("Invalid Padding Size");
        
        _const3 = BitConverter.ToUInt32(new[] { data[28], data[29], data[30], data[31] });
        if (_const3 != 0) throw new Exception("Invalid Const3");
    }
    
    public byte[] ToBytes()
    {
        var bytes = new byte[32];

        Array.Copy(BitConverter.GetBytes(_const0)     , 0, bytes,  0,  4);
        Array.Copy(BitConverter.GetBytes(_const1)     , 0, bytes,  4,  4);
        Array.Copy(BitConverter.GetBytes(_slotSize)   , 0, bytes,  8,  4);
        Array.Copy(BitConverter.GetBytes(_const2)     , 0, bytes, 12,  4);
        Array.Copy(BitConverter.GetBytes(_offset)     , 0, bytes, 16,  4);
        Array.Copy(BitConverter.GetBytes(_titleOffset), 0, bytes, 20,  4);
        Array.Copy(BitConverter.GetBytes(_paddingSize), 0, bytes, 24,  4);
        Array.Copy(BitConverter.GetBytes(_const3)     , 0, bytes, 28,  4);

        return bytes;
    }

    public uint Size => _slotSize;

    public uint Offset => _offset;

    public uint TitleOffset => _titleOffset;

    public uint PaddingSize => _paddingSize;
}