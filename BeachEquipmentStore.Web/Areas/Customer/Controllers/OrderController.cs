namespace BeachEquipmentStore.Web.Areas.Customer.Controllers
{
    using BeachEquipmentStore.Web.Areas.Customer.CustomerControllerServices.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class OrderController : BaseCustomerController
    {
        private readonly IOrderControllerService _orderControllerService;

        public OrderController(IOrderControllerService orderControllerService)
        {
            _orderControllerService = orderControllerService;
        }

        [HttpGet]
        [Route("Create-Order")]
        public async Task<IActionResult> CreateOrder()
        {
            var result = await _orderControllerService.GetDetailsForCreateOrderAsync();

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.DetailsForCreateOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create-Order")]
        public async Task<IActionResult> CreateOrder(string? addressName, string? town, string zipCode)
        {
            var result = await _orderControllerService.CreateOrderAsync(addressName, town, zipCode);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("OrderHistory", "Profile");
        }

        [HttpGet]
        [Route("Order-Details")]
        public async Task<IActionResult> Details(string orderId)
        {
            var result = await _orderControllerService.GetOrderDetailsAsync(orderId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.OrderDetails);
        }
    }
}
