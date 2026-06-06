namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Order;

    public class GetUndeliveredOrdersResponse : BaseResponse
    {
        public List<PendingOrderViewModel> UndeliveredOrders { get; set; } = new();
    }
}
