using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
using static BeachEquipmentStore.Common.Constants.Messages;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices
{
    public class OrderControllerService : IOrderControllerService
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _ordersService;

        public OrderControllerService(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _ordersService = orderService;
        }

        public async Task<GetDetailsForCreateOrderResponse> GetDetailsForCreateOrderAsync()
        {
            try
            {
                return new GetDetailsForCreateOrderResponse
                {
                    IsSuccess = true,
                    DetailsForCreateOrder = await _ordersService.GetDetailsForCreateOrderAsync()
                };
            }
            catch (Exception ex)
            {
                return new GetDetailsForCreateOrderResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> CreateOrderAsync(string? addressName, string? town, string zipCode)
        {
            try
            {
                await _ordersService.CreateOrderAsync(addressName, town, zipCode);
                await _cartService.ClearCartAfterOrderAsync();

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = OrderCreateSuccess
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

        public async Task<GetOrderDetailsResponse> GetOrderDetailsAsync(string orderId)
        {
            try
            {
                var orderDetails = await _ordersService.GetOrderDetailsAsync(orderId);

                return new GetOrderDetailsResponse
                {
                    IsSuccess = true,
                    OrderDetails = orderDetails
                };
            }
            catch (Exception ex)
            {
                return new GetOrderDetailsResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<GetUndeliveredOrdersResponse> GetUndeliveredOrdersAsync()
        {
            try
            {
                return new GetUndeliveredOrdersResponse
                {
                    IsSuccess = true,
                    UndeliveredOrders = await _ordersService.GetUndeliveredOrdersAsync()
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
                var result = await _ordersService.DeliverOrdersAsync(orderId);

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
