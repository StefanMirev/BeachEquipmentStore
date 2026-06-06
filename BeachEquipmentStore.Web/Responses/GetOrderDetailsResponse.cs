namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Order;

    public class GetOrderDetailsResponse : BaseResponse
    {
        public OrderDetailViewModel OrderDetails { get; set; } = null!;
    }
}
