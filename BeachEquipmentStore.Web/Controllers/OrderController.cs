namespace BeachEquipmentStore.Web.Controllers
{
    using BeachEquipmentStore.Services.Interfaces;
    using BeachEquipmentStore.Infrastructure.Extensions;
    using BeachEquipmentStore.ViewModels.Order;
    using BeachEquipmentStore.ViewModels.Product;
    using BeachEquipmentStore.ViewModels.Profile;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orders;
        private readonly ICartService _cart;

        public OrderController(IOrderService orders, ICartService cart)
        {
            _cart = cart;
            _orders = orders;
        }

        [HttpGet]
        [Route("Create-Order")]
        public async Task<IActionResult> CreateOrder()
        {
            try
            {
                var orderServiceData = await _orders.GetDataRequiredForOrder(Guid.Parse(User.GetId()));

                bool hasAddress = !string.IsNullOrEmpty(orderServiceData.UserAddress?.Name);
                ViewBag.HasAddress = hasAddress;

                decimal? sumOfAllProducts = orderServiceData.Products.Sum(p => p.Price * p.Quantity);
                ViewBag.FormattedSum = string.Format("{0:C}", sumOfAllProducts);

                return View(new CreateOrderViewModel
                {
                    UserDetails = new UserDetailsViewModel
                    {
                        FirstName = orderServiceData.UserDetails.FirstName,
                        LastName = orderServiceData.UserDetails.LastName,
                        Email = orderServiceData.UserDetails.Email,
                        PhoneNumber = orderServiceData.UserDetails.PhoneNumber,
                    },
                    UserAddress = new AddressDetailsViewModel
                    {
                        Name = orderServiceData.UserAddress!.Name,
                        Town = orderServiceData.UserAddress!.Town,
                        ZipCode = orderServiceData.UserAddress.ZipCode
                    },
                    Products = new List<ProductViewModel>(orderServiceData.Products.Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        Quantity = p.Quantity
                    }))
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create-Order")]
        public async Task<IActionResult> CreateOrder(bool hasAddress, string? addressName, string? town, string zipCode, decimal totalSum)
        {
            try
            {
                var userId = Guid.Parse(User.GetId());

                await _orders.GenerateOrder(userId, hasAddress, addressName, town, zipCode, totalSum);
                await _cart.ClearCartAfterOrder(userId);
                return RedirectToAction("OrderHistory", "Profile");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string orderId)
        {
            try
            {
                var detailsModel = await _orders.GetOrderDetails(orderId);

                return View(new OrderDetailViewModel
                {
                    Id = detailsModel.Id,
                    OrderDate = detailsModel.OrderDate,
                    ShippingDate = detailsModel.ShippingDate,
                    DeliveryStatus = detailsModel.DeliveryStatus,
                    DeliveryPrice = detailsModel.DeliveryPrice,
                    OverallPrice = detailsModel.TotalPrice,
                    TotalPrice = detailsModel.TotalPrice - detailsModel.DeliveryPrice,
                    AddressName = detailsModel.AddressName,
                    TownName = detailsModel.TownName,
                    ZipCode = detailsModel.ZipCode,
                    Products = detailsModel.Products.Select(p => new ExtendedProductViewModel
                    {
                        Name = p.Name,
                        Barcode = p.Barcode,
                        Price = p.Price,
                        Stock = p.Stock
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
        }
    }
}