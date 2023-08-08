namespace BeachEquipmentStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using static BeachEquipmentStore.Common.EntityValidationConstants.Category;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Unicode]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = null!;
    }
}
