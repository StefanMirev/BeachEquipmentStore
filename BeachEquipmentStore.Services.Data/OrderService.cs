using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Cart;
using BeachEquipmentStore.Services.Data.Models.Order;
using BeachEquipmentStore.Services.Data.Models.Product;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly EquipmentStoreDbContext _data;

        public OrderService(EquipmentStoreDbContext data)
        {
            this._data = data;
        }

        public async Task<CreateOrderServiceModel> GetDataRequiredForOrder(string userId)
        {
            ApplicationUser currentUser = await _data.Users.Include(u => u.Addresses).FirstAsync(u => u.Id.ToString() == userId);
            Address? userAddress = currentUser.Addresses.ElementAtOrDefault(0);
            
            var userCartItems = await _data.CartItems
                .Where(ci => ci.CustomerId.ToString() == userId)
                .ToListAsync();

            List<Product> userProducts = new List<Product>();
            
            foreach (var item in userCartItems)
            {
                userProducts.Add(await _data.Products.FindAsync(item.ProductId));
            }

            return new CreateOrderServiceModel
            {
                FirstName = currentUser.FirstName,
                LastName = currentUser.LastName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber,
                AddressName = userAddress.Name,
                Town = userAddress.Town,
                ZipCode = userAddress.ZipCode,
                Products = new List<ProductServiceModel>(userProducts.Select(p => new ProductServiceModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Quantity = p.Stock
                }))
            };
        }
    }
}
