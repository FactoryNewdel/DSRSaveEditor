using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Aes = System.Security.Cryptography.Aes;

namespace DSR.SavefileStructure;

public class SaveSlot
{
    private static readonly byte[] Key = { 0x1, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
    private Aes _aes;

    private byte[] _iv;
    private byte[] _checksum;
    private UInt32 _remainingSize; // 0x60030 - IV - Checksum - Footer
    private SaveSlotDetails _details; // Actual save file details
    private byte[] _footerPadding;

    public SaveSlot(byte[] data)
    {
        _checksum = data.Take(16).ToArray();
        _iv = data.Skip(16).Take(16).ToArray();

        _aes = Aes.Create();
        _aes.IV = _iv;
        _aes.Key = Key;

        var decrypted = _aes.DecryptCbc(data.Skip(32).ToArray(), _iv, PaddingMode.None);
        
        _remainingSize = BitConverter.ToUInt32(decrypted.Skip(0).Take(4).ToArray());
        _details = new SaveSlotDetails(decrypted.Skip(4).Take(0x5FFFC).ToArray());
        _footerPadding = decrypted.Skip(4 + 0x5FFFC).Take(16).ToArray();
    }

    public byte[] ToBytes()
    {
        var bytes = new byte[0x60030];

        Array.Copy(_iv                                  , 0, bytes,  16, 16);

        var decrypted = new byte[0x60030 - 32];
        Array.Copy(BitConverter.GetBytes(_remainingSize), 0, decrypted, 0,  4);
        Array.Copy(_details.Bytes                       , 0, decrypted, 4, 0x5FFFC);
        Array.Copy(_footerPadding                       , 0, decrypted, 4 + 0x5FFFC, 16);

        Array.Copy(_aes.EncryptCbc(decrypted, _iv, PaddingMode.None), 0, bytes, 32, decrypted.Length);
        
        var md5 = MD5.Create();
        md5.TransformFinalBlock(bytes, 16, 16 + 20 + 0x5FFFC);
        Array.Copy(md5.Hash          , 0, bytes,  0,  16);

        _aes.Dispose();
        
        return bytes;
    }

    public uint Length => 0x60030;

    public byte[] Iv => _iv;

    public byte[] Checksum => _checksum;

    public uint RemainingSize => _remainingSize;

    public SaveSlotDetails Details => _details;

    public byte[] FooterPadding => _footerPadding;
}