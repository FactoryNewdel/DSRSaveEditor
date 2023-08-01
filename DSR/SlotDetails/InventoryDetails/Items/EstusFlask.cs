namespace DSR.SlotDetails.InventoryDetails.Items;

public class EstusFlask : SpecialItem
{
    private uint _strength;
    private bool _empty;
    
    public EstusFlask(uint id, uint amount, int index) : base(64, 200, amount, 0x20, index, true, 0, 0)
    {
        _strength = (id - 200) / 2;
        _empty = (id - 200) % 2 == 0;
        ImagePath = $"Images/ItemIcons/Items/EstusFlask{(_empty ? "Empty" : "")}.png";
    }

    public EstusFlask() : base(ItemType.EstusFlask, 64, 200, 0x20)
    {
        ImagePath = "Images/ItemIcons/Items/EstusFlask.png";
    }

    public EstusFlask(EstusFlask estusFlask) : base(estusFlask)
    {
        Strength = estusFlask.Strength;
        Empty = estusFlask.Empty;
    }

    public override uint FullID => (uint)(200 + Strength * 2 + (Empty ? 0 : 1));

    // TODO Check if max possible amount is saved somewhere to detect cheating. If not, set to 20
    public override uint MaxAmount => 20;

    public uint Strength
    {
        get => _strength;
        set
        {
            _strength = value;
            NotifyPropertyChanged();
        } 
    }
    
    public bool Empty
    {
        get => _empty;
        set
        {
            if (_empty && !value) ImagePath = ImagePath.Replace("EstusFlaskEmpty", "EstusFlask");
            else if (!_empty && value) ImagePath = ImagePath.Replace("EstusFlask", "EstusFlaskEmpty");
            
            _empty = value;
            NotifyPropertyChanged();
        } 
    }
}