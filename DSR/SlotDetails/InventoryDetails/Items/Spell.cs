namespace DSR.SlotDetails.InventoryDetails.Items;

public class Spell : Item
{
    private SpellType _spellType;
    private UInt32 _maxUsages;
    private UInt32 _usedSlots;
    
    public Spell(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        _spellType = (SpellType)(id / 1000);
        var invSpell = (ItemList.GetItem(Type) as Spell);
        _maxUsages = invSpell.MaxUsages;
        _usedSlots = invSpell.UsedSlots;
        ImagePath += $"Spells/{_spellType}/{Type}.png";
    }

    public Spell(ItemType type, byte idSpace, uint id, uint sorting, uint maxUsages, uint usedSlots = 1) : base(type, idSpace, id, sorting, 0)
    {
        _spellType = (SpellType)(id / 1000);
        _maxUsages = maxUsages;
        _usedSlots = usedSlots;
        ImagePath += $"Spells/{_spellType}/{Type}.png";
    }

    public Spell(Spell spell) : base(spell)
    {
        _spellType = spell._spellType;
        _maxUsages = spell._maxUsages;
        _usedSlots = spell._usedSlots;
    }

    public SpellType SpellType => _spellType;

    public uint MaxUsages => _maxUsages;

    public uint UsedSlots => _usedSlots;
}