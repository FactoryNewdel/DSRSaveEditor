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
        //var data = File.ReadAllBytes(@"C:\Users\Tim\Documents\NBGI\DarkSouls\DRAKS0005.sl2");
        var data = File.ReadAllBytes(path);
        
        Console.WriteLine(BitConverter.ToString(data.Skip(0x300).Take(0x30F - 0x300 + 1).ToArray()));
        Console.WriteLine(BitConverter.ToString(MD5.Create().ComputeHash(data.Skip(0x310).Take(0x10030F - 0x310 + 1).ToArray())));

        Console.WriteLine(BitConverter.ToUInt32(data.Skip(64 + 16).Take(4).ToArray()));
        var slot = data.Skip(704).Take(0x60014).ToArray();
        Console.WriteLine(BitConverter.ToString(slot.Take(16).ToArray()));
        Console.WriteLine(BitConverter.ToString(MD5.Create().ComputeHash(slot.Skip(16).ToArray())));
        Console.WriteLine(BitConverter.ToString(MD5.Create().ComputeHash(slot.Skip(20).ToArray())));
        Console.WriteLine();
        slot = data.Skip(704).Take(0x60030).ToArray();
        Console.WriteLine(BitConverter.ToString(slot.Take(16).ToArray()));
        Console.WriteLine(BitConverter.ToString(MD5.Create().ComputeHash(slot.Skip(16).ToArray())));
        Console.WriteLine(BitConverter.ToString(MD5.Create().ComputeHash(slot.Skip(20).ToArray())));
        Console.WriteLine();

        var savefile = new SaveFile(File.ReadAllBytes(path));
        savefile.WriteToFile();
    }
}