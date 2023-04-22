using System.Security.Cryptography;

namespace DSR.SavefileStructure;

public class SaveSlot
{
    private static readonly byte[] Key = { 0x1, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
    
    private byte[] _iv;
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
        Details = 0x5FFFC,
        FooterPadding = 16
    }

    public SaveSlot(byte[] data)
    {
        _iv = data.Take((int)Lengths.Iv).ToArray();

        using var aes = Aes.Create();
        aes.IV = _iv;
        aes.Key = Key;

        var decrypted = aes.DecryptCbc(data.Skip(16).ToArray(), _iv);
        
        _checksum = data.Skip(16).Take((int)Lengths.Checksum).ToArray();
        Console.WriteLine("------SaveSlot------");
        Console.WriteLine("IV = " + BitConverter.ToString(_iv));
        Console.WriteLine("Checksum encrypted  = " + BitConverter.ToString(_checksum));
        Console.WriteLine("Checksum decryptedN = " + BitConverter.ToString(decrypted.Take(16).ToArray()));
        
        _remainingSize = BitConverter.ToUInt32(decrypted.Skip((int)Indices.RemainingSize).Take((int)Lengths.RemainingSize).ToArray());
        Console.WriteLine(_remainingSize);
        Console.WriteLine((int)Lengths.Details);
        using var md5 = MD5.Create();
        Console.WriteLine($"Slot Hash Encrypted All                          = {BitConverter.ToString(md5.ComputeHash(data.Skip(0).Take(0x60030).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIv                     = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).Take(16 + 4 + 0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksum             = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(4 + 0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLength       = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take(0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLengthFooter = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take(0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumFooter       = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvAndFooter            = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).Take(16 + 4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(data.Skip(0).Take(16 + 16 + 4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIv                     = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).Take(16 + 4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksum             = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take(4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLength       = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take((int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumLengthFooter = {BitConverter.ToString(md5.ComputeHash(data.Skip(36).Take((int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvChecksumFooter       = {BitConverter.ToString(md5.ComputeHash(data.Skip(32).Take((int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButIvAndFooter            = {BitConverter.ToString(md5.ComputeHash(data.Skip(16).Take(16 + 4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Encrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(data.Skip(0).Take(16 + 16 + 4 + (int)_remainingSize).ToArray()))}");
        
        Console.WriteLine($"Slot Hash Decrypted All                          = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksum               = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + (int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLength         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take((int)_remainingSize + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLengthFooter   = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take((int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumFooter         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + (int)_remainingSize).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted All                          = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + 0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksum               = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + 0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLength         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take(0x5FFFC + 16).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumLengthFooter   = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(20).Take(0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButChecksumFooter         = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(16).Take(4 + 0x5FFFC).ToArray()))}");
        Console.WriteLine($"Slot Hash Decrypted AllButFooter                 = {BitConverter.ToString(md5.ComputeHash(decrypted.Skip(0).Take(16 + 4 + 0x5FFFC).ToArray()))}");

        var newhash = md5.ComputeHash(decrypted.Skip(16).ToArray());
        Console.WriteLine("ReHash = " + BitConverter.ToString(newhash));
        Console.WriteLine("Re     = " + BitConverter.ToString(md5.ComputeHash(aes.EncryptCbc(decrypted, newhash))));
        Console.WriteLine("Re     = " + BitConverter.ToString(md5.ComputeHash(aes.EncryptCbc(decrypted, _iv))));
        
        File.WriteAllBytes("USERDATA00" + ii++, decrypted);
        Console.WriteLine("--------------------");
    }

    private static int ii = 0;
}