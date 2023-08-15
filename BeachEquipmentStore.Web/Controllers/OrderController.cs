using BeachEquipmentStore.Services.Data.Interfaces;
using BeachEquipmentStore.Web.ViewModels.Order;
using BeachEquipmentStore.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace BeachEquipmentStore.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orders;

        public OrderController(IOrderService orders)
        {
            _orders = orders;
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder(string userId)
        {
            var orderServiceData = await _orders.GetDataRequiredForOrder(userId);

            decimal? sumOfAllProducts = orderServiceData.Products.Sum(p => p.Price * p.Quantity);
            ViewBag.FormattedSum = string.Format("{0:C}", sumOfAllProducts);

            return View(new CreateOrderViewModel
            {
                FirstName = orderServiceData.FirstName,
                LastName = orderServiceData.LastName,
                Email = orderServiceData.Email,
                PhoneNumber = orderServiceData.PhoneNumber,
                AddressName = orderServiceData.AddressName,
                Town = orderServiceData.Town,
                ZipCode = orderServiceData.ZipCode,
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

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            return RedirectToAction("All", "Product");
        }
    }
}
