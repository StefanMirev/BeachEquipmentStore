namespace BeachEquipmentStore.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CartItem : IEntity
    {
        public CartItem()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public Guid CustomerUserId { get; set; }
        [ForeignKey(nameof(CustomerUserId))]
        public CustomerUser CustomerUser { get; set; } = null!;

        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }

        public int Quantity { get; set; }
    }
}
