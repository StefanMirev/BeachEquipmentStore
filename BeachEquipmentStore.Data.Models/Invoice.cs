namespace BeachEquipmentStore.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using BeachEquipmentStore.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class Invoice
    {
        public Invoice()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public PaymentMethod PaymentMethod {get;set;}

        [Required]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        [Required]
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; } = null!;
    }
}
