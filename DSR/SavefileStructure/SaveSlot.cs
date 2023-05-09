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
    private byte[] _realIv;
    private byte[] _realChecksum;
    private byte[] _checksum;
    private UInt32 _remainingSize; // 0x60030 - IV - Checksum - Footer
    private byte[] _details; // Actual save file details
    private byte[] _footerPadding;

    private enum Indices
    {
        Iv = 0,
        Checksum = 0,
        RemainingSize = 16,
        Details = 20,
        FooterPadding = 20 + Lengths.Details
    }

    private enum Lengths
    {
        Iv = 16,
        Checksum = 16,
        RemainingSize = 4,
        Details = 393212,
        FooterPadding = 16
    }

    private static int i = 0;

    public SaveSlot(byte[] data)
    {
        _iv = data.Skip(16).Take(16).ToArray();
        _realChecksum = data.Take(16).ToArray();

        _aes = Aes.Create();
        _aes.IV = _iv;
        _aes.Key = Key;

        Console.WriteLine(data.Length);
        Console.WriteLine(0x60030);
        var decrypted = _aes.DecryptCbc(data.Skip(32).ToArray(), _iv, PaddingMode.None);
        Console.WriteLine(decrypted.Length);
        Console.WriteLine(16 + 4 + 0x5FFFC + 16);
        
        _checksum = decrypted.Take(16).ToArray();
        _realIv = data.Skip(16).Take(16).ToArray();
        _remainingSize = BitConverter.ToUInt32(decrypted.Skip(0).Take(4).ToArray());
        _details = decrypted.Skip(4).Take(0x5FFFC).ToArray();
        _footerPadding = decrypted.Skip(4 + 0x5FFFC).Take(16).ToArray();
        Console.WriteLine(_footerPadding.Length);
        
        Console.WriteLine("------SaveSlot------");
        Console.WriteLine("IV = " + BitConverter.ToString(_iv));
        Console.WriteLine("Checksum encrypted  = " + BitConverter.ToString(data.Skip(16).Take(16).ToArray()));
        Console.WriteLine("Checksum decryptedN = " + BitConverter.ToString(_checksum));
        Console.WriteLine("Checksum decryptedE = " + BitConverter.ToString(decrypted.Skip(decrypted.Length - 16).Take(16).ToArray()));

        Console.WriteLine(BitConverter.ToString(MD5.Create().ComputeHash(decrypted.Skip(16).ToArray())));
        var dex = decrypted.Length - 1;
        //decrypted[dex] = (byte)(decrypted[dex] == 0 ? 0xFF : 0);
        Console.WriteLine(BitConverter.ToString(MD5.Create().ComputeHash(decrypted.Skip(16).ToArray())));
        
        
        //if (true) return;
        var checksum = decrypted.Take(16).ToArray();
        var checksumXor = new byte[16];
        var checksumAnd = new byte[16];
        var checksumOr = new byte[16];
        var checksumXorFooter = new byte[16];
        for (var i = 0; i < checksum.Length; i++)
        {
            checksumXor[i] = (byte)(checksum[i] ^ _iv[i]);
        }
        for (var i = 0; i < checksum.Length; i++)
        {
            checksumAnd[i] = (byte)(checksum[i] & _iv[i]);
        }
        for (var i = 0; i < checksum.Length; i++)
        {
            checksumOr[i] = (byte)(checksum[i] | _iv[i]);
        }
        for (var i = 0; i < checksum.Length; i++)
        {
            //checksumXorFooter[i] = (byte)(checksum[i] ^ _footerPadding[i]);
        }
        Console.WriteLine("Checksum XOR        = " + BitConverter.ToString(checksumXor));
        Console.WriteLine("Checksum AND        = " + BitConverter.ToString(checksumAnd));
        Console.WriteLine("Checksum  OR        = " + BitConverter.ToString(checksumOr));
        Console.WriteLine("ChecksumXXOR        = " + BitConverter.ToString(checksumXorFooter));
        /*for (var skip = 0; skip < 40; skip++)
        {
            for (var take = 0; take < 0x60030; take++)
            {
                if (skip + take > decrypted.Length) continue;
                var check = MD5.Create().ComputeHash(decrypted, skip, take);
                if (check[0] == 0x89 && check[1] == 0xE3 && check[2] == 0x3D) Console.WriteLine(BitConverter.ToString(check));
                if (check[0] == 0xAD && check[1] == 0xE1 && check[2] == 0x51) Console.WriteLine(BitConverter.ToString(check));
                if (check[0] == 0xD6 && check[1] == 0x11 && check[2] == 0x30) Console.WriteLine(BitConverter.ToString(check));
            }
        }*/

        var relevantDe = decrypted.Skip(20).Take(0x5FFFC).ToArray();
        var xorDe = new byte[relevantDe.Length];
        var relevantEn = data.Skip(36).Take(0x5FFFC).ToArray();
        var xorEn = new byte[relevantEn.Length];
        
        for (int i = 0, j = 0; i < relevantDe.Length; i++, j++)
        {
            if (j == 16) j = 0;
            //xorDe[i] = (byte)(relevantDe[i] ^ _footerPadding[j]);
        }

        for (int i = 0, j = 0; i < relevantEn.Length; i++, j++)
        {
            if (j == 16) j = 0;
            //xorEn[i] = (byte)(relevantEn[i] ^ _footerPadding[j]);
        }

        Console.WriteLine(_remainingSize);
        Console.WriteLine((int)Lengths.Details);
        Console.WriteLine(data.Length);
        using var md5 = MD5.Create();
        using var sha256 = SHA256.Create();
        
        Console.WriteLine($"Slot Hash Encrypted All                          = {BitConverter.ToString(md5.ComputeHash(data.Skip(0).Take(0x60030).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted All                          = {BitConverter.ToString(md5.ComputeHash(data))}");
        Console.WriteLine($"Slot Hash Encrypted All                          = {BitConverter.ToString(md5.ComputeHash(data.Take(16).Skip(16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIv                     = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksum             = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(4 + 0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksum             = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLength       = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take(0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLength       = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLengthFooter = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take(0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumFooter       = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumFooter       = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(0x60014).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvAndFooter            = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).Take(16 + 4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(data.Skip(0).Take(16 + 16 + 4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIv                     = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).Take(16 + 4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksum             = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLength       = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take((int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLengthFooter = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take((int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumFooter       = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvAndFooter            = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).Take(16 + 4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(data.Skip(0).Take(16 + 16 + 4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted XOR                          = {BitConverter.ToString(md5.ComputeHash(xorEn))}");
        
        Console.WriteLine($"Slot Hash Decrypted All                          = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksum               = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLength         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take((int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLengthFooter   = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take((int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumFooter         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted All                          = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + 0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted All                          = {BitConverter.ToString(md5.ComputeHash(decrypted))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksum               = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + 0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksum               = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + 0x5FFFC + 4).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksum               = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(0x60014).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksum               = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLength         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take(0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLength         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take(0x5FFFC + 4).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLength         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLengthFooter   = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take(0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumFooter         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted XOR                          = {BitConverter.ToString(md5.ComputeHash(xorDe))}");

        var newhash = md5.ComputeHash(decrypted.Skip(16).ToArray());
        var newhash1 = sha256.ComputeHash(decrypted.Skip(16).ToArray());
        Console.WriteLine("ReHash  = " + BitConverter.ToString(newhash));
        Console.WriteLine("ReHash1 = " + BitConverter.ToString(newhash1));
        Console.WriteLine("Re      = " + BitConverter.ToString(md5.ComputeHash(_aes.EncryptCbc(decrypted, newhash))));
        Console.WriteLine("Re      = " + BitConverter.ToString(md5.ComputeHash(_aes.EncryptCbc(decrypted, _iv, PaddingMode.None))));
        Console.WriteLine("Re      = " + BitConverter.ToString(md5.ComputeHash(_iv.Concat(_aes.EncryptCbc(decrypted, _iv, PaddingMode.None)).ToArray())));
        //Console.WriteLine("Re1     = " + BitConverter.ToString(sha256.ComputeHash(aes.EncryptCbc(decrypted, newhash1))));
        //Console.WriteLine("Re1     = " + BitConverter.ToString(sha256.ComputeHash(aes.EncryptCbc(decrypted, _iv))));
        
        File.WriteAllBytes("USERDATA00" + ii++, decrypted);
        File.WriteAllText("BUSERDATA00" + ij++, BitConverter.ToString(decrypted.Skip(16).ToArray()));
        Console.WriteLine("--------------------");


        if (BitConverter.ToUInt32(_details.Skip(224).Take(4).ToArray()) == 5228274)
        {
            Console.WriteLine("Hii");
            var souls = new byte[] { 0x69, 0x18, 0x71, 0x87 };
        
            _details[224] = 0x01;
            _details[225] = 0x01;
            _details[226] = 0x01;
            _details[227] = 0x01;
        }
        if (BitConverter.ToUInt32(_details.Skip(391584).Take(4).ToArray()) == 5228274)
        {
            Console.WriteLine("Hiii");
            var souls = new byte[] { 0x69, 0x18, 0x71, 0x87 };

            _details[391584] = 0x01;
            _details[391585] = 0x01;
            _details[391586] = 0x01;
            _details[391587] = 0x01;
        }
    }

    private static int ii = 0;
    private static int ij = 0;
    
    public byte[] ToBytes()
    {
        var bytes = new byte[0x60030];

        Array.Copy(_realIv                              , 0, bytes,  16, 16);

        var decrypted = new byte[0x60030 - 32];
        Array.Copy(BitConverter.GetBytes(_remainingSize), 0, decrypted, 0,  4);
        Array.Copy(_details                             , 0, decrypted, 4, 0x5FFFC);
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

    public byte[] Details => _details;

    public byte[] FooterPadding => _footerPadding;
}