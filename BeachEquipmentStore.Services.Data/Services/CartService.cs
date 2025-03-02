namespace BeachEquipmentStore.Services.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Cart;
    using Microsoft.EntityFrameworkCore;

    public class CartService : ICartService
    {
        private readonly EquipmentStoreDbContext _data;

        public CartService(EquipmentStoreDbContext data)
        {
            _data = data;
        }
        public async Task AddItemToCart(Guid userId, Guid productId, int quantity)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
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

        public async Task<List<CartViewModel>> GetItemsInCart(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

            return await _data.CartItems
                .Where(ci => ci.CustomerId == userId)
                .Select(ci => new CartViewModel
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                })
                .ToListAsync();
        }

        public async Task RemoveAllItemsFromCart(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
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
            await _data.SaveChangesAsync();
        }

        public async Task RemoveItemFromCart(Guid userId, Guid productId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

            if (!_data.Products.Any(u => u.Id == productId))
            {
                throw new InvalidOperationException("Продуктът не съществува!");
            }

            var cartItem = await _data.CartItems.FirstAsync(ci => ci.CustomerId == userId && ci.ProductId == productId);

            var dbProduct = await _data.Products.FirstAsync(p => p.Id == cartItem.ProductId);
            dbProduct.Stock += cartItem.Quantity;

            _data.CartItems.Remove(cartItem);
            await _data.SaveChangesAsync();
        }

        public async Task ClearCartAfterOrder(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

            var productsToRemove = await _data.CartItems
               .Where(p => p.CustomerId == userId)
               .ToListAsync();

            _data.RemoveRange(productsToRemove);
            await _data.SaveChangesAsync();
        }
    }
}
