namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Cart;
    using Microsoft.EntityFrameworkCore;
    using static Core.Common.Constants.Messages;

    public class CartService : ICartService
    {
        private readonly IUserService _userService;
        private readonly AllBusinessLogics _allBls;

        public CartService(IUserService userService, AllBusinessLogics allBls)
        {
            _userService = userService;
            _allBls = allBls;
        }

        public async Task AddItemToCartAsync(Guid productId, int quantity)
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
                throw new InvalidOperationException(UserNotFound);

            using var transaction = _allBls.CartItemsBL.GetTransactionProxy();
            try
            {
                var existingCartItem = await _allBls.CartItemsBL.FirstOrDefaultAsync(ci => ci.CustomerUserId == userId && ci.ProductId == productId);

                if (existingCartItem != null)
                    existingCartItem.Quantity += quantity;
                else
                    await _allBls.CartItemsBL.AddAsync(new CartItem
                    {
                        CustomerUserId = userId,
                        ProductId = productId,
                        Quantity = quantity
                    });

                var dbProduct = await _allBls.ProductsBL.FindAsync(productId);
                dbProduct!.Stock -= quantity;

                await _allBls.CartItemsBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<CartProductViewModel>> GetCartProductsAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
            {
                throw new InvalidOperationException(UserNotFound);
            }

            var cartItems = await _allBls.CartItemsBL.SearchFor(ci => ci.CustomerUserId == userId)
                .OrderByDescending(ci => ci.CreatedAt)
                .ToListAsync();

            if (!cartItems.Any())
                return new List<CartProductViewModel>();

            var productIds = cartItems.Select(ci => ci.ProductId).ToList();
            var products = await _allBls.ProductsBL.SearchFor(p => productIds.Contains(p.Id)).ToListAsync();
            var productMap = products.ToDictionary(p => p.Id);

            return cartItems
                .Select(ci => new CartProductViewModel
                {
                    Id = ci.ProductId,
                    Name = productMap[ci.ProductId].Name,
                    ImageUrl = productMap[ci.ProductId].ImageUrl,
                    Price = productMap[ci.ProductId].Price,
                    CartQuantity = ci.Quantity
                })
                .ToList();
        }

        public async Task ClearCartAsync(bool restoreStock)
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
                throw new InvalidOperationException(UserNotFound);

            using var transaction = _allBls.CartItemsBL.GetTransactionProxy();
            try
            {
                var cartItems = await _allBls.CartItemsBL.SearchFor(p => p.CustomerUserId == userId)
                    .ToListAsync();

                foreach (var cartItem in cartItems)
                {
                    if (restoreStock)
                    {
                        var dbProduct = await _allBls.ProductsBL.FindAsync(cartItem.ProductId);
                        dbProduct!.Stock += cartItem.Quantity;
                    }

                    _allBls.CartItemsBL.Remove(cartItem);
                }

                await _allBls.CartItemsBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task RemoveItemFromCartAsync(Guid productId)
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
                throw new InvalidOperationException(UserNotFound);

            using var transaction = _allBls.CartItemsBL.GetTransactionProxy();
            try
            {
                var product = await _allBls.ProductsBL.FindAsync(productId)
                    ?? throw new InvalidOperationException(ProductNotFound);

                var cartItem = await _allBls.CartItemsBL.All()
                    .FirstOrDefaultAsync(ci => ci.CustomerUserId == userId && ci.ProductId == productId);

                product.Stock += cartItem!.Quantity;

                _allBls.CartItemsBL.Remove(cartItem);
                await _allBls.CartItemsBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
