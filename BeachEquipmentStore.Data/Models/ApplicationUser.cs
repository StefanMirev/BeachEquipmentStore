﻿namespace BeachEquipmentStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static BeachEquipmentStore.Common.EntityValidationConstants.ApplicationUser;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.CartItems = new HashSet<CartItem>();
            this.Orders = new HashSet<Order>();
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

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
