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
        }
        
        _saveSlotTitles = new SaveSlotTitle[11];
        for (var i = 0; i < _saveSlotHeaders.Length; i++)
        {
            _saveSlotTitles[i] = new SaveSlotTitle(data.Skip(_fileHeader.Length + 11 * 32 + i * 26).Take(26).ToArray());
        }
        
        _saveSlots = new SaveSlot[11];
        for (var i = 0; i < _saveSlots.Length; i++)
        {
            _saveSlots[i] = new SaveSlot(data.Skip(0x2C0 + i * 0x60030).Take(0x60030).ToArray());
        }
    }

    public void WriteToFile()
    {
        WriteToFile("DRAKS0005.sl2");
    }
 
    public void WriteToFile(string path)
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

        File.WriteAllBytes(path, bytes.ToArray());
    }

    public SaveFileHeader FileHeader => _fileHeader;

    public SaveSlotHeader[] SaveSlotHeaders => _saveSlotHeaders;

    public SaveSlotTitle[] SaveSlotTitles => _saveSlotTitles;

    public SaveSlot[] SaveSlots => _saveSlots;
}