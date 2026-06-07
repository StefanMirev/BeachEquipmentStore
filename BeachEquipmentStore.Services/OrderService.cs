namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Entities;
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
        private readonly AllBusinessLogics _allBls;

        public OrderService(IAddressService addressService, IUserService userService, AllBusinessLogics allBls)
        {
            _addressService = addressService;
            _userService = userService;
            _allBls = allBls;
        }

        public async Task<List<OrderHistoryViewModel>> GetCurrentUserOrderHistoryAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
            {
                throw new ArgumentNullException(UserNotFound);
            }

            var orders = await _allBls.OrdersBL.GetAllAsync(o => o.CustomerId == userId);

            return orders
                .Select(o => new OrderHistoryViewModel
                {
                    Id = o.Id,
                    Number = o.Number,
                    DeliveryStatus = o.DeliveryStatus.ToString(),
                    OrderDate = o.CreatedAt,
                    TotalPrice = o.TotalPrice
                })
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public async Task<CreateOrderViewModel> GetDetailsForCreateOrderAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            var user = await _allBls.UsersBL.FindAsNoTrackingAsync(userId)
                ?? throw new InvalidOperationException(UserNotFound);

            var userDetails = new UserSummaryViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber ?? string.Empty
            };

            var addresses = await _allBls.AddressesBL.GetAllAsync(a => a.CustomerId == userId);
            var userAddress = addresses
                .OrderByDescending(a => a.IsPrimaryAddress)
                .Select(a => new AddressDetailsViewModel
                {
                    Name = a.Name,
                    Town = a.Town,
                    ZipCode = a.ZipCode
                })
                .FirstOrDefault() ?? new AddressDetailsViewModel();

            var userProducts = await _allBls.CartItemsBL.AsQueryable().AsNoTracking()
                .Include(ci => ci.Product)
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

            if (await _allBls.UsersBL.FindAsNoTrackingAsync(userId) == null)
                throw new InvalidOperationException(UserNotFound);

            var userAddresses = await _allBls.AddressesBL.GetAllAsync(a => a.CustomerId == userId);

            if (!userAddresses.Any(a => a.Name == addressName && a.Town == town && a.ZipCode == zipCode))
                await _addressService.AddAddressAsync(userId, addressName!, town!, zipCode!, true);

            using var transaction = _allBls.OrdersBL.GetTransactionProxy();
            try
            {
                var addressLog = new AddressLog
                {
                    Name = addressName!,
                    Town = town!,
                    ZipCode = zipCode!
                };

                var cartItems = await _allBls.CartItemsBL.AsQueryable().AsNoTracking()
                    .Include(ci => ci.Product)
                    .Where(ci => ci.CustomerId == userId)
                    .ToListAsync();

                var order = new Order
                {
                    DeliveryStatus = 0,
                    CustomerId = userId,
                    AddressLogId = addressLog.Id
                };

                var productLogs = new List<ProductLog>();
                var productOrders = new List<ProductOrder>();
                decimal totalPrice = 0;

                foreach (var ci in cartItems)
                {
                    var productLog = new ProductLog
                    {
                        Name = ci.Product.Name,
                        Price = ci.Product.Price
                    };
                    productLogs.Add(productLog);
                    productOrders.Add(new ProductOrder
                    {
                        OrderId = order.Id,
                        ProductId = ci.ProductId,
                        ProductLogId = productLog.Id,
                        Quantity = ci.Quantity
                    });
                    totalPrice += productLog.Price * ci.Quantity;
                }

                order.TotalPrice = totalPrice;

                await _allBls.AddressLogsBL.AddAsync(addressLog);
                await _allBls.ProductLogsBL.AddRangeAsync(productLogs);
                await _allBls.OrdersBL.AddAsync(order);
                await _allBls.ProductOrdersBL.AddRangeAsync(productOrders);

                await _allBls.OrdersBL.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<OrderDetailViewModel> GetOrderDetailsAsync(Guid orderId)
        {
            var order = await _allBls.OrdersBL.AsQueryable().AsNoTracking()
                .Include(o => o.AddressLog)
                .FirstOrDefaultAsync(o => o.Id == orderId)
                ?? throw new InvalidOperationException(OrderNotFound);

            if (_userService.GetCurrentLoggedInUserId() != order.CustomerId)
            {
                throw new InvalidOperationException(OrderNotFound);
            }

            var productOrders = await _allBls.ProductOrdersBL.AsQueryable().AsNoTracking()
                .Include(po => po.ProductLog)
                .Include(po => po.Product)
                .Where(po => po.OrderId == orderId)
                .ToListAsync();

            var products = productOrders
                .Select(po => new ExtendedProductViewModel
                {
                    Name = po.ProductLog.Name,
                    Price = po.ProductLog.Price,
                    Barcode = po.Product.Barcode,
                    Quantity = po.Quantity,
                    CreatedAt = po.CreatedAt
                })
                .OrderByDescending(po => po.CreatedAt)
                .ToList();

            return new OrderDetailViewModel
            {
                Id = order.Id,
                Number = order.Number,
                OrderDate = order.CreatedAt,
                ShippingDate = order.ShippingDate,
                DeliveryStatus = order.DeliveryStatus.ToString(),
                TotalPrice = order.TotalPrice,
                AddressName = order.AddressLog.Name,
                TownName = order.AddressLog.Town,
                ZipCode = order.AddressLog.ZipCode,
                Products = products
            };
        }

        public async Task<List<PendingOrderViewModel>> GetUndeliveredOrdersAsync()
        {
            var orders = await _allBls.OrdersBL.GetAllAsync(o => o.DeliveryStatus == 0);

            return orders
                .Select(o => new PendingOrderViewModel
                {
                    Id = o.Id,
                    CreatedAt = o.CreatedAt
                })
                .OrderBy(o => o.CreatedAt)
                .ToList();
        }

        public async Task<bool> DeliverOrdersAsync(Guid orderId)
        {
            using var transaction = _allBls.OrdersBL.GetTransactionProxy();
            try
            {
                var order = await _allBls.OrdersBL.FindAsync(orderId)
                    ?? throw new InvalidOperationException(OrderNotFound);

                order.ShippingDate = DateTime.Now;
                order.DeliveryStatus += 1;
                order.UpdatedAt = DateTime.Now;

                var result = await _allBls.OrdersBL.SaveChangesAsync() > 0;
                await transaction.CommitAsync();
                return result;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
