using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Cart;
using Microsoft.EntityFrameworkCore;

namespace BeachEquipmentStore.Services.Data
{
    public class CartService : ICartService
    {
        private readonly EquipmentStoreDbContext _data;

        public CartService(EquipmentStoreDbContext data)
        {
            this._data = data;
        }
        public async Task AddItemToCart(Guid userId, Guid productId, int quantity)
        {
            if (await _data.CartItems.AnyAsync(ci => ci.CustomerId == userId && ci.ProductId == productId))
            {
                var cartProduct = await _data.CartItems.FirstAsync(ci => ci.CustomerId == userId && ci.ProductId == productId);
                cartProduct.Quantity += quantity;

                var dbProduct =  await _data.Products.FirstAsync(p => p.Id == productId);
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

        public async Task<List<CartServiceModel>> GetItemsInCart(Guid userId)
        {
            return await _data.CartItems
                .Where(ci => ci.CustomerId == userId)
                .Select(ci => new CartServiceModel
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                })
                .ToListAsync();       
        }

        public async Task RemoveAllItemsFromCart(Guid userId)
        {
            var productsToRemove = await this._data.CartItems
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
            var cartItem = await _data.CartItems.FirstAsync(ci => ci.CustomerId == userId && ci.ProductId == productId);

            _data.CartItems.Remove(cartItem);
            await _data.SaveChangesAsync();
        }
    }
}
