using BeachEquipmentStore.Web.ViewModels.Category;
using BeachEquipmentStore.Web.ViewModels.Manufacturer;

namespace BeachEquipmentStore.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
            this.Manufacturers = new List<ManufacturerViewModel>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public List<CategoryViewModel>? Categories { get; set; }

        public List<ManufacturerViewModel>? Manufacturers { get; set; }
    }
}
