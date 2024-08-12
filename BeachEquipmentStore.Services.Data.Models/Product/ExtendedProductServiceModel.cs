using BeachEquipmentStore.Services.Data.Models.Category;
using BeachEquipmentStore.Services.Data.Models.Manufacturer;

namespace BeachEquipmentStore.Services.Data.Models.Product
{

    public class ExtendedProductServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Barcode { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public ManufacturerServiceModel Manufacturer { get; set; } = null!;

        public CategoryServiceModel Category { get; set; } = null!;
    }
}
