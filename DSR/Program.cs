// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using DSR.SavefileStructure;

class Program
{
    static string dir = @"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\296043893";
    static string path = Path.Join(dir, "DRAKS0005.sl2");

    static byte[] _key =
        { 0x1, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };

    private static byte[] _iv;


    public static void Main(string[] args)
    {
        var j = 0;

        /*foreach (var b in File.ReadAllBytes(path))
        {
            Console.Write($"{(b > 32 && b < 126 ? (char)b : b)} ");
            if (++j == 704) break;
        }*/

        Console.WriteLine();

        Console.WriteLine(File.ReadAllBytes(path).Length);
        Console.WriteLine(0x4204D0);

        //var testpath = @"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\296043893\USER_DATA1.soul";
        var testpath = @"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\296043893\USER_DATA1.soul2";
        var testpath1 = @"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\296043893\USER_DATA1.soul";
        var bb = File.ReadAllBytes(testpath);
        var bc = File.ReadAllBytes(testpath1);

        Console.WriteLine("Compare");
        for (var i = 0; i < bb.Length; i++)
        {
            //if (bb[i] != bc[i]) Console.Write($"[{i}]: {bb[i]} -> {bc[i]}\t");
        }
        
        Console.WriteLine("Compare Again");
        for (var i = 0; i < bb.Length; i += 4)
        {
            //var first = BitConverter.ToUInt32(bb.Skip(i).Take(4).ToArray());
            //var second = BitConverter.ToUInt32(bc.Skip(i).Take(4).ToArray());
            //if (first != second) Console.Write($"[{i}]: {first} -> {second}\t");
        }
        
        
        var bbb = File.ReadAllBytes(@"C:\Users\Tim\Downloads\USER_DATA001");
        foreach (var b in bbb)
        {
            //Console.Write($"{(b > 32 && b < 126 ? (char)b : b)} ");
        }

        Console.WriteLine("Souls");
        for (var i = 0; i < bb.Length; i += 4)
        {
            var a = BitConverter.ToUInt32(bb.Skip(i).Take(4).ToArray());
            var b = BitConverter.ToUInt32(bb.Skip(i).Take(4).Reverse().ToArray());
            var c = BitConverter.ToInt32(bb.Skip(i).Take(4).ToArray());
            var d = BitConverter.ToInt32(bb.Skip(i).Take(4).Reverse().ToArray());
            if (a == 5228274) Console.WriteLine("a: " + i);
            if (b == 5228274) Console.WriteLine("b: " + i);
            if (c == 5228274) Console.WriteLine("c: " + i);
            if (d == 5228274) Console.WriteLine("d: " + i);
        } 
        
        Console.WriteLine("Name");
        var str = File.ReadAllText(testpath);
        Console.WriteLine("Pls = " + str.Contains("Dalai-Alpaka", StringComparison.InvariantCultureIgnoreCase));

        //if (true) Environment.Exit(1337);

//Console.WriteLine(DecryptStringFromBytes_Aes(File.ReadAllBytes(path).Skip(16).ToArray(), key));
        //File.WriteAllBytes(Path.Join(dir, "test.txt"), DecryptStringFromBytes_Aes(File.ReadAllBytes(path), key));
        const uint SAVE_FILE_SIZE = 0x4204D0;
        const uint SAVE_SLOT_SIZE = 0x060030;
        const uint BASE_SLOT_OFFSET = 0x02C0;
        const uint USER_DATA_SIZE = 0x060020;
        const uint USER_DATA_FILE_COUNT = 11;
        const uint USER_DATA_FILE_NAME_LENGTH = 13;

        var bytes = File.ReadAllBytes(path);

        var saveFile = new SaveFile(bytes);

        for (var i = 0;
             i < USER_DATA_FILE_COUNT;
             i++)
        {
            var curPointer = BASE_SLOT_OFFSET + i * SAVE_SLOT_SIZE;
            var decrypted = DecryptStringFromBytes_Aes(bytes.Skip((int)curPointer).Take((int)SAVE_SLOT_SIZE).ToArray());
            var encrypted = EncryptStringToBytes_Aes(decrypted, _key, _iv);
            

            var safePath = Path.Join(dir, $"USER_DATA{i}.soul");
            File.WriteAllBytes(safePath, decrypted);
            
        }
    }

    private static int f = 0;

    static byte[] DecryptStringFromBytes_Aes(byte[] cipherText)
    {
        // Declare the string used to hold 
        // the decrypted text. 
        byte[] decrypted = null;

        // Create an Aes object 
        // with the specified key and IV. 
        using Aes aesAlg = Aes.Create();

        aesAlg.Key = _key;

        aesAlg.IV = cipherText.Take(16).ToArray();
        Console.WriteLine("IV = " + BitConverter.ToString(aesAlg.IV));
        _iv = aesAlg.IV;

        var cipherText1 = cipherText.Skip(16).ToArray();

        aesAlg.Mode = CipherMode.CBC;

        var decrypt = aesAlg.DecryptCbc(cipherText1, _iv);
        var encrypt = aesAlg.EncryptCbc(decrypt, _iv);

        //File.WriteAllBytes(@"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\296043893\Plt" + f, cipherText1);
        //File.WriteAllBytes(@"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\296043893\Pls" + f++, encrypt);
        using var md5 = MD5.Create();
        /*Console.WriteLine(cipherText.Length);
        Console.WriteLine(cipherText1.Length);
        Console.WriteLine(decrypt.Length);
        Console.WriteLine(0x5FFFC);
        Console.WriteLine(0x5FFFC + 4 + 16);
        Console.WriteLine(0x60030);
        var length = BitConverter.ToUInt32(decrypt.Skip(16).Take(4).ToArray());
        Console.WriteLine(length);
        var hash = md5.ComputeHash(decrypt.Skip(16).Take((int)length + 4).ToArray());

        Console.WriteLine("MD5");
        foreach (var b in hash)
        {
            Console.Write(b + " ");
        }

        Console.WriteLine();

        Console.WriteLine("Actual Checksum");
        foreach (var b in decrypt.Take(16).ToArray())
        {
            Console.Write(b + " ");
        }

        Console.WriteLine();
        foreach (var b in cipherText1.Take(16).ToArray())
        {
            Console.Write(b + " ");
        }

        Console.WriteLine();*/

        for (var i = 0; i < decrypt.Length; i++)
        {
            //Console.WriteLine($"{cipherText[i]} = {encrypt[i]}");
        }


        return decrypt;
    }
    
    static byte[] EncryptStringToBytes_Aes(byte[] plainText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");
        byte[] encrypted;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }
}