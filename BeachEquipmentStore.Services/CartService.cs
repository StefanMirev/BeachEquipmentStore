namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Services.DTOs;
    using Microsoft.EntityFrameworkCore;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class CartService : ICartService
    {
        private readonly IUserService _userService;
        private readonly EquipmentStoreDbContext _data;

        public CartService(IUserService userService, EquipmentStoreDbContext data)
        {
            _userService = userService;
            _data = data;
        }

        public async Task AddItemToCartAsync(Guid productId, int quantity)
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (!await _data.Users.AnyAsync(u => u.Id == userId))
            {
                throw new InvalidOperationException(UserNotFound);
            }

            if (await _data.CartItems.AnyAsync(ci => ci.CustomerId == userId && ci.ProductId == productId))
            {
                var cartProduct = await _data.CartItems.FirstAsync(ci => ci.CustomerId == userId && ci.ProductId == productId);
                cartProduct.Quantity += quantity;

                var dbProduct = await _data.Products.FirstAsync(p => p.Id == productId);
                dbProduct.Stock -= quantity;
            }
            else
            {
                await _data.CartItems.AddAsync(new CartItem
                {
                    CustomerId = userId,
                    ProductId = productId,
                    Quantity = quantity
                });
            }

            await _data.SaveChangesAsync();
        }

        public async Task<List<CartItemDto>> GetItemsInCartAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (!await _data.Users.AnyAsync(u => u.Id == userId))
            {
                throw new InvalidOperationException(UserNotFound);
            }

            return await _data.CartItems
                .Where(ci => ci.CustomerId == userId)
                .Select(ci => new CartItemDto
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    CreatedAt = ci.CreatedAt
                })
                .OrderByDescending(ci => ci.CreatedAt)
                .ToListAsync();
        }

        public async Task RemoveAllItemsFromCartAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException(UserNotFound);
            }

            var productsToRemove = await _data.CartItems
                .Where(p => p.CustomerId == userId)
                .ToListAsync();

            foreach (var cartItem in productsToRemove)
            {
                var dbProduct = await _data.Products.FirstAsync(p => p.Id == cartItem.ProductId);
                dbProduct.Stock += cartItem.Quantity;
            }

            _data.RemoveRange(productsToRemove);
            _data.SaveChanges();
        }

        public async Task RemoveItemFromCartAsync(Guid productId)
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (!await _data.Users.AnyAsync(u => u.Id == userId))
            {
                throw new InvalidOperationException(UserNotFound);
            }

            if (!await _data.Products.AnyAsync(u => u.Id == productId))
            {
                throw new InvalidOperationException(ProductNotFound);
            }

            var cartItem = await _data.CartItems.FirstAsync(ci => ci.CustomerId == userId && ci.ProductId == productId);

            var dbProduct = await _data.Products.FirstAsync(p => p.Id == cartItem.ProductId);
            dbProduct.Stock += cartItem.Quantity;

            _data.CartItems.Remove(cartItem);
            await _data.SaveChangesAsync();
        }

        public async Task ClearCartAfterOrderAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (!await _data.Users.AnyAsync(u => u.Id == userId))
            {
                throw new InvalidOperationException(UserNotFound);
            }

            var productsToRemove = await _data.CartItems
               .Where(p => p.CustomerId == userId)
               .ToListAsync();

            _data.RemoveRange(productsToRemove);
            await _data.SaveChangesAsync();
        }
    }
}
