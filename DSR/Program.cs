using System.Text;
using DSR.SavefileStructure;

class Program
{
    private static string dir = @"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\472496615";
    private static string path = Path.Join(dir, "DRAKS0005.sl2");
    private static string path1 = Path.Join(dir, "DRAKS0005 - Kopie (14).sl2");

    public static void Main(string[] args)
    {
        var savefile = new SaveFile(File.ReadAllBytes(path));
        var savefile1 = new SaveFile(File.ReadAllBytes(path1));

        var b0 = savefile.SaveSlots[0].Details.Bytes;
        var b1 = savefile1.SaveSlots[0].Details.Bytes;
        var ticks = DateTime.UtcNow.Ticks;

        var sb = new StringBuilder("\n\n\n\n");

        for (var i = 0; i < 300000; i++)
        {
            if (b0[i] == b1[i]) continue;
            File.AppendAllText(ticks + "_log.txt", $"{i} : {b1[i]} -> {b0[i]}\n");
            sb.AppendLine($"_bytes[{i}] = {b1[i]};");
        }
        if (sb.Length > 10) File.AppendAllText(ticks + "_log.txt", sb.ToString());

        savefile.WriteToFile();
        Console.WriteLine("Save file created!");
    }
}