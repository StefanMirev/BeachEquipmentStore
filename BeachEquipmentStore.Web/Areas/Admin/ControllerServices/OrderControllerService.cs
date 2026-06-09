using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Areas.Admin.Interfaces;
using BeachEquipmentStore.Web.Responses;
using static Core.Common.Constants.Messages;

namespace BeachEquipmentStore.Web.Areas.Admin.ControllerServices
{
    public class OrderControllerService : IOrderControllerService
    {
        private readonly IOrderService _orderService;

        public OrderControllerService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<GetUndeliveredOrdersResponse> GetUndeliveredOrdersAsync()
        {
            try
            {
                return new GetUndeliveredOrdersResponse
                {
                    IsSuccess = true,
                    UndeliveredOrders = await _orderService.GetUndeliveredOrdersAsync()
                };
            }
            catch (Exception ex)
            {
                return new GetUndeliveredOrdersResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> DeliverOrdersAsync(Guid orderId)
        {
            try
            {
                var result = await _orderService.DeliverOrdersAsync(orderId);

                return new BaseResponse
                {
                    IsSuccess = result,
                    ResponseMessage = result ? OrderDeliverySuccess : OrderDeliveryFailure
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }
    }
}
