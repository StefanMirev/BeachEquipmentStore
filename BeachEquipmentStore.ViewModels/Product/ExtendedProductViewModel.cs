namespace BeachEquipmentStore.Web.ViewModels.Product
{
    using BeachEquipmentStore.Web.ViewModels.Category;
    using BeachEquipmentStore.Web.ViewModels.Manufacturer;

    public class ExtendedProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Barcode { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public ManufacturerViewModel Manufacturer { get; set; } = null!;

        public CategoryViewModel Category { get; set; } = null!;
    }
}
