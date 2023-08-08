namespace BeachEquipmentStore.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderProducts = new HashSet<ProductOrder>();
            this.Invoices = new HashSet<Invoice>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Precision(18, 2)]
        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; } = null!;

        public Guid? DeliveryId { get; set; }
        [ForeignKey(nameof(DeliveryId))]
        public Delivery Delivery { get; set; } = null!;

        public ICollection<Invoice> Invoices { get; set; }

        public ICollection<ProductOrder> OrderProducts { get; set; }
    }
}
