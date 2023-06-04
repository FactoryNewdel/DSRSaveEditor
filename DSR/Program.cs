using System.Diagnostics;
using System.Text;
using DSR.SavefileStructure;
using DSR.SlotDetails;
using DSR.SlotDetails.InventoryDetails.Items;
using DSR.Utils;

class Program
{
    private static string dir = @"C:\Users\Tim\Documents\NBGI\DARK SOULS REMASTERED\472496615";
    private static string path = Path.Join(dir, "DRAKS0005.sl2");
    private static string path1 = Path.Join(dir, "DRAKS0005 - Kopie (11).sl2");

    public static void Main(string[] args)
    {
        DetailComparer.Init(0x5FFFC);

        var savefile = new SaveFile(File.ReadAllBytes(path));
        var savefile1 = new SaveFile(File.ReadAllBytes(path1));

        var b0 = savefile.SaveSlots[0].Details.Bytes;
        var b1 = savefile1.SaveSlots[0].Details.Bytes;
        var ticks = DateTime.UtcNow.Ticks;

        var sb = new StringBuilder("\n\n\n\n");

        for (var i = 0; i < 300000; i++)
        {
            if (b0[i] == b1[i]) continue;
            if (DetailComparer.KnownBytes[i] == 0xFF) continue;
            File.AppendAllText(ticks + "_log.txt", $"{i} : {b1[i]} -> {b0[i]}\n");
            sb.AppendLine($"_bytes[{i}] = {b1[i]};");
        }

        var section0 = savefile.SaveSlots[1].Details.Progress.Sections;
        var section1 = savefile1.SaveSlots[1].Details.Progress.Sections;
        for (var i = 0; i < section0.Length; i++)
        {
            for (var j = 0; j < section0[i].Length; j++)
            {
                if (section0[i][j] == section1[i][j]) continue;
                File.AppendAllText(ticks + "_log.txt", $"S_{i}_{j} : {section1[i][j]} -> {section0[i][j]}\n");
            }
        }

        if (sb.Length > 10)
        {
            var p = ticks + "_log.txt";
            //File.AppendAllText(p, sb.ToString());
            //Process.Start("explorer.exe", Path.GetFullPath(p));
        }

        savefile.SaveSlots[0].Details.CharacterStats.CurrentSouls = 1000000;
        savefile.SaveSlots[0].Details.CharacterStats.TotalSouls = 1000000;
        /*var longsword = Items.GetItem(ItemType.Longsword);
        longsword.Infusion = Infusion.Crystal;
        longsword.Level = 5;
        var pointer = savefile.SaveSlots[0].Details.Equipment.ItemRight0.Index;
        longsword.Index = pointer;

        savefile.SaveSlots[0].Details.Inventory.Items[pointer] = longsword;
        savefile.SaveSlots[0].Details.Equipment.ItemRight0 = longsword;*/

        savefile.WriteToFile();
        Console.WriteLine("Save file created!");
    }
}