namespace BeachEquipmentStore.Services
{
    using Core.Enums;
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.ViewModels.Cart;
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.EntityFrameworkCore;
    using static Core.Common.Constants.Messages;

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

            return await _allBls.OrdersBL.SearchFor(o => o.CustomerUserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .Select(o => new OrderHistoryViewModel
                {
                    Id = o.Id,
                    Number = o.Number,
                    DeliveryStatus = o.DeliveryStatus.ToString(),
                    OrderDate = o.CreatedAt,
                    TotalPrice = o.TotalPrice
                })
                .ToListAsync();
        }

        public async Task<CreateOrderViewModel> GetDetailsForCreateOrderAsync()
        {
            var userId = _userService.GetCurrentLoggedInUserId();

            var user = await _allBls.UsersBL.FindAsNoTrackingAsync(userId)
                ?? throw new InvalidOperationException(UserNotFound);

            var customerUser = await _allBls.CustomerUsersBL.FindAsNoTrackingAsync(userId)
                ?? throw new InvalidOperationException(UserNotFound);

            var userDetails = new UserSummaryViewModel
            {
                FirstName = customerUser.FirstName,
                LastName = customerUser.LastName,
                Email = user.Email,
                PhoneNumber = customerUser.PhoneNumber ?? string.Empty
            };

            var userAddress = await _allBls.AddressesBL.SearchFor(a => a.CustomerUserId == userId)
                .OrderByDescending(a => a.IsPrimaryAddress)
                .Select(a => new AddressDetailsViewModel
                {
                    Name = a.Name,
                    Town = a.Town,
                    ZipCode = a.ZipCode
                })
                .FirstOrDefaultAsync() ?? new AddressDetailsViewModel();

            var cartItems = await _allBls.CartItemsBL.SearchFor(ci => ci.CustomerUserId == userId)
                .OrderByDescending(ci => ci.CreatedAt)
                .ToListAsync();

            var cartProductIds = cartItems.Select(ci => ci.ProductId).ToList();
            var cartProducts = await _allBls.ProductsBL.SearchFor(p => cartProductIds.Contains(p.Id)).ToListAsync();
            var cartProductMap = cartProducts.ToDictionary(p => p.Id);

            var userProducts = cartItems
                .Where(ci => cartProductMap.ContainsKey(ci.ProductId))
                .Select(ci => new CartProductViewModel
                {
                    Id = ci.ProductId,
                    Name = cartProductMap[ci.ProductId].Name,
                    ImageUrl = cartProductMap[ci.ProductId].ImageUrl,
                    Price = cartProductMap[ci.ProductId].Price,
                    CartQuantity = ci.Quantity
                })
                .ToList();

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

            if (!await _allBls.AddressesBL.All().AnyAsync(a => a.CustomerUserId == userId && a.Name == addressName && a.Town == town && a.ZipCode == zipCode))
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

                var cartItems = await _allBls.CartItemsBL.SearchFor(ci => ci.CustomerUserId == userId).ToListAsync();

                var orderProductIds = cartItems.Select(ci => ci.ProductId).ToList();
                var orderProducts = await _allBls.ProductsBL.SearchFor(p => orderProductIds.Contains(p.Id)).ToListAsync();
                var orderProductMap = orderProducts.ToDictionary(p => p.Id);

                var order = new Order
                {
                    DeliveryStatus = DeliveryStatus.Пътува,
                    CustomerUserId = userId,
                    AddressLogId = addressLog.Id
                };

                var productLogs = new List<ProductLog>();
                var productOrders = new List<ProductOrder>();
                decimal totalPrice = 0;

                foreach (var ci in cartItems)
                {
                    var product = orderProductMap[ci.ProductId];
                    var productLog = new ProductLog
                    {
                        Name = product.Name,
                        Price = product.Price
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
                foreach (var productLog in productLogs)
                    await _allBls.ProductLogsBL.AddAsync(productLog);
                await _allBls.OrdersBL.AddAsync(order);
                foreach (var productOrder in productOrders)
                    await _allBls.ProductOrdersBL.AddAsync(productOrder);

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
            var order = await _allBls.OrdersBL.FindAsNoTrackingAsync(orderId)
                ?? throw new InvalidOperationException(OrderNotFound);

            if (_userService.GetCurrentLoggedInUserId() != order.CustomerUserId)
                throw new InvalidOperationException(OrderNotFound);

            var addressLog = await _allBls.AddressLogsBL.FindAsNoTrackingAsync(order.AddressLogId);

            var productOrders = await _allBls.ProductOrdersBL.SearchFor(po => po.OrderId == orderId).ToListAsync();

            var productLogIds = productOrders.Select(po => po.ProductLogId).ToList();
            var detailProductIds = productOrders.Select(po => po.ProductId).ToList();

            var productLogs = await _allBls.ProductLogsBL.SearchFor(pl => productLogIds.Contains(pl.Id)).ToListAsync();
            var detailProducts = await _allBls.ProductsBL.SearchFor(p => detailProductIds.Contains(p.Id)).ToListAsync();

            var productLogMap = productLogs.ToDictionary(pl => pl.Id);
            var detailProductMap = detailProducts.ToDictionary(p => p.Id);

            var orderedProducts = productOrders
                .Select(po => new ExtendedProductViewModel
                {
                    Name = productLogMap[po.ProductLogId].Name,
                    Price = productLogMap[po.ProductLogId].Price,
                    Barcode = detailProductMap[po.ProductId].Barcode,
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
                AddressName = addressLog!.Name,
                TownName = addressLog.Town,
                ZipCode = addressLog.ZipCode,
                Products = orderedProducts
            };
        }

        public async Task<List<PendingOrderViewModel>> GetUndeliveredOrdersAsync()
        {
            return await _allBls.OrdersBL.SearchFor(o => o.DeliveryStatus == DeliveryStatus.Пътува)
                .OrderBy(o => o.CreatedAt)
                .Select(o => new PendingOrderViewModel
                {
                    Id = o.Id,
                    CreatedAt = o.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<bool> DeliverOrdersAsync(Guid orderId)
        {
            using var transaction = _allBls.OrdersBL.GetTransactionProxy();
            try
            {
                var order = await _allBls.OrdersBL.FindAsync(orderId)
                    ?? throw new InvalidOperationException(OrderNotFound);

                order.ShippingDate = DateTime.Now;
                order.DeliveryStatus = DeliveryStatus.Доставена;

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
