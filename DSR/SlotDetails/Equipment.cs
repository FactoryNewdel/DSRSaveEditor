namespace DSR.SlotDetails;

public class Equipment
{
    #region Variables

    //private 

    #endregion

    public Equipment(byte[] bytes)
    {
        // Pointer first left hand 660-3
        // Pointer first right hand 664-7
        // Pointer second left hand 668-71
        // Pointer second right hand 672-5
        
        // ID first left hand 768-71
        // ID first right hand 772-5
        // ID second left hand 776-9
        // ID second right hand 780-3
        
        // Pointer Helmet 692-5
        // Pointer Chest 696-9
        // Pointer Leggings 700-3
        // Pointer Booties 704-7
        
        // ID Helmet 800-3
        // ID Chest 804-7
        // ID Leggings 808-11
        // ID Booties 812-5
        
        // Pointer 1st Consumable 720-3     58308-11
        // Pointer 2nd Consumable 724-7     58312-5
        // Pointer 3rd Consumable 728-1     58316-9
        // Pointer 4th Consumable 732-5     58320-3
        // Pointer 5th Consumable 736-9     58324-7
        
        // ID 1st Consumable 828-31
        // ID 2nd Consumable 832-5
        // ID 3rd Consumable 836-9
        // ID 4th Consumable 840-3
        // ID 5th Consumable 844-7
    }
}