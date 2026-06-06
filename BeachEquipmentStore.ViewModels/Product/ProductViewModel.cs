namespace BeachEquipmentStore.ViewModels.Product
{
    using BeachEquipmentStore.ViewModels.Category;
    using BeachEquipmentStore.ViewModels.Manufacturer;

    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public CategoryViewModel Category { get; set; } = null!;

        public ManufacturerViewModel Manufacturer { get; set; } = null!;
    }
}
