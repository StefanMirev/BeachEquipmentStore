namespace BeachEquipmentStore.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductOrder
    {
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal SingularPrice { get; set; }
    }
}