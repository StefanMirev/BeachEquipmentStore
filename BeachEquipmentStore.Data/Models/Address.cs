namespace BeachEquipmentStore.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static BeachEquipmentStore.Common.EntityValidationConstants.Address;

    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Unicode]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Unicode]
        [StringLength(TownNameMaxLength, MinimumLength = TownNameMinLength)]
        public string Town { get; set; } = null!;

        [Required]
        [Range(ZipCodeMinLength, ZipCodeMaxLength)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; } = null!;

        [Required]
        [DisplayName("Is Primary Address")]
        public bool IsPrimaryAddress { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; } = null!;
    }
}
