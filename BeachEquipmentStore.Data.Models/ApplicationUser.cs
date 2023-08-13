namespace BeachEquipmentStore.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    
    using static BeachEquipmentStore.Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.CartItems = new HashSet<CartItem>();
            this.Orders = new HashSet<Order>();
            this.Invoices = new HashSet<Invoice>();
            this.Deliveries = new HashSet<Delivery>();
            this.Addresses = new HashSet<Address>();
        }

        [Required]
        [Unicode]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Unicode]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;

        public ICollection<Address> Addresses { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }
    }
}
