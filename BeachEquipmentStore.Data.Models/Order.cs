namespace BeachEquipmentStore.Data.Models
{
    using BeachEquipmentStore.Data.Models.Enums;
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
            this.ShippingDate = null;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Shipping Date")]
        public DateTime? ShippingDate { get; set; }

        [Required]
        [DisplayName("Delivery Status")]
        public DeliveryStatus DeliveryStatus { get; set; }

        [Required]
        [Precision(18, 2)]
        [DisplayName("Total Price")]
        public decimal TotalPrice { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; } = null!;

        public ICollection<ProductOrder> OrderProducts { get; set; }
    }
}
