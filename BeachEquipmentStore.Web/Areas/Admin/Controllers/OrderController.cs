namespace BeachEquipmentStore.Web.Areas.Admin.Controllers
{
    using BeachEquipmentStore.Web.Areas.Admin.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using static BeachEquipmentStore.Common.Constants.GeneralApplicationConstants;

    [Area("Admin")]
    public class OrderController : BaseAdminController
    {
        private readonly IOrderControllerService _orderControllerService;

        public OrderController(IOrderControllerService orderControllerService)
        {
            _orderControllerService = orderControllerService;
        }

        [HttpGet]
        [Route("Delivery-Status")]
        public async Task<IActionResult> Deliver()
        {
            var result = await _orderControllerService.GetUndeliveredOrdersAsync();

            if (!result.IsSuccess)
            {

                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            return View(result.UndeliveredOrders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteDelivery(Guid orderId)
        {
            var result = await _orderControllerService.DeliverOrdersAsync(orderId);

            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.ResponseMessage;

                return RedirectToAction("Index", "Home");
            }

            TempData["Message"] = result.ResponseMessage;

            return RedirectToAction("Deliver", "Order", new { Area = AdminAreaName });
        }
    }
}
