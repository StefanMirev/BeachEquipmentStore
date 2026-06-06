namespace BeachEquipmentStore.Web.Responses
{
    using BeachEquipmentStore.ViewModels.Order;

    public class GetDetailsForCreateOrderResponse : BaseResponse
    {
        public CreateOrderViewModel DetailsForCreateOrder { get; set; } = null!;
    }
}
