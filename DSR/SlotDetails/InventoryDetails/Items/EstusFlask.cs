namespace DSR.SlotDetails.InventoryDetails.Items;

public class EstusFlask : SpecialItem
{ 
    public EstusFlask(uint id, uint amount, int index) : base(64, 200, amount, 0x20, index, true, 0, 0)
    {
        Strength = (id - 200) / 2;
        Empty = (id - 200) % 2 == 0;
        ImagePath = "Images/ItemIcons/Items/EstusFlask.png";
    }

    public EstusFlask() : base(ItemType.EstusFlask, 64, 200, 0x20)
    {
        
    }

    public EstusFlask(EstusFlask estusFlask) : base(estusFlask)
    {
        Strength = estusFlask.Strength;
        Empty = estusFlask.Empty;
    }

    public override uint FullID => (uint)(200 + Strength * 2 + (Empty ? 0 : 1));

    // TODO Check if max possible amount is saved somewhere to detect cheating. If not, set to 20
    public override uint MaxAmount => 5;

    public uint Strength { get; private set; }
    
    public bool Empty { get; private set; }
}