namespace BeachEquipmentStore.ViewModels.Cart
{
    public class CartViewModel
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
