namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Manufacturer;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class ManufacturerService : IManufacturerService
    {
        private readonly AllBusinessLogics _allBls;

        public ManufacturerService(AllBusinessLogics allBls)
        {
            _allBls = allBls;
        }

        public async Task<List<ManufacturerViewModel>> GetAllManufacturersAsync()
        {
            var manufacturers = await _allBls.ManufacturersBL.GetAllAsync();

            if (!manufacturers.Any())
            {
                throw new InvalidOperationException(ManufacturersNotFound);
            }

            return manufacturers
                .Select(m => new ManufacturerViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                })
                .ToList();
        }
    }
}
