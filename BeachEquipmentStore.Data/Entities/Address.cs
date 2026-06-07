namespace BeachEquipmentStore.Data.Entities
{
    using static BeachEquipmentStore.Common.Constants.EntityValidationConstants.Address;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Address : IEntity
    {
        public Address()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
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
        [StringLength(ZipCodeMaxLength, MinimumLength = ZipCodeMinLength)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; } = null!;

        [Required]
        [DisplayName("Is Primary Address")]
        public bool IsPrimaryAddress { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [Required]
        public Guid CustomerUserId { get; set; }
        [ForeignKey(nameof(CustomerUserId))]
        public CustomerUser CustomerUser { get; set; } = null!;
    }
}
