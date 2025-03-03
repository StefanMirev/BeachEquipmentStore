namespace BeachEquipmentStore.Services.Interfaces
{
    using BeachEquipmentStore.ViewModels.Manufacturer;

    public interface IManufacturerService
    {
        Task<List<ManufacturerViewModel>> GetAllManufacturersAsync();
    }
}
