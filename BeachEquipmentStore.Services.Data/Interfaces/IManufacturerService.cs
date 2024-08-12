using BeachEquipmentStore.Services.Data.Models.Manufacturer;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IManufacturerService
    {
        Task<List<ManufacturerServiceModel>> GetAllManufacturersAsync();
    }
}
