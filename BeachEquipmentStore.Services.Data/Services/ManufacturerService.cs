namespace BeachEquipmentStore.Services.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Manufacturer;
    using Microsoft.EntityFrameworkCore;

    public class ManufacturerService : IManufacturerService
    {
        private readonly EquipmentStoreDbContext _data;

        public ManufacturerService(EquipmentStoreDbContext data)
        {
            _data = data;
        }

        public async Task<List<ManufacturerViewModel>> GetAllManufacturersAsync()
        {
            if (!_data.Manufacturers.Any())
            {
                throw new InvalidOperationException("Няма въведени производители!");
            }

            return await _data.Manufacturers
                .Select(manufacturer => new ManufacturerViewModel
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    ImageUrl = manufacturer.ImageUrl
                })
                .ToListAsync();
        }
    }
}
