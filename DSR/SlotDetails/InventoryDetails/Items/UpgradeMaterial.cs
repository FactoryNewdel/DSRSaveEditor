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

    private void GetMaterialDetails()
    {
        var substract = ID / 1000 * 1000;
        var materialTypeNum = (ID - substract) / 100;
        if (!Enum.IsDefined(typeof(MaterialType), (int)materialTypeNum)) throw new InvalidDataException($"Invalid MaterialType: {materialTypeNum}");
        _materialType = (MaterialType)materialTypeNum;
    }

    public MaterialType MaterialType => _materialType;
}