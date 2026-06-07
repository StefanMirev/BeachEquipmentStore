namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Cart;
    using Microsoft.EntityFrameworkCore;
    using static BeachEquipmentStore.Common.Constants.Messages;

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
                var existingCartItem = await _allBls.CartItemsBL.AsQueryable()
                    .FirstOrDefaultAsync(ci => ci.CustomerId == userId && ci.ProductId == productId);

                if (existingCartItem != null)
                    existingCartItem.Quantity += quantity;
                else
                    await _allBls.CartItemsBL.AddAsync(new CartItem
                    {
                        CustomerId = userId,
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

            var cartItems = await _allBls.CartItemsBL.GetAllAsync(ci => ci.CustomerId == userId);
            var productIds = cartItems.Select(ci => ci.ProductId).ToList();
            var products = await _allBls.ProductsBL.GetAllAsync(p => productIds.Contains(p.Id));

            return products
                .Join(cartItems, p => p.Id, ci => ci.ProductId, (p, ci) => new { p, ci })
                .OrderByDescending(x => x.ci.CreatedAt)
                .Select(x => new CartProductViewModel
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    ImageUrl = x.p.ImageUrl,
                    Price = x.p.Price,
                    CartQuantity = x.ci.Quantity
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
                var cartItems = await _allBls.CartItemsBL.GetAllAsync(p => p.CustomerId == userId);

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

                var cartItem = await _allBls.CartItemsBL.AsQueryable()
                    .FirstOrDefaultAsync(ci => ci.CustomerId == userId && ci.ProductId == productId);

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
