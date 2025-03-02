namespace BeachEquipmentStore.ViewModels.Order
{
    using BeachEquipmentStore.Common;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.ViewModels.Profile;

    public class OrderDetailViewModel
    {
        public OrderDetailViewModel()
        {
            this.Products = new List<ExtendedProductViewModel>();
            this.DeliveryPrice = EntityValidationConstants.Order.DeliveryPrice;
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

        public string? ZipCode { get; set; }

        public AddressDetailsViewModel Address { get; set; } = null!;

        public List<ExtendedProductViewModel> Products { get; set; }
    }
}
