namespace BeachEquipmentStore.Data.Entities
{
    using Core.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : IEntity
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
            this.OrderProducts = new HashSet<ProductOrder>();
            this.ShippingDate = null;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [DisplayName("Order Date")]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

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
        public Guid AddressLogId { get; set; }
        [ForeignKey(nameof(AddressLogId))]
        public AddressLog AddressLog { get; set; } = null!;

        [Required]
        public Guid CustomerUserId { get; set; }
        [ForeignKey(nameof(CustomerUserId))]
        public CustomerUser CustomerUser { get; set; } = null!;

        public ICollection<ProductOrder> OrderProducts { get; set; }
    }
}
