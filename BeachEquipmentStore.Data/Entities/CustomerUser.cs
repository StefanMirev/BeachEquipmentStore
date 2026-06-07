namespace BeachEquipmentStore.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static BeachEquipmentStore.Common.Constants.EntityValidationConstants.CustomerUser;

    public class CustomerUser : IEntity
    {
        public CustomerUser()
        {
            this.CreatedAt = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

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

        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [DisplayName("Email Confirmed")]
        public bool EmailConfirmed { get; set; } = false;

        [Required]
        [DisplayName("Phone Number Confirmed")]
        public bool PhoneNumberConfirmed { get; set; } = false;

        [Required]
        [DisplayName("Two-Factor Enabled")]
        public bool TwoFactorEnabled { get; set; } = false;

        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [DisplayName("Lockout Enabled")]
        public bool LockoutEnabled { get; set; } = true;

        public DateTimeOffset? LockoutEnd { get; set; }

        [Required]
        [DisplayName("Access Failed Count")]
        public int AccessFailedCount { get; set; } = 0;

        [DisplayName("GDPR Consent Given At")]
        public DateTime? GdprConsentGivenAt { get; set; }

        [Required]
        [DisplayName("Marketing Preferences")]
        public bool MarketingPreferences { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UserRoleId { get; set; }
        [ForeignKey(nameof(UserRoleId))]
        public UserRole? UserRole { get; set; }

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
