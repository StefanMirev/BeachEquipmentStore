namespace BeachEquipmentStore.ViewModels.Product
{
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.ViewModels.Manufacturer;

    public class FilterProductsViewModel
    {
        public List<ProductViewModel> Products { get; set; } = null!;

        public List<CategoryViewModel> Categories { get; set; } = null!;

        public List<ManufacturerViewModel> Manufacturers { get; set; } = null!;
    }
}
