namespace BeachEquipmentStore.Services.Data.Models.Profile
{
    public class OrderHistoryServiceModel
    {
        public Guid Id { get; set; }

        public string DeliveryStatus { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
