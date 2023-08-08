namespace BeachEquipmentStore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class CartItem
    {
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; } = null!;

        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
