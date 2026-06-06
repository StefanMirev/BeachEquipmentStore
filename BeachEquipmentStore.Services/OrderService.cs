namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data;
    using BeachEquipmentStore.Data.Models;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Cart;
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.EntityFrameworkCore;
    using static BeachEquipmentStore.Common.Constants.Messages;

    public class OrderService : IOrderService
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;
        private readonly EquipmentStoreDbContext _data;

        public OrderService(IAddressService addressService, IUserService userService, EquipmentStoreDbContext data)
        {
            _addressService = addressService;
            _userService = userService;
            _data = data;
        }

        public async Task<List<OrderHistoryViewModel>> GetCurrentUserOrderHistoryAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (!await _data.Users.AnyAsync(u => u.Id == userId))
            {
                throw new ArgumentNullException(UserNotFound);
            }

            return await _data.Orders
                .Where(o => o.CustomerId == userId)
                .Select(o => new OrderHistoryViewModel
                {
                    Id = o.Id,
                    Number = o.Number,
                    DeliveryStatus = o.DeliveryStatus.ToString(),
                    OrderDate = o.CreatedAt,
                    TotalPrice = o.TotalPrice
                })
                .OrderByDescending(oh => oh.OrderDate)
                .ToListAsync();
        }

        public async Task<CreateOrderViewModel> GetDetailsForCreateOrderAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            var userDetails = await _data.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserDetailsViewModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                }).FirstOrDefaultAsync() ?? throw new InvalidOperationException(UserNotFound);

            var userAddress = await _data.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Addresses)
                .OrderByDescending(a => a.IsPrimaryAddress)
                .Select(a => new AddressDetailsViewModel
                {
                    Name = a.Name,
                    Town = a.Town,
                    ZipCode = a.ZipCode
                })
                .FirstOrDefaultAsync() ?? new AddressDetailsViewModel();

            var userProducts = await _data.CartItems.Include(p => p.Product)
                .Where(ci => ci.CustomerId == userId)
                .OrderByDescending(ci => ci.CreatedAt)
                .Select(p => new CartProductViewModel
                {
                    Id = p.ProductId,
                    Name = p.Product.Name,
                    ImageUrl = p.Product.ImageUrl,
                    Price = p.Product.Price,
                    CartQuantity = p.Quantity
                })
                .ToListAsync();

            return new CreateOrderViewModel
            {
                UserDetails = userDetails,
                UserAddress = userAddress,
                Products = userProducts
            };
        }

        public async Task CreateOrderAsync(string? addressName, string? town, string? zipCode)
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            var user = await _data.Users.Include(u => u.Addresses).FirstOrDefaultAsync(u => u.Id == userId) ?? throw new InvalidOperationException(UserNotFound);

            if (!user.Addresses.Any(a => a.Name == addressName && a.Town == town && a.ZipCode == zipCode))
            {
                await _addressService.AddAddressAsync(userId, addressName!, town!, zipCode!, true);
            }

            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                DeliveryStatus = 0,
                CreatedAt = DateTime.Now,
                CustomerId = userId,
                AddressName = addressName,
                TownName = town,
                ZipCode = zipCode
            };

            var productOrders = await _data.CartItems.Include(p => p.Product)
              .Where(ci => ci.CustomerId == userId)
              .Select(po => new ProductOrder
              {
                  OrderId = order.Id,
                  ProductId = po.ProductId,
                  SingularPrice = po.Product.Price,
                  Quantity = po.Quantity
              })
              .ToListAsync();

            order.TotalPrice = productOrders.Sum(e => e.SingularPrice * e.Quantity);

            await _data.ProductOrders.AddRangeAsync(productOrders);
            await _data.Orders.AddRangeAsync(order);

            await _data.SaveChangesAsync();
        }

        public async Task<OrderDetailViewModel> GetOrderDetailsAsync(string orderId)
        {
            var order = await _data.Orders.FirstOrDefaultAsync(p => p.Id.ToString() == orderId) ?? throw new InvalidOperationException(OrderNotFound);

            if (_userService.GetCurrentLoggedInUserId() != order.CustomerId)
            {
                throw new InvalidOperationException(OrderNotFound);
            }

            var productOrders = await _data.ProductOrders
                .Include(p => p.Product)
                .Where(p => p.OrderId == Guid.Parse(orderId))
                .Select(po => new ExtendedProductViewModel
                {
                    Name = po.Product.Name,
                    Barcode = po.Product.Barcode,
                    Price = po.Product.Price,
                    Stock = po.Quantity,
                    CreatedAt = po.CreatedAt
                }).OrderByDescending(po => po.CreatedAt)
                .ToListAsync();

            return new OrderDetailViewModel
            {
                Id = order.Id,
                Number = order.Number,
                OrderDate = order.CreatedAt,
                ShippingDate = order.ShippingDate,
                DeliveryStatus = order.DeliveryStatus.ToString(),
                TotalPrice = order.TotalPrice,
                AddressName = order.AddressName,
                TownName = order.TownName,
                ZipCode = order.ZipCode,
                Products = productOrders
            };
        }

        public async Task<List<PendingOrderViewModel>> GetUndeliveredOrdersAsync()
        {
            var orders = await _data.Orders
                .Where(o => o.DeliveryStatus == 0)
                .Select(o => new PendingOrderViewModel
                {
                    Id = o.Id,
                    CreatedAt = o.CreatedAt
                })
                .OrderBy(o => o.CreatedAt)
                .ToListAsync();

            return orders;
        }

        public async Task<bool> DeliverOrdersAsync(Guid orderId)
        {
            var order = await _data.Orders.FirstOrDefaultAsync(o => o.Id == orderId) ?? throw new InvalidOperationException(OrderNotFound);

            order.ShippingDate = DateTime.Now;
            order.DeliveryStatus += 1;
            order.UpdatedAt = DateTime.Now;

            return await _data.SaveChangesAsync() > 0;
        }
    }
}
