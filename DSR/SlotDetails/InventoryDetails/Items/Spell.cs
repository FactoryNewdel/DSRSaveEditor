namespace DSR.SlotDetails.InventoryDetails.Items;

public class Spell : Item
{
    private SpellType _spellType;
    
    public Spell(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        _spellType = (SpellType)(id / 1000);
        ImagePath += $"Spells/{_spellType}/{Type}.png";
    }

    public Spell(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting, 0)
    {
        _spellType = (SpellType)(id / 1000);
        ImagePath += $"Spells/{_spellType}/{Type}.png";
    }

    public Spell(Spell spell) : base(spell)
    {
        _spellType = spell._spellType;
    }

    public SpellType SpellType => _spellType;
}