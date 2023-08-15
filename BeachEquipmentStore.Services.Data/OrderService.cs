using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;
using BeachEquipmentStore.Data.Models.Enums;
using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Services.Data.Models.Cart;
using BeachEquipmentStore.Services.Data.Models.Order;
using BeachEquipmentStore.Services.Data.Models.Product;
using BeachEquipmentStore.Services.Data.Models.Profile;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

using ApplicationUser = BeachEquipmentStore.Data.Models.ApplicationUser;
using Address = BeachEquipmentStore.Data.Models.Address;
using Product = BeachEquipmentStore.Data.Models.Product;
using BeachEquipmentStore.Web.ViewModels.Profile;
using static BeachEquipmentStore.Common.EntityValidationConstants;

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

            List<CartItem> userCartItems = await _data.CartItems.Include(p => p.Product)
                .Where(ci => ci.CustomerId.ToString() == userId)
                .ToListAsync();

            List<ProductServiceModel> userProducts = userCartItems.Select(p => new ProductServiceModel
            {
                Id = p.ProductId,
                Name = p.Product.Name,
                ImageUrl = p.Product.ImageUrl,
                Price = p.Product.Price,
                Quantity = p.Quantity
            })
                .ToList();

            return new CreateOrderServiceModel
            {
                UserInfo = new UserInfoServiceModel
                {
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Email = currentUser.Email,
                    PhoneNumber = currentUser.PhoneNumber
                },
                UserAddress = new AddressServiceModel
                {
                    Name = userAddress!.Name,
                    Town = userAddress!.Town,
                    ZipCode = userAddress.ZipCode,
                },
                Products = userProducts
            };
        }

        public async Task GenerateOrder(string userId, bool hasAddress, string? addressName, string? town, int zipCode, decimal totalSum)
        {
            if (!hasAddress)
            {
                Address address = new Address()
                {
                    Name = addressName!,
                    Town = town!,
                    ZipCode = zipCode,
                    CustomerId = Guid.Parse(userId)
                };

                _data.Addresses.Add(address);
            }

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                DeliveryStatus = 0,
                OrderDate = DateTime.Now,
                TotalPrice = totalSum,
                CustomerId = Guid.Parse(userId)
            };

            var userCartItems = await _data.CartItems.Include(p => p.Product)
              .Where(ci => ci.CustomerId.ToString() == userId)
              .ToListAsync();

            List<ProductOrder> productOrders = new List<ProductOrder>();

            foreach (var item in userCartItems)
            {
                ProductOrder productOrder = new ProductOrder()
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    SingularPrice = item.Product.Price,
                    Quantity = item.Quantity
                };

                productOrders.Add(productOrder);
            }

            _data.ProductOrders.AddRange(productOrders);
            _data.Orders.Add(order);

            await _data.SaveChangesAsync();
        }

        public async Task<OrderDetailServiceModel> GetOrderDetails(string orderId)
        {
            Order order = await _data.Orders.FirstAsync(p => p.Id.ToString() == orderId);

            Address address = await _data.Addresses.FirstAsync(p => p.CustomerId == order.CustomerId);

            List<ProductOrder> productOrders = await _data.ProductOrders
                .Include(p => p.Product)
                .Where(p => p.OrderId.ToString() == orderId)
                .ToListAsync();

            return new OrderDetailServiceModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                ShippingDate = order.ShippingDate,
                DeliveryStatus = order.DeliveryStatus.ToString(),
                TotalPrice = order.TotalPrice,
                Address = new AddressServiceModel()
                {
                    Name = address.Name,
                    Town = address.Town,
                    ZipCode = address.ZipCode
                },
                Products = productOrders.Select(po => new ExtendedProductServiceModel
                {
                    Name = po.Product.Name,
                    Barcode = po.Product.Barcode,
                    Price = po.Product.Price,
                    Stock = po.Quantity
                }).ToList()
            };
        }
    }
}
