namespace BeachEquipmentStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Services.Data.Interfaces;
    using BeachEquipmentStore.Services.Data.Models.Manufacturer;

    public class ManufacturerService : IManufacturerService
    {
        private readonly EquipmentStoreDbContext _data;

        public ManufacturerService(EquipmentStoreDbContext data)
        {
            this._data = data;
        }

        public async Task<List<ManufacturerServiceModel>> GetAllManufacturersAsync()
        {
            return await _data.Manufacturers
                .Select(manufacturer => new ManufacturerServiceModel
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    ImageUrl = manufacturer.ImageUrl
                })
                .ToListAsync();
        }
    }
}
