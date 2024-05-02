using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BeachEquipmentStore.Data.Models.Enums;
using BeachEquipmentStore.Services.Data.Models.Profile;
using BeachEquipmentStore.Services.Data.Models.Product;

namespace BeachEquipmentStore.Services.Data.Models.Order
{
    public class OrderDetailServiceModel
    {
        public OrderDetailServiceModel()
        {
            this.Products = new List<ExtendedProductServiceModel>();
            this.DeliveryPrice = 5.50m;
        }

        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public string DeliveryStatus { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal OverallPrice {get;set;} 

        public string? AddressName { get; set; }

        public string? TownName { get; set; }

        public int ZipCode { get; set; }

        public AddressServiceModel Address { get; set; } = null!;

        public List<ExtendedProductServiceModel> Products { get; set; }
    }
}
