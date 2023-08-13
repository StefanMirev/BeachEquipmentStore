namespace BeachEquipmentStore.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using static BeachEquipmentStore.Common.EntityValidationConstants.Delivery;

    public class Delivery
    {
        public Delivery()
        {
            this.Id = Guid.NewGuid();
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public Guid Id{ get; set; }

        [Required]
        [StringLength(TrackingNumberMaxLength, MinimumLength = TrackingNumberMinLength)]
        [DisplayName("Tracking Number")]
        public string TrackingNumber { get; set; } = null!;

        [Required]
        [DisplayName("Shipping Date")]
        public DateTime ShippingDate { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; } = null!;

        public ICollection<Order> Orders { get; set; }
    }
}
