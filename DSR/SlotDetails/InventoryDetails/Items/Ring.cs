namespace DSR.SlotDetails.InventoryDetails.Items;

public class Ring : Item
{
    private List<Action> _ringEffects;
    
    public Ring(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        ImagePath += $"Rings/{Type}.png";
    }

    public Ring(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting, 0)
    {
        ImagePath += $"Rings/{Type}.png";
    }

    public Ring(Ring ring) : base(ring)
    {
        _ringEffects = ring._ringEffects;
    }

    public List<Action> RingEffects => _ringEffects;
}