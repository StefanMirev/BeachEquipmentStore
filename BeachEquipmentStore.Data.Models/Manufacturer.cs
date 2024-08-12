namespace BeachEquipmentStore.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static BeachEquipmentStore.Common.EntityValidationConstants.Manufacturer;

    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Unicode]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;
    }
}
