using System.Security.Cryptography;
using System.Text;

namespace DSR.SavefileStructure;

public class SaveFile
{
    private SaveFileHeader _fileHeader;
    private SaveSlotHeader[] _saveSlotHeaders;
    private SaveSlotTitle[] _saveSlotTitles;
    private SaveSlot[] _saveSlots;

    public SaveFile(byte[] data)
    {
        _fileHeader = new SaveFileHeader(data.Take(64).ToArray());

        _saveSlotHeaders = new SaveSlotHeader[11];
        for (var i = 0; i < _saveSlotHeaders.Length; i++)
        {
            _saveSlotHeaders[i] = new SaveSlotHeader(data.Skip(_fileHeader.Length + i * 32).Take(32).ToArray());
            using var md5 = MD5.Create();
            Console.WriteLine($"SlotHeader Hash = {BitConverter.ToString(md5.ComputeHash(data.Skip(_fileHeader.Length + i * 32).Take(32).ToArray()))}");
            Console.WriteLine("Offset      = " + _saveSlotHeaders[i].Offset);
            Console.WriteLine("TitleOffset = " + _saveSlotHeaders[i].TitleOffset);
            Console.WriteLine("PaddingSize = " + _saveSlotHeaders[i].PaddingSize);
        }
        
        _saveSlotTitles = new SaveSlotTitle[11];
        for (var i = 0; i < _saveSlotHeaders.Length; i++)
        {
            _saveSlotTitles[i] = new SaveSlotTitle(data.Skip(_fileHeader.Length + 11 * 32 + i * 26).Take(26).ToArray());
        }
        
        _saveSlots = new SaveSlot[11];
        for (var i = 0; i < _saveSlots.Length; i++)
        {
            Console.WriteLine("Skipping " + (0x2C0 + i * 0x60030));
            _saveSlots[i] = new SaveSlot(data.Skip(0x2C0 + i * 0x60030).Take(0x60030).ToArray());
        }
        
        

        var alpaka = _saveSlots[1];
        Console.WriteLine("Souls");
        for (var i = 0; i < alpaka.Details.Length; i += 4)
        {
            var a = BitConverter.ToUInt32(alpaka.Details.Skip(i).Take(4).ToArray());
            if (a == 5228274) Console.WriteLine("a: " + i);
            if (a == 0x69187187) Console.WriteLine("b: " + i);
            if (a == 264409) Console.WriteLine("c: " + i);
            if (a == 0xEEEEEEEE) Console.WriteLine("d: " + i);
        } 
        
        Console.WriteLine("Name");
        var str = Encoding.Default.GetString(alpaka.Details);
        Console.WriteLine("Pls = " + str.Contains("Dalai-Alpaka", StringComparison.InvariantCultureIgnoreCase));
    }

    public void WriteToFile()
    {
        var bytes = new List<byte>();
        bytes.AddRange(_fileHeader.ToBytes());
        foreach (var saveSlotHeader in _saveSlotHeaders)
        {
            bytes.AddRange(saveSlotHeader.ToBytes());
        }
        foreach (var saveSlotTitle in _saveSlotTitles)
        {
            bytes.AddRange(saveSlotTitle.ToBytes());
        }
        bytes.Add(0);
        bytes.Add(0);
        foreach (var saveSlot in _saveSlots)
        {
            bytes.AddRange(saveSlot.ToBytes());
        }

        var compare = File.ReadAllBytes(@"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\296043893\DRAKS0005.sl2");
        for (var i = 0; i < bytes.Count; i++)
        {
            //if (bytes[i] != compare[i]) Console.WriteLine(i);
        }
        
        File.WriteAllBytes("DRAKS0005.sl2", bytes.ToArray());
    }
}