namespace DSR.SlotDetails.InventoryDetails.Items;

public class EstusFlask : CommonItem
{ 
    public EstusFlask(uint id, uint amount, int index) : base(64, 200, amount, 0x2000, index, true, 0, 0)
    {
        Strength = (id - 200) % 7;
        Empty = (id - 200) % 2 == 0;
        ImagePath = "Images/ItemIcons/Items/EstusFlask.png";
    }

    public EstusFlask() : base(ItemType.EstusFlask, 64, 200, 0x2000)
    {
        
    }

    public override uint FullID => (uint)(200 + Strength * 2 + (Empty ? 0 : 1));

    public uint Strength { get; private set; }
    
    public bool Empty { get; private set; }
}