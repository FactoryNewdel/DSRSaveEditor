using DSR.SlotDetails.InventoryDetails;
using DSR.SlotDetails.InventoryDetails.Items;

namespace GUI.ViewModels;

public class EstusConfiguratorViewModel
{
    private EstusFlask _estus;
    private EstusFlask _originalEstus;
    
    public EstusConfiguratorViewModel(EstusFlask estus)
    {
        _estus = estus;
        _originalEstus = new EstusFlask(estus);
    }

    public void ResetChanges()
    {
        _estus.Strength = _originalEstus.Strength;
        _estus.Amount = _originalEstus.Amount;
        _estus.Empty = _originalEstus.Empty;
    }

    public EstusFlask Estus => _estus;
}