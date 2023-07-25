namespace DSR.SlotDetails.InventoryDetails.Items;

public class UpgradeMaterial : Item
{
    private MaterialType _materialType;
    
    public UpgradeMaterial(byte idSpace, uint id, uint amount, uint sorting, int index, bool enabled, uint durability, uint durabilityLoss) : base (idSpace, id, amount, sorting, index, enabled, durability, durabilityLoss)
    {
        GetMaterialDetails();
    }

    public UpgradeMaterial(ItemType type, byte idSpace, uint id, uint sorting) : base(type, idSpace, id, sorting, 0)
    {
        GetMaterialDetails();
    }

    public UpgradeMaterial(UpgradeMaterial upgradeMaterial) : base(upgradeMaterial)
    {
        _materialType = upgradeMaterial._materialType;
    }

    private void GetMaterialDetails()
    {
        switch (Type)
        {
            case ItemType.TitaniteShard:
            case ItemType.LargeTitaniteShard:
            case ItemType.TitaniteChunk:
            case ItemType.TitaniteSlab:
                _materialType = MaterialType.Normal;
                break;
            case ItemType.GreenTitaniteShard:
            case ItemType.BlueTitaniteChunk:
            case ItemType.BlueTitaniteSlab:
            case ItemType.WhiteTitaniteChunk:
            case ItemType.WhiteTitaniteSlab:
            case ItemType.RedTitaniteChunk:
            case ItemType.RedTitaniteSlab:
                _materialType = MaterialType.Colored;
                break;
            case ItemType.DragonScale:
            case ItemType.TwinklingTitanite:
            case ItemType.DemonTitanite:
                _materialType = MaterialType.Unique;
                break;
            default:
                throw new Exception($"Invalid Type: {Type}");
        }
    }

    public MaterialType MaterialType => _materialType;
}