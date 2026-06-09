namespace BeachEquipmentStore.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static Core.Common.Constants.EntityValidationConstants.Address;

    public class AddressLog : IEntity
    {
        public AddressLog()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

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
        public string ZipCode { get; set; } = null!;

        public Order Order { get; set; } = null!;
    }
}
