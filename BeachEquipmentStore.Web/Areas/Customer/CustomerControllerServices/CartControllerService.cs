using BeachEquipmentStore.Services.Interfaces;
using BeachEquipmentStore.Web.Responses;
using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
using static BeachEquipmentStore.Common.Constants.Messages;

namespace BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices
{
    public class CartControllerService : ICartControllerService
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartControllerService(ICartService cartItems, IProductService products)
        {
            _cartService = cartItems;
            _productService = products;
        }

        public async Task<GetCartResponse> GoToCartAsync()
        {
            try
            {
                var cartItems = await _cartService.GetItemsInCartAsync();

                return new GetCartResponse
                {
                    IsSuccess = true,
                    Products = await _productService.GetProductsInCartAsync(cartItems)
                };
            }
            catch (Exception ex)
            {
                return new GetCartResponse
                {
                    IsSuccess = false,
                    ResponseMessage = ex.Message
                };
            }
        }

        public async Task<BaseResponse> AddToCartAsync(Guid productId, int quantity)
        {
            try
            {
                if (quantity <= 0)
                {
                    throw new ArgumentOutOfRangeException(ProductQuantityTooLow);
                }

                if (!await _productService.IsInStockAsync(productId, quantity))
                {
                    throw new ArgumentException(ProductOutOfStock);
                }

                await _cartService.AddItemToCartAsync(productId, quantity);

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = CartAddSuccess
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

        public async Task<BaseResponse> RemoveAllItemsFromCartAsync()
        {
            try
            {
                await _cartService.RemoveAllItemsFromCartAsync();

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = CartClearSuccess
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

        public async Task<BaseResponse> RemoveItemFromCartAsync(Guid productId)
        {
            try
            {
                await _cartService.RemoveItemFromCartAsync(productId);

                return new BaseResponse
                {
                    IsSuccess = true,
                    ResponseMessage = CartRemoveSuccess
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
