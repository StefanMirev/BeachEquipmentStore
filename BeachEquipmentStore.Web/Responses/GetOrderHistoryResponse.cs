namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Order;

    public class GetOrderHistoryResponse : BaseResponse
    {
        public List<OrderHistoryViewModel> Orders { get; set; } = new();
    }
}
