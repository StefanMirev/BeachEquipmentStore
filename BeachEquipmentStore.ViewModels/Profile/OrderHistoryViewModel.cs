namespace BeachEquipmentStore.ViewModels.Profile
{
    public class OrderHistoryViewModel
    {
        public Guid Id { get; set; }

        public string DeliveryStatus { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
