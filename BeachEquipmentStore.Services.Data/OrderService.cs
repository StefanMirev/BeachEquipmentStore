using BeachEquipmentStore.Data;
using BeachEquipmentStore.Data.Models;

using BeachEquipmentStore.Services.Data.Interfaces;

using BeachEquipmentStore.Services.Data.Models.Order;
using BeachEquipmentStore.Services.Data.Models.Product;
using BeachEquipmentStore.Services.Data.Models.Profile;

using Microsoft.EntityFrameworkCore;

using ApplicationUser = BeachEquipmentStore.Data.Models.ApplicationUser;
using Address = BeachEquipmentStore.Data.Models.Address;
using Product = BeachEquipmentStore.Data.Models.Product;
using static BeachEquipmentStore.Common.EntityValidationConstants;
using BeachEquipmentStore.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BeachEquipmentStore.Data.Models.Enums;

namespace BeachEquipmentStore.Services.Data
{
    public class OrderService : IOrderService
    {
        private readonly EquipmentStoreDbContext _data;

        public OrderService(EquipmentStoreDbContext data)
        {
            this._data = data;
        }

        public async Task<CreateOrderServiceModel> GetDataRequiredForOrder(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

            ApplicationUser currentUser = await _data.Users.Include(a => a.Addresses).FirstAsync(u => u.Id == userId);
            Address userAddress = new Address();

            if (currentUser.Addresses.Any() && await _data.Addresses.AnyAsync(a => a.Id == currentUser.Addresses.ElementAt(0).Id))
            {
                userAddress = currentUser.Addresses.ElementAt(0);
            }

            List<CartItem> userCartItems = await _data.CartItems.Include(p => p.Product)
                .Where(ci => ci.CustomerId == userId)
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
                    Name = userAddress.Name,
                    Town = userAddress.Town,
                    ZipCode = userAddress.ZipCode,
                },
                Products = userProducts
            };
        }

        public async Task GenerateOrder(Guid userId, bool hasAddress, string? addressName, string? town, int zipCode, decimal totalSum)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

            Address address = new Address();

            if (!hasAddress)
            {
                address.Name = addressName!;
                address.Town = town!;
                address.ZipCode = zipCode;
                address.CustomerId = userId;

                _data.Addresses.Add(address);
            }
            else
            {
                address = await _data.Addresses.FirstAsync(a => a.CustomerId == userId);
            }

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                DeliveryStatus = 0,
                OrderDate = DateTime.Now,
                TotalPrice = totalSum,
                CustomerId = userId,
                AddressName = address.Name,
                TownName = address.Town,
                ZipCode = address.ZipCode
            };

            var userCartItems = await _data.CartItems.Include(p => p.Product)
              .Where(ci => ci.CustomerId == userId)
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
            if (!_data.Orders.Any(u => u.Id == Guid.Parse(orderId)))
            {
                throw new InvalidOperationException("Такава поръчка не съществува!");
            }

            Order order = await _data.Orders.FirstAsync(p => p.Id.ToString() == orderId);

            if (!_data.Users.Any(u => u.Id == order.CustomerId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

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
                AddressName = order.AddressName,
                TownName = order.TownName,
                ZipCode = order.ZipCode,
                Products = productOrders.Select(po => new ExtendedProductServiceModel
                {
                    Name = po.Product.Name,
                    Barcode = po.Product.Barcode,
                    Price = po.Product.Price,
                    Stock = po.Quantity
                })
                .ToList()
            };
        }

        public async Task<List<CompleteOrderViewModel>> GetUndeliveredOrders()
        {
            var orders = await _data.Orders
                .Where(o => (int)o.DeliveryStatus == 0)
                .Select(o => new CompleteOrderViewModel
                {
                    Id = o.Id
                })
                .ToListAsync();

            return orders;
        }


        public async Task DeliverOrders(Guid orderId)
        {
            if (!_data.Orders.Any(u => u.Id == orderId))
            {
                throw new InvalidOperationException("Такава поръчка не съществува!");
            }

            Order? order = await _data.Orders.FindAsync(orderId);

            order!.ShippingDate = DateTime.UtcNow;
            order!.DeliveryStatus += 1;

            await _data.SaveChangesAsync();
        }
    }
}
