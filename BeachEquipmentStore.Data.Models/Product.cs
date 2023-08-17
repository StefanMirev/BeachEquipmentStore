namespace BeachEquipmentStore.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Microsoft.EntityFrameworkCore;

    using static BeachEquipmentStore.Common.EntityValidationConstants.Product;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
            this.CartItems = new HashSet<CartItem>();
            this.ProductsOrders = new HashSet<ProductOrder>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Unicode]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Unicode]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Unicode]
        [DisplayName("Image Url")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(BarcodeMinValue, BarcodeMaxValue)]
        [DisplayName("EAN")]
        public int Barcode { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(typeof(decimal),PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Quantity in stock")]
        public int Stock { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<ProductOrder> ProductsOrders { get; set; }


    }
}
