namespace BeachEquipmentStore.ViewModels.Order
{
    using BeachEquipmentStore.Common;
    using BeachEquipmentStore.ViewModels.Product;

    public class OrderDetailViewModel : OrderHistoryViewModel
    {
        public DateTime? ShippingDate { get; set; }

        public decimal DeliveryPrice { get; set; } = Constants.GeneralApplicationConstants.DeliveryPrice;

        public decimal OverallPrice => TotalPrice + DeliveryPrice;

        public string? AddressName { get; set; }

        public string? TownName { get; set; }

        public string? ZipCode { get; set; }

        public List<ExtendedProductViewModel> Products { get; set; } = new();
    }
}
