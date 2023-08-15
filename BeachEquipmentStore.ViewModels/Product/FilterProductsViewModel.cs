using BeachEquipmentStore.Web.ViewModels.Category;
using BeachEquipmentStore.Web.ViewModels.Manufacturer;

namespace BeachEquipmentStore.Web.ViewModels.Product
{
    public class FilterProductsViewModel
    {
        public List<ProductViewModel> Products { get; set; } = null!;

        public List<CategoryViewModel> Categories { get; set; } = null!;

        public List<ManufacturerViewModel> Manufacturers { get; set; } = null!;
     }
}
