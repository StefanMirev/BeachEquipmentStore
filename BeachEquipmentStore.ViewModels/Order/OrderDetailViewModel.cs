using BeachEquipmentStore.Web.ViewModels.Product;
using BeachEquipmentStore.Web.ViewModels.Profile;

namespace BeachEquipmentStore.Web.ViewModels.Order
{
    public class OrderDetailViewModel
    {
        public OrderDetailViewModel()
        {
            this.Products = new List<ExtendedProductViewModel>();
        }

        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippingDate { get; set; }

        public string DeliveryStatus { get; set; } = null!;

        public decimal TotalPrice { get; set; }

        public decimal DeliveryPrice { get; set; }

        public decimal OverallPrice { get; set; }

        public string? AddressName { get; set; }

        public string? TownName { get; set; }

        public int ZipCode { get; set; }

        public AddressDetailsViewModel Address { get; set; } = null!;

        public List<ExtendedProductViewModel> Products { get; set; }
    }
}
