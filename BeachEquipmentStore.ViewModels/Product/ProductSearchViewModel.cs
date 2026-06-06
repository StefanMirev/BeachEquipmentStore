namespace BeachEquipmentStore.ViewModels.Product
{
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.ViewModels.Manufacturer;

    public class ProductSearchViewModel
    {
        public string Keyword { get; set; } = null!;

        public int CategoryId { get; set; }

        public int ManufacturerId { get; set; }

        public List<ProductViewModel> Products { get; set; } = new();

        public List<CategoryViewModel> Categories { get; set; } = new();

        public List<ManufacturerViewModel> Manufacturers { get; set; } = new();
    }
}
