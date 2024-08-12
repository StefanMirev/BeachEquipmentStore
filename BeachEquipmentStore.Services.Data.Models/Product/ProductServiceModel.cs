namespace BeachEquipmentStore.Services.Data.Models.Product
{
    public class ProductServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
