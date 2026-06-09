namespace BeachEquipmentStore.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using static Core.Common.Constants.EntityValidationConstants.Product;

    public class ProductLog : IEntity
    {
        public ProductLog()
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
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public ProductOrder ProductOrder { get; set; } = null!;
    }
}
