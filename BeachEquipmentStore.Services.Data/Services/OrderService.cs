namespace BeachEquipmentStore.Services.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.EntityFrameworkCore;

    public class OrderService : IOrderService
    {
        private readonly IAddressService _addressService;
        private readonly EquipmentStoreDbContext _data;

        public OrderService(IAddressService addressService, EquipmentStoreDbContext data)
        {
            _addressService = addressService;
            _data = data;
        }

        public async Task<List<OrderHistoryViewModel>> GetOrderHistory(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new ArgumentNullException("Потребителят не съществува!");
            }

            return await _data.Orders
                .Where(o => o.CustomerId == userId)
                .Select(o => new OrderHistoryViewModel
                {
                    Id = o.Id,
                    DeliveryStatus = o.DeliveryStatus.ToString(),
                    OrderDate = o.CreatedAt,
                    TotalPrice = o.TotalPrice
                })
                .ToListAsync();
        }

        public async Task<CreateOrderViewModel> GetDataRequiredForOrder(Guid userId)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

            ApplicationUser currentUser = await _data.Users.Include(a => a.Addresses).FirstAsync(u => u.Id == userId);
            var userAddress = new Address();

            if (currentUser.Addresses.Any() && await _data.Addresses.AnyAsync(a => a.Id == currentUser.Addresses.ElementAt(0).Id))
            {
                userAddress = currentUser.Addresses.ElementAt(0);
            }

            List<CartItem> userCartItems = await _data.CartItems.Include(p => p.Product)
                .Where(ci => ci.CustomerId == userId)
                .ToListAsync();

            List<ProductViewModel> userProducts = userCartItems.Select(p => new ProductViewModel
            {
                Id = p.ProductId,
                Name = p.Product.Name,
                ImageUrl = p.Product.ImageUrl,
                Price = p.Product.Price,
                Quantity = p.Quantity
            })
                .ToList();

            return new CreateOrderViewModel
            {
                UserDetails = new UserDetailsViewModel
                {
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Email = currentUser.Email,
                    PhoneNumber = currentUser.PhoneNumber
                },
                UserAddress = new AddressDetailsViewModel
                {
                    Name = userAddress.Name,
                    Town = userAddress.Town,
                    ZipCode = userAddress.ZipCode,
                },
                Products = userProducts
            };
        }

        public async Task GenerateOrder(Guid userId, bool hasAddress, string? addressName, string? town, string? zipCode, decimal totalSum)
        {
            if (!_data.Users.Any(u => u.Id == userId))
            {
                throw new InvalidOperationException("Такъв потребител не съществува!");
            }

            if (!hasAddress)
            {
                await _addressService.AddAddress(userId, addressName!, town!, zipCode!, true);
            }

            var address = await _data.Addresses.FirstAsync(a => a.CustomerId == userId);

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                DeliveryStatus = 0,
                CreatedAt = DateTime.Now,
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

            await _data.ProductOrders.AddRangeAsync(productOrders);
            await _data.Orders.AddRangeAsync(order);

            await _data.SaveChangesAsync();
        }

        public async Task<OrderDetailViewModel> GetOrderDetails(string orderId)
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

            return new OrderDetailViewModel
            {
                Id = order.Id,
                OrderDate = order.CreatedAt,
                ShippingDate = order.ShippingDate,
                DeliveryStatus = order.DeliveryStatus.ToString(),
                TotalPrice = order.TotalPrice,
                AddressName = order.AddressName,
                TownName = order.TownName,
                ZipCode = order.ZipCode,
                Products = productOrders.Select(po => new ExtendedProductViewModel
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
                .Where(o => o.DeliveryStatus == 0)
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
