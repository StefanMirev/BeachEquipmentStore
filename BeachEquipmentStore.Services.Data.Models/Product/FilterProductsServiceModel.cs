using BeachEquipmentStore.Services.Data.Models.Category;
using BeachEquipmentStore.Services.Data.Models.Manufacturer;

namespace BeachEquipmentStore.Services.Data.Models.Product
{
    public class FilterProductsServiceModel
    {
        public List<ProductServiceModel> Products { get; set; } = null!;

        public List<CategoryServiceModel> Categories { get; set; } = null!;

        public List<ManufacturerServiceModel> Manufacturers { get; set; } = null!;
    }
}
