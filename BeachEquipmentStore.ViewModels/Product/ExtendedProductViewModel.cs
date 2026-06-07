namespace BeachEquipmentStore.ViewModels.Product
{
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.ViewModels.Manufacturer;

    public class ExtendedProductViewModel : ProductViewModel
    {
        public string Description { get; set; } = null!;

        public long Barcode { get; set; }

        public CategoryViewModel Category { get; set; } = null!;

        public ManufacturerViewModel Manufacturer { get; set; } = null!;
    }
}
